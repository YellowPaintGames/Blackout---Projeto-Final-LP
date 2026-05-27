using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Blackout
{
    public interface IView
    {
        /// <summary>
        /// The method called by the scene to show the game area
        /// (in our case using Specter.Console).
        /// </summary>
        /// <param name="size">The size of the playable area.</param>
        void ShowBoard(BlackoutBoard B);
        /// <summary>
        /// Tells the view which controller is being used.
        /// </summary>
        /// <param name="C">Controller that is going to be referenced.</param>
        void SetControllerRef(Controller C);
        /// <summary>
        /// Asks the coordinates X,Y where the Player wants toggle.
        /// </summary>
        /// <param name="B">It's the Board</param>
        /// <returns>coords X,Y</returns>
        (int, int) PromptUser(BlackoutBoard B);
        /// <summary>
        /// Prompts the Player with a menu where he can choose between the
        /// options "Play" that starts the game, "HowToPlay" that explains how
        /// to play the game and "Exit" that ends the program.
        /// </summary>
        void PromptMenuChoice();
        /// <summary>
        /// Prompts the Player to choose the difficulty of the game.
        /// </summary>
        /// <returns>Returns the 3 options of difficulty the Player can choose from.</returns>
        int PromptStart();
    }
}