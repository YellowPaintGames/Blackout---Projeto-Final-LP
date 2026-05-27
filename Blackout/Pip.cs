using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Blackout
{
    /// <summary>
    /// The squares that make up the board have 2 modes:
    /// - On
    /// - Off
    /// </summary>
    public class Pip
    {
        /// <summary>
        /// Sets the default Pips to Off
        /// </summary>
        public bool On { get; private set; } = false;
        /// <summary>
        /// Turns the current Pip On and Off
        /// </summary>
        public void Toggle()
        {
            On = !On;
        }
        /// <summary>
        /// This is here for debugging
        ///  (needs to be here otherwise the 0 and 1 doesn't load)
        /// </summary>
        /// <returns>ToString converted into a Byte(On)</returns>
        public override string ToString()
        {
            return Convert.ToString(Convert.ToByte(On));
        }
    }
}