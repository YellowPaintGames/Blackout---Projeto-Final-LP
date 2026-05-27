using System;

namespace Blackout
{
    public class Controller
    {
        private readonly IView spectreView;

        public Controller(BlackoutBoard b, IView v)
        {
            spectreView = v;
            spectreView.SetBoardRef(b);
        }

        public void Run()
        {
            while (true)
            {
                var choice = spectreView.GetMenuChoice();

                if(choice == "Play")
                {
                    spectreView.ShowBoard();
                    spectreView.PromptUser();
                }
                if(choice == "HowToPlay")
                {
                    break;
                }
                if(choice == "Exit")
                {
                    break;
                }
            }
        }
    }
}