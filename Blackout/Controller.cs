using System;

namespace Blackout
{
    public class Controller
    {
        private IView View;
        private BlackoutBoard Board;
        public void StartController(IView v)
        {
            View = v;
        }
        public void StartGame()
        {
            Board = new BlackoutBoard(View.PromptStart(), this);
            View.ShowBoard(Board);
            Board.ToggleBoard(View.PromptUser(Board));
        }
        public void NextTurn()
        {
            View.ShowBoard(Board);
            Board.ToggleBoard(View.PromptUser(Board));
        }
    }
}