using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypteringsprogram
{
    internal class Encryption
    {
        // All variables created as fields.
        static string letters = "abcdefghijklmnopqrstuvwxyz";
        static string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string numbers = "0123456789";
        static string special = "!\"@#£¤$%&/{([)]=}?+´`|¨^~'*-_.:,; ";
        static string output;
        static int pinNr;
        static int count;

        internal static string GenerateCode(string str, string pin)
        {
            // Output always has to be reset to empty, so it doesnt stack when the programme is run multiple times.
            output = "";
            
            // For loop to go through each char in the string u want to encrypt.
            for (int i = 0; i < str.Length; i++)
            {
                if (special.Contains(str[i]))
                {
                    // Method that determines what to do if character is a special sign.
                    GenerateSpecial(str, pin, i);
                }
                else if (letters.Contains(str[i]))
                {
                    // Method that determines what to do if character is a letter.
                    GenerateLetters(str, pin, i);
                }
                else if (capLetters.Contains(str[i]))
                {
                    // Method that determines what to do if character is a capital letter.
                    GenerateCapLetters(str, pin, i);
                }
                else
                {
                    // Method that determines what to do if character is a number.
                    GenerateNumbers(str, pin, i);
                }
            }
            //Exiting the method by returning the output.
            return output;
        }

        static void GenerateSpecial(string str, string pin, int i)
        {
            // Takes the first digit of pincode to make encryption.
            pinNr = Convert.ToInt32(pin[0].ToString());
            // If pinNR is 0, it wont encrypt the type of characters - therefore it will automatically change to 1.
            if (pinNr == 0) { pinNr = 1; }
            // Finds the index of the char from the in the inputstring, in the special string.
            count = special.IndexOf(str[i]);
            if (count + pinNr > special.Length - 1)
            {
                // Will count the remaining from index 0 if count + pinNr is bigger than the special string and add it to output.
                output += special[(count + pinNr) % (special.Length)];
            }
            else
            {
                // Otherwise it will add the new char in special to output.
                output += special[count + pinNr];
            }
        }

        static void GenerateLetters(string str, string pin, int i)
        {
            // Comments are the same as in GenerateSpecial, but for letters instead.
            pinNr = Convert.ToInt32(pin[1].ToString());
            if (pinNr == 0) { pinNr = 1; }
            count = letters.IndexOf(str[i]);
            if (count + pinNr > letters.Length - 1)
            {
                output += letters[(count + pinNr) % (letters.Length)];
            }
            else
            {
                output += letters[count + pinNr];
            }
        }

        static void GenerateCapLetters(string str, string pin, int i)
        {
            // Comments are the same as in GenerateSpecial, but for capital letters instead.
            pinNr = Convert.ToInt32(pin[2].ToString());
            if (pinNr == 0) { pinNr = 1; }
            count = capLetters.IndexOf(str[i]);
            if (count + pinNr > capLetters.Length - 1)
            {
                output += capLetters[(count + pinNr) % (capLetters.Length)];
            }
            else
            {
                output += capLetters[count + pinNr];
            }
        }

        static void GenerateNumbers(string str, string pin, int i)
        {
            // Comments are the same as in GenerateSpecial, but for numbers instead.
            pinNr = Convert.ToInt32(pin[3].ToString());
            if (pinNr == 0) { pinNr = 1; }
            count = numbers.IndexOf(str[i]);
            if (count + pinNr > numbers.Length - 1)
            {
                output += numbers[(count + pinNr) % (numbers.Length)];
            }
            else
            {
                output += numbers[count + pinNr];
            }
        }
    }
}
