using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypteringsprogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.WriteLine("1. Generer kode\n2. Oversæt kode\n\nIndtast valg ");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Console.WriteLine("Indtast sætning: ");
                    string s = Console.ReadLine();
                    //TODO Pincode
                    Console.WriteLine(GenerateCode(s));
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.WriteLine("Indtast sætning: ");
                    //TODO Pincode
                    s = Console.ReadLine();
                    Console.WriteLine(TranslateCode(s));
                    break;
                default:
                    break;
            }
        }    

        static string GenerateCode(string str)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string special = "!\"@#£¤$%&/{([)]=}?+´`|¨^~'*-_.:,; ";
            string output = "";
            int count = 0;
            
            //TODO split into methos
            //TODO create pincode
            for(int i = 0; i < str.Length; i++)
            {
                if (special.Contains(str[i]))
                {
                    count = special.IndexOf(str[i]);
                    if (count + 2 > special.Length - 1)
                    {
                        output += special[(count + 2) - special.Length];
                    }
                    else
                    {
                        output += special[count + 2];
                    }
                }
                else if (letters.Contains(str[i]))
                {
                    count = letters.IndexOf(str[i]);
                    if(count + 3 > letters.Length-1)
                    {
                        output += letters[(count + 3) - letters.Length];
                    }
                    else
                    {
                        output += letters[count + 3];
                    }
                }
                else if (capLetters.Contains(str[i]))
                {
                    count = capLetters.IndexOf(str[i]);
                    if (count + 4 > capLetters.Length - 1)
                    {
                        output += capLetters[(count + 4) - capLetters.Length];
                    }
                    else
                    {
                        output += capLetters[count + 4];
                    }
                }
                else
                {
                    count = numbers.IndexOf(str[i]);
                    if (count + 6 > numbers.Length - 1)
                    {
                        output += numbers[(count + 6) - numbers.Length];
                    }
                    else
                    {
                        output += numbers[count + 6];
                    }
                }
            }
            return output;
        }

        static string TranslateCode(string str)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string special = "!\"@#£¤$%&/{([)]=}?+´`|¨^~'*-_.:,; ";
            string output = "";
            int count = 0;

            //TODO split into methos
            //TODO create pincode reader
            for (int i = 0; i < str.Length; i++)
            {
                if (special.Contains(str[i]))
                {
                    count = special.IndexOf(str[i]);
                    if (count - 2 < 0)
                    {
                        output += special[special.Length - (count - 2)];
                    }
                    else
                    {
                        output += special[count - 2];
                    }
                }
                else if (letters.Contains(str[i]))
                {
                    count = letters.IndexOf(str[i]);
                    if (count - 3 < 0)
                    {
                        output += letters[letters.Length + (count - 3)];
                    }
                    else
                    {
                        output += letters[count - 3];
                    }
                }
                else if (capLetters.Contains(str[i]))
                {
                    count = capLetters.IndexOf(str[i]);
                    if (count - 4 < 0)
                    {
                        output += capLetters[capLetters.Length + (count - 4)];
                    }
                    else
                    {
                        output += capLetters[count - 4];
                    }
                }
                else
                {
                    count = numbers.IndexOf(str[i]);
                    if (count - 6 < 0)
                    {
                        output += numbers[numbers.Length + (count - 6)];
                    }
                    else
                    {
                        output += numbers[count - 6];
                    }
                }
            }
            return output;
        }
    }
}
