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
        /* This programme lets you encrypt a sentence with a pincode. When you want to decrypt your sentence,
         you'll have to enter the same pincode for it to turn back to your original sentence */

        //All variables outside Main - created as fields
        internal static string s = "";
        internal static string pincode = "";

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

        static void GenerateOption()
        {
            //User inputs sentence they want to encrypt
            Console.Write("Indtast sætning for kryptering: ");
            s = Console.ReadLine();
            //asks user for a 4 digit code - loop will run untill they do
            do
            {
                Console.Write("Indtast 4-cifret pinkode: ");
                pincode = Console.ReadLine();
            } while (PincodeCheck.CheckIfValidPincode(pincode) == false); //references to the class PincodeCheck, and the method inside
            //Runs and outputs the GenerateCode method.
            Console.WriteLine("\n" + Encryption.GenerateCode(s, pincode));
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
            } while (PincodeCheck.CheckIfValidPincode(pincode) == false);
            Console.WriteLine("\n" + Decryption.TranslateCode(s, pincode));
        }
    }
}
