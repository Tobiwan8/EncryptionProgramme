using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Krypteringsprogram
{
    internal class Program
    {
        //All variables outside Main - created as fields
        static string letters = "abcdefghijklmnopqrstuvwxyz";
        static string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string numbers = "0123456789";
        static string special = "!\"@#£¤$%&/{([)]=}?+´`|¨^~'*-_.:,; ";
        static string output = "";
        static int count = 0;
        static int pinNr = 0;
        static string s = "";
        static string pincode = "";

        static void Main(string[] args)
        {
            //Runs the menu until the application is closed
            while (true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.WriteLine("\n1. Generer kode\n2. Oversæt kode\n\nIndtast valg ");

            //Gives the opportunity to choose from menu by pressing 1 or 2
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    //Generate encryption method
                    GenerateOption();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    //Generate decryption method
                    DecryptOption();
                    break;
                default:
                    break;
            }
        }    

        static string GenerateCode(string str, string pin)
        {
            //output always has to be reset to empty, so it doesnt stack when the programme is run multiple times
            output = "";
            
            //for loop to go through each char in the sentence u want to encrypt
            for(int i = 0; i < str.Length; i++)
            {
                if (special.Contains(str[i]))
                {
                    //method that determines what to do if character is a special sign
                    GenerateSpecial(str, pin, i);
                }
                else if (letters.Contains(str[i]))
                {
                    //method that determines what to do if character is a letter
                    GenerateLetters(str, pin, i);
                }
                else if (capLetters.Contains(str[i]))
                {
                    //method that determines what to do if character is a capital letter
                    GenerateCapLetters(str, pin, i);
                }
                else
                {
                    //method that determines what to do if character is a number
                    GenerateNumbers(str, pin, i);
                }
            }
            //Exiting the method by return the output
            return output;
        }

        static string TranslateCode(string str, string pin)
        {
            //Comments are the same as in GenerateCode, except for decryption instead.
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

        static void GenerateOption()
        {
            //User inputs sentence they want to encrypt
            Console.Write("Indtast sætning for kryptering: ");
            s = Console.ReadLine();
            //asks user for a 4 digit code - will run untill they do
            do
            {
                Console.Write("Indtast 4-cifret pinkode: ");
                pincode = Console.ReadLine();
            } while (pincode.Length != 4);
            //Runs and outputs the GenerateCode method.
            Console.WriteLine("\n" + GenerateCode(s, pincode));
        }

        static void DecryptOption()
        {
            //Comments are the same as GenerateOption - but for decryption instead.
            Console.Write("Indtast sætning for dekryptering: ");
            s = Console.ReadLine();
            do
            {
                Console.Write("Indtast 4-cifret pinkode: ");
                pincode = Console.ReadLine();
            } while (pincode.Length != 4);
            Console.WriteLine("\n" + TranslateCode(s, pincode));
        }
        
        static void GenerateSpecial(string str, string pin, int i)
        {
            //Takes the first digit of pincode to make encryption
            pinNr = Convert.ToInt32(pin[0].ToString());
            //If pinNR is 0, it wont encrypt the type of characters - therefore it will automatically change to 1
            if(pinNr == 0) { pinNr = 1; }
            //finds the index of the char from the in the inputstring, in the special string
            count = special.IndexOf(str[i]);
            if (count + pinNr > special.Length - 1)
            {
                //Will count the remaining from index 0 if count + pinNr is bigger than the special string and add it to output
                output += special[(count + pinNr) % (special.Length)];
            }
            else
            {
                //Otherwise it will add the new char in special to output
                output += special[count + pinNr];
            }
        }
        
        static void GenerateLetters(string str, string pin, int i)
        {
            //Comments are the same as in GenerateSpecial, but for letters instead
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
            //Comments are the same as in GenerateSpecial, but for capital letters instead
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
            //Comments are the same as in GenerateSpecial, but for numbers instead
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
        
        static void DecryptSpecial(string str, string pin, int i)
        {
            //Takes the first digit of pincode to make decryption
            pinNr = Convert.ToInt32(pin[0].ToString());
            //If pinNR is 0, it wont decrypt the type of characters - therefore it will automatically change to 1
            if (pinNr == 0) { pinNr = 1; }
            //finds the index of the char from the in the inputstring, in the special string
            count = special.IndexOf(str[i]);
            if (count - pinNr < 0)
            {
                //Will count backwards from special.Length if count - pinNr is less than 0 and add it to output
                output += special[(special.Length) + (count - pinNr)];
            }
            else
            {
                //Otherwise it will add the new char in special to output
                output += special[count - pinNr];
            }
        }

        static void DecryptLetters(string str, string pin, int i)
        {
            //Comments are the same as in DecryptSpecial, but for letters instead
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
            //Comments are the same as in DecryptSpecial, but for capital letters instead
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
            //Comments are the same as in DecryptSpecial, but for numbers instead
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
