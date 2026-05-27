using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public void ToggleBoard(int X, int Y)
        {
            Board[Y, X].Toggle();
            if(X > 0)
            {
                Board[Y,X - 1].Toggle();
            }
            if(X < Board.GetLength(1) - 1)
            {
                Board[Y,X + 1].Toggle();
            }
            if(Y > 0)
            {
                Board[Y - 1,X].Toggle();
            }
            if(Y < Board.GetLength(0) - 1)
            {
                Board[Y + 1,X].Toggle();
            }

            /*
            Console.WriteLine(X + " " + Math.Clamp(Y - 1, 0, Board.GetLength(1) - 1));
            Console.WriteLine(X + " " + Math.Clamp(Y + 1, 0, Board.GetLength(1) - 1));
            Console.WriteLine(Math.Clamp(X + 1, 0, Board.GetLength(0) - 1) + " " + Y);
            Console.WriteLine(Math.Clamp(X - 1, 0, Board.GetLength(0) - 1) + " " + Y);
            ^Cena para debug - FC
            */
        }
    }
}