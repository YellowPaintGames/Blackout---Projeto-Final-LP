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
    /// O que vai ser utilizado para mostrar o tabuleiro
    /// </summary>
    public class SpectreView : IView
    {
        private Controller Controller;
        public void ShowBoard(BlackoutBoard B)
        {
            for (int i = 0; i < B.Board.GetLength(0); i++)
            {
                for (int j = 0; j < B.Board.GetLength(1); j++)
                {
                    Console.Write(B.Board[i, j] + "   ");
                }
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
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Pick an Option\n    Play\n  HowToPlay\n     Exit").AddChoices("Play", "HowToPlay", "Exit"));
            if (choice == "Play")
            {
                Controller.StartGame();
            }
            if (choice == "HowToPlay")
            {
                AnsiConsole.WriteLine("Some prompts will appear after the board, write out the coordinates and make them all [green] green! [/]");
                PromptMenuChoice();
            }
            if (choice == "Exit")
            {
                AnsiConsole.Write("[red]BYE!![/]");
            }
        }
        public int PromptStart()
        {
            return AnsiConsole.Prompt(new SelectionPrompt<int>().Title("Pick an Option\n    Easy\n  Medium\n     Hard").AddChoices(3, 5, 8));
        }
        public void SetControllerRef(Controller C)
        {
            Controller = C;
        }
    }
}