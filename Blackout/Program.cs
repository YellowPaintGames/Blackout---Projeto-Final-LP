using System;
namespace Blackout
{
    /// <summary>
    /// Blackout Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program begins here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main(string[] args)
        {
            IView V = new SpectreView();

            //Instantiate Controller
            Controller controller = new();

            V.SetControllerRef(controller);

            controller.StartController(V);

            V.PromptMenuChoice();
        }
    }
}