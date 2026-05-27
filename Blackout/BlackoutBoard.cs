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

        public void StartRandomBoard()
        {
            //difficulty defaults medium
            int difficulty = 1; //0 - easy (3x3), 1- medium (5x5), 2 - hard(8x8)
            int numberOfSpots = 3; //easy = 1, medium = 3, hard = 5

            if(difficulty == 0) numberOfSpots = 1;
            if(difficulty == 2) numberOfSpots = 5;

            Random rand = new Random();

            while (numberOfSpots != 0)
            {
                int randomSpotx  = rand.Next(0, Board.GetLength(0));
                int randomSpoty  = rand.Next(0, Board.GetLength(1));
                for (int x = 0; x <= randomSpotx; x++)
                {
                    for (int y = 0; y <= randomSpoty; y++)
                    {
                        if(x == randomSpotx && y == randomSpoty)
                        {
                            Board[x, y].Toggle();
                            numberOfSpots--;
                        }                        
                    }
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