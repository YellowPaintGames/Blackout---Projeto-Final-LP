using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
namespace Blackout
{
    /// <summary>
    /// The class responsible for information within the Board, and its logic.
    /// </summary>
    public class BlackoutBoard
    {
        private Controller C;
        public int size { private set; get; }

        /// <summary>
        /// Gets the two-dimensional array representing the game board.
        /// </summary>
        public Pip[,] Board { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlackoutBoard"/> class.
        /// </summary>
        /// <param name="size">The size of the board.</param>
        /// <param name="controller">Controller that manages the game flow.</param>
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
            if (size == 3)
            {
                C.difficulty = "Easy";
            }
            else if (size == 5)
            {
                C.difficulty = "Normal";
            }
            else if (size == 8)
            {
                C.difficulty = "Hard";
            }
        }

        /// <summary>
        /// Initializes the board with a random pattern of lit pips to start a new game.
        /// </summary>
        public void StartRandomBoard()
        {
            int numberOfSpots = 3;

            if (size == 3) numberOfSpots = 1; //Easy
            else if (size == 5) numberOfSpots = 2; //Medium
            else if (size == 8) numberOfSpots = 3; //Hard

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

        /// <summary>
        /// Toggles the state of a pip at the given coordinates and its adjacent pips
        /// (Up, Down, Left, Right).
        /// </summary>
        /// <param name="coords">The coordinates (X, Y) of the pip to toggle.</param>
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
            //Checks if the diagonals are valid
            if (coords.X - 1 > 0 && coords.Y - 1 > 0)
            {
                Board[coords.Y - 1, coords.X - 1].Toggle();
            }
            if (coords.X + 1 < Board.GetLength(1) - 1 && coords.Y + 1 < Board.GetLength(0))
            {
                Board[coords.Y + 1, coords.X + 1].Toggle();
            }
            if (coords.Y - 1 > 0 && coords.X + 1 < Board.GetLength(0))
            {
                Board[coords.Y - 1, coords.X + 1].Toggle();
            }
            if (coords.Y + 1 < Board.GetLength(0) && coords.X - 1 > 0)
            {
                Board[coords.Y + 1, coords.X - 1].Toggle();
            }
            C.NextTurn();
        }

        /// <summary>
        /// Checks if all pips on the board are turned On.
        /// </summary>
        /// <returns>True if all pips are On, otherwise false.</returns>
        public bool IsWin()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (!Board[i, j].On)
                        return false;
                }
            }
            return true;
        }
    }
}