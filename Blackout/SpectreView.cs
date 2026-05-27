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
        private BlackoutBoard Board;
        public void ShowBoard()
        {
            for (int i = 0; i < Board.Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.Board.GetLength(1); j++)
                {
                    string cor = "";
                    if (Board.Board[i, j].On)
                    {
                        cor = "green";
                    }
                    else { cor = "red"; }
                    AnsiConsole.Write($"[{cor}]{Board.Board[i, j]}[/]   ");
                }
            }
                AnsiConsole.WriteLine();
        }
    
        public void SetBoardRef(BlackoutBoard B)
        {
            Board = B;
        }

        public void PromptUser()
        {
            int X;
            int Y;

            Console.WriteLine("Where to Toggle in the X axis?");
            X = Convert.ToInt16(Console.ReadLine());


            Console.WriteLine("Where to Toggle in the Y axis?");
            Y = Convert.ToInt16(Console.ReadLine());

            X -= 1;
            Y -= 1;
            X = Math.Clamp(X, 0, Board.Board.GetLength(1) - 1);
            Y = Math.Clamp(Y, 0, Board.Board.GetLength(0) - 1);
            AnsiConsole.WriteLine(X + " " + Y);
            Board.ToggleBoard(X, Y);
        }

        public string GetMenuChoice()
        {
            AnsiConsole.Write(new FigletText("Blackout").Centered().Color(Spectre.Console.Color.White));

            return AnsiConsole.Prompt(new SelectionPrompt<string>().Title("[lightgreen]Use[/] [bold cyan]Up Arrow[/] [lightgreen]and[/] [bold cyan]Down Arrow[/] [lightgreen]to move between the options[/]").AddChoices("Play", "HowToPlay", "Exit"));
        }
    }
}