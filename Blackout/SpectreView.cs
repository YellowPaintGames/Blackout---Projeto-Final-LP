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
                    Console.Write(Board.Board[i, j] + "   ");
                }
                Console.WriteLine();
            }
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
            Console.WriteLine(X + " " + Y);
            Board.ToggleBoard(X, Y);
        }

        public string GetMenuChoice()
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Pick an Option\n    Play\n  HowToPlay\n     Exit").AddChoices("Play", "HowToPlay", "Exit"));
        }
    }
}