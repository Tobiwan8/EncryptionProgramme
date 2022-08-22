using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypteringsprogram
{
    internal class PincodeCheck
    {
        internal static bool CheckIfValidPincode(string pin)
        {
            //if pin length is not 4, it will return false
            if (pin.Length != 4) { return false; }

            //runs through each char in pin
            foreach (char num in pin)
            {
                //if the char is not a digit, it will return false
                if (!Char.IsDigit(num)) { return false; }
            }
            //returns true if all conditions are met
            return true;
        }
    }
}
