using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace Blackout
{
    /// <summary>
    ///This is the View of the Game.
    /// </summary>
    public class SpectreView : IView
    {
        /// <summary>
        /// Instance Reference.
        /// </summary>
        private Controller Controller;

        public void ShowBoard(BlackoutBoard B)
        {
            AnsiConsole.Clear();

            for (int i = 0; i < B.Board.GetLength(0); i++)
            {
                for (int j = 0; j < B.Board.GetLength(1); j++)
                {
                    if (B.Board[i, j].On)
                    {
                        AnsiConsole.Markup("[lightgreen]██[/] ");
                    }
                    else
                    {
                        AnsiConsole.Markup("[red]██[/] ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public (int, int) PromptUser(BlackoutBoard B)
        {
            int X;
            int Y;
            Console.WriteLine("Where to Toggle in the X axis?");
            X = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Where to Toggle in the Y axis?");
            Y = Convert.ToInt16(Console.ReadLine());
            X -= 1;
            Y -= 1;
            X = Math.Clamp(X, 0, B.Board.GetLength(1) - 1);
            Y = Math.Clamp(Y, 0, B.Board.GetLength(0) - 1);
            (int, int) coords = (X, Y);
            return coords;
        }
        public void PromptMenuChoice()
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText 
            ("Blackout").Centered().Color(Spectre.Console.Color.White));

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("[lightgreen]Use[/] [bold cyan]Up Arrow[/] [lightgreen]and[/] [bold cyan]Down Arrow[/] [lightgreen]to move between the options[/]")
            .AddChoices("Play", "How To Play", "Exit"));
            if (choice == "Play")
            {
                Controller.StartGame();
            }
            if (choice == "How To Play")
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("Some prompts will appear after the board, write out the coordinates and make them all [lightgreen]green! [/]");
                AnsiConsole.MarkupLine("\nPress any key to return to the menu...");
                Console.ReadKey(true);
                PromptMenuChoice();
            }
            if (choice == "Exit")
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[red]BYE!![/]");
            }
        }
        public int PromptStart()
        {
            return AnsiConsole.Prompt(new SelectionPrompt<int>().Title("Pick an Option\n  Easy\n  Medium\n  Hard").AddChoices(3, 5, 8));
        }
        public void SetControllerRef(Controller C)
        {
            Controller = C;
        }

        public void ShowWinMessage()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]You Win![/]");
            AnsiConsole.MarkupLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
            PromptMenuChoice();
        }
    }
}