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
        private Controller C;
        private int size;
        public Pip[,] Board { get; private set; }
        public BlackoutBoard(int size, Controller controller)
        {
            C = controller;
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
        public void ToggleBoard((int X, int Y) coords)
        {
            Board[coords.Y, coords.X].Toggle();
            if (coords.X > 0)
            {
                Board[coords.Y, coords.X - 1].Toggle();
            }
            if (coords.X < Board.GetLength(1) - 1)
            {
                Board[coords.Y, coords.X + 1].Toggle();
            }
            if (coords.Y > 0)
            {
                Board[coords.Y - 1, coords.X].Toggle();
            }
            if (coords.Y < Board.GetLength(0) - 1)
            {
                Board[coords.Y + 1, coords.X].Toggle();
            }
            C.NextTurn();
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