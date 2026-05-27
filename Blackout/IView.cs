using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Blackout
{
    public interface IView
    {
        /// <summary>
        /// O método chamado pela cena de mostrar coisas 
        /// (no nosso caso usando Specter.Console)
        /// para mostrar a área de jogo
        /// </summary>
        /// <param name="size">O tamanho da área jogável</param>
        void ShowBoard(BlackoutBoard B);
        void SetControllerRef(Controller C);
        (int, int) PromptUser(BlackoutBoard B);
        void PromptMenuChoice();
        int PromptStart();
    }
}