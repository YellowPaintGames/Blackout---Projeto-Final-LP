using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
namespace Blackout
{
    /// <summary>
    /// A classe responsável pela informação dentro do Board,
    /// e a sua lógica
    /// </summary>
    public class BlackoutBoard
    {
        private int size;
        public Pip[,] Board { get; private set; }
        public BlackoutBoard(int size)
        {
            this.size = size;
            Board = new Pip[size, size];
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = new Pip();
                }
            }
        }
    }
}