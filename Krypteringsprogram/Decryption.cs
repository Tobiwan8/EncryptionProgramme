using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypteringsprogram
{
    internal class Decryption
    {
        // Comments are the same as in Encryption, except for Decryption instead.
        static string letters = "abcdefghijklmnopqrstuvwxyz";
        static string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string numbers = "0123456789";
        static string special = "!\"@#£¤$%&/{([)]=}?+´`|¨^~'*-_.:,; ";
        static string output;
        static int pinNr;
        static int count;

        internal static string TranslateCode(string str, string pin)
        {
            output = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (special.Contains(str[i]))
                {
                    DecryptSpecial(str, pin, i);
                }
                else if (letters.Contains(str[i]))
                {
                    DecryptLetters(str, pin, i);
                }
                else if (capLetters.Contains(str[i]))
                {
                    DecryptCapLetters(str, pin, i);
                }
                else
                {
                    DecryptNumbers(str, pin, i);
                }
            }
            return output;
        }

        static void DecryptSpecial(string str, string pin, int i)
        {
            // Takes the first digit of pincode to make decryption
            pinNr = Convert.ToInt32(pin[0].ToString());
            // If pinNR is 0, it wont decrypt the type of characters - therefore it will automatically change to 1
            if (pinNr == 0) { pinNr = 1; }
            // Finds the index of the char from the in the inputstring, in the special string
            count = special.IndexOf(str[i]);
            if (count - pinNr < 0)
            {
                // Will count backwards from special.Length if count - pinNr is less than 0 and add it to output
                output += special[(special.Length) + (count - pinNr)];
            }
            else
            {
                // Otherwise it will add the new char in special to output
                output += special[count - pinNr];
            }
        }

        static void DecryptLetters(string str, string pin, int i)
        {
            // Comments are the same as in DecryptSpecial, but for letters instead
            pinNr = Convert.ToInt32(pin[1].ToString());
            if (pinNr == 0) { pinNr = 1; }
            count = letters.IndexOf(str[i]);
            if (count - pinNr < 0)
            {
                output += letters[letters.Length + (count - pinNr)];
            }
            else
            {
                output += letters[count - pinNr];
            }
        }

        static void DecryptCapLetters(string str, string pin, int i)
        {
            // Comments are the same as in DecryptSpecial, but for capital letters instead
            pinNr = Convert.ToInt32(pin[2].ToString());
            if (pinNr == 0) { pinNr = 1; }
            count = capLetters.IndexOf(str[i]);
            if (count - pinNr < 0)
            {
                output += capLetters[capLetters.Length + (count - pinNr)];
            }
            else
            {
                output += capLetters[count - pinNr];
            }
        }

        static void DecryptNumbers(string str, string pin, int i)
        {
            // Comments are the same as in DecryptSpecial, but for numbers instead
            pinNr = Convert.ToInt32(pin[3].ToString());
            if (pinNr == 0) { pinNr = 1; }
            count = numbers.IndexOf(str[i]);
            if (count - pinNr < 0)
            {
                output += numbers[numbers.Length + (count - pinNr)];
            }
            else
            {
                output += numbers[count - pinNr];
            }
        }
    }
}

