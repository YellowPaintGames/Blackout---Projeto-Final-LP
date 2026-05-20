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
            Board[Y, Math.Clamp(X - 1, 0, Board.GetLength(0) - 1)].Toggle();
            Board[Y, Math.Clamp(X + 1, 0, Board.GetLength(0) - 1)].Toggle();
            Board[Math.Clamp(Y + 1, 0, Board.GetLength(1) - 1), X].Toggle();
            Board[Math.Clamp(Y - 1, 0, Board.GetLength(1) - 1), X].Toggle();

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