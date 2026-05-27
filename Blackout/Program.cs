using System;
namespace Blackout
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IView V = new SpectreView();
            Controller controller = new();
            V.SetControllerRef(controller);
            controller.StartController(V);
            V.PromptMenuChoice();
        }
    }
}