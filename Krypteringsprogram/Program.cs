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
            while (true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.WriteLine("\n1. Generer kode\n2. Oversæt kode\n\nIndtast valg ");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    GenerateOption();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    DecryptOption();
                    break;
                default:
                    break;
            }
        }    

        static string GenerateCode(string str, string pin)
        {
            output = "";
            
            for(int i = 0; i < str.Length; i++)
            {
                if (special.Contains(str[i]))
                {
                    GenerateSpecial(str, pin, i);
                }
                else if (letters.Contains(str[i]))
                {
                    GenerateLetters(str, pin, i);
                }
                else if (capLetters.Contains(str[i]))
                {
                    GenerateCapLetters(str, pin, i);
                }
                else
                {
                    GenerateNumbers(str, pin, i);
                }
            }
            return output;
        }

        static string TranslateCode(string str, string pin)
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

        static void GenerateOption()
        {
            Console.WriteLine("Indtast sætning for kryptering: ");
            s = Console.ReadLine();
            Console.WriteLine("Indtast pinkode: ");
            pincode = Console.ReadLine();
            Console.WriteLine(GenerateCode(s, pincode));
        }

        static void DecryptOption()
        {
            Console.WriteLine("Indtast sætning for dekryptering: ");
            s = Console.ReadLine();
            Console.WriteLine("Indtast pinkode: ");
            pincode = Console.ReadLine();
            Console.WriteLine(TranslateCode(s, pincode));
        }
        
        static void GenerateSpecial(string str, string pin, int i)
        {
            pinNr = Convert.ToInt32(pin[0].ToString());
            count = special.IndexOf(str[i]);
            if (count + pinNr > special.Length - 1)
            {
                output += special[(count + pinNr) % (special.Length)];
            }
            else
            {
                output += special[count + pinNr];
            }
        }
        
        static void GenerateLetters(string str, string pin, int i)
        {
            pinNr = Convert.ToInt32(pin[1].ToString());
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
            pinNr = Convert.ToInt32(pin[2].ToString());
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
            pinNr = Convert.ToInt32(pin[3].ToString());
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
            pinNr = Convert.ToInt32(pin[0].ToString());
            count = special.IndexOf(str[i]);
            if (count - pinNr < 0)
            {
                output += special[(special.Length) + (count - pinNr)];
            }
            else
            {
                output += special[count - pinNr];
            }
        }

        static void DecryptLetters(string str, string pin, int i)
        {
            pinNr = Convert.ToInt32(pin[1].ToString());
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
            pinNr = Convert.ToInt32(pin[2].ToString());
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
            pinNr = Convert.ToInt32(pin[3].ToString());
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
