using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Blackout
{
    /// <summary>
    /// Os coisinhos que consistem do board, têm 2 modos:
    /// - Ligado
    /// - Desligado
    /// </summary>
    public class Pip
    {
        public bool On { get; private set; } = false;
        /// <summary>
        /// Liga/Desliga este Pip atual
        /// </summary>
        public void Toggle()
        {
            On = !On;
        }
        /// <summary>
        /// Isto está aqui a âmbito de debugging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Convert.ToString(Convert.ToByte(On));
        }
    }
}