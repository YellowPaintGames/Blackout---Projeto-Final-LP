using System;
using System.IO;

namespace Blackout
{
    /// <summary>
    /// Main controller for the Blackout game.
    /// Coordinates communication between the View and the Model.
    /// </summary>
    public class Controller
    {
        private IView View;
        private BlackoutBoard Board;
        public int Turns { set; get; } = 0;
        public string difficulty { set; get; }
        /// <summary>
        /// Initializes the controller with a view implementation.
        /// </summary>
        /// <param name="v">The view that handles user interface and input.</param>
        public void StartController(IView v)
        {
            View = v;
        }

        /// <summary>
        /// Creates the board, shows it, and prompts the user for the first move.
        /// </summary>
        public void StartGame()
        {
            Turns = 1;
            Board = new BlackoutBoard(View.PromptStart(), this);
            Board.StartRandomBoard();
            View.ShowBoard(Board);
            Board.ToggleBoard(View.PromptUser(Board));
        }

        /// <summary>
        /// Handles the next turn after a player move,
        /// refreshes the board display and prompts the Player for the next input.
        /// </summary>
        public void NextTurn()
        {
            View.ShowBoard(Board);
            if (Board.IsWin())
            {
                if (LoadScores(difficulty).Item2 > Turns)
                {
                    SaveGame(difficulty, Turns);
                }
                View.ShowWinMessage();
                return;
            }
            Turns++;
            Board.ToggleBoard(View.PromptUser(Board));
        }
        private void SaveGame(string Difficulty, int Turns)
        {
            StreamWriter S = new StreamWriter("HighScores.txt");
            S.WriteLine($"{Difficulty} : {Turns} Turns (Try getting a smaller number!)");
            S.Close();
        }
        public (string, int) LoadScores(string Difficulty)
        {
            string s;
            string Result = "You haven't gotten a score here!";
            int turns = 0;
            using StreamReader S = new StreamReader("HighScores.txt");
            while ((s = S.ReadLine()) != null)
            {
                foreach (string word in s.Split(" "))
                {
                    if (Difficulty == word)
                    {
                        Result = s;
                        turns = int.Parse(s.Split(" ")[2]);
                    }
                }
            }
            return (Result, turns);
        }
    }
}