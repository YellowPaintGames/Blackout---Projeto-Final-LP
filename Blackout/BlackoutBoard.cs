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
        public void StartRandomBoard()
        {
            //difficulty defaults medium
            int difficulty = 1; //0 - easy (3x3), 1- medium (5x5), 2 - hard(8x8)
            int numberOfSpots = 3; //easy = 1, medium = 3, hard = 5

            if (difficulty == 0) numberOfSpots = 1;
            if (difficulty == 2) numberOfSpots = 5;

            Random rand = new Random();

            while (numberOfSpots != 0)
            {
                int randomSpotx = rand.Next(0, Board.GetLength(0));
                int randomSpoty = rand.Next(0, Board.GetLength(1));
                for (int x = 0; x <= randomSpotx; x++)
                {
                    for (int y = 0; y <= randomSpoty; y++)
                    {
                        if (x == randomSpotx && y == randomSpoty)
                        {
                            Board[x, y].Toggle();
                            numberOfSpots--;
                        }
                    }
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