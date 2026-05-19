using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

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
                    Board.Board[i, 2].Toggle();
                    Console.Write(Board.Board[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }
        public void SetBoardRef(BlackoutBoard B)
        {
            Board = B;
        }
    }
}