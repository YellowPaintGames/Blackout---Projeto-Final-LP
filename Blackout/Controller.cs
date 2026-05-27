using System;

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
            Board = new BlackoutBoard(View.PromptStart(), this);
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
                View.ShowWinMessage();
                return;
            }
            Board.ToggleBoard(View.PromptUser(Board));
        }
    }
}