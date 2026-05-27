using System;

namespace Blackout
{
    public class Controller
    {
        private readonly SpectreView spectreView;

        public Controller()
        {
            spectreView = new SpectreView();
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