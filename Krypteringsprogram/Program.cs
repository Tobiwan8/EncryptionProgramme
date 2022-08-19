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
        /*string letters = "abcdefghijklmnopqrstuvwxyz";
        string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        string special = "!\"@#£¤$%&/{([)]=}?+´`|¨^~'*-_.:,; ";*/

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
                    Console.WriteLine("Indtast sætning for kryptering: ");
                    string s = Console.ReadLine();
                    Console.WriteLine("Indtast pinkode: ");
                    string pincode = Console.ReadLine();
                    Console.WriteLine(GenerateCode(s, pincode));
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.WriteLine("Indtast sætning for dekryptering: ");
                    s = Console.ReadLine();
                    Console.WriteLine("Indtast pinkode: ");
                    pincode = Console.ReadLine();
                    Console.WriteLine(TranslateCode(s, pincode));
                    break;
                default:
                    break;
            }
        }    

        static string GenerateCode(string str, string pin)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string special = "!\"@#£¤$%&/{([)]=}?+´`|¨^~'*-_.:,; ";
            string output = "";
            int count = 0;
            int pinNr = 0;
            
            //TODO split into methods
            //TODO create pincode
            for(int i = 0; i < str.Length; i++)
            {
                if (special.Contains(str[i])) //if(GenerateSpecial(str[i], pin[0]))
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
                else if (letters.Contains(str[i])) //else if(GenerateLetters(str[i], pin[1]))
                {
                    pinNr = Convert.ToInt32(pin[1].ToString());
                    count = letters.IndexOf(str[i]);
                    if(count + pinNr > letters.Length-1)
                    {
                        output += letters[(count + pinNr) % (letters.Length)];
                    }
                    else
                    {
                        output += letters[count + pinNr];
                    }
                }
                else if (capLetters.Contains(str[i]))
                {
                    pinNr = Convert.ToInt32(pin[2].ToString());
                    count = capLetters.IndexOf(str[i]);
                    if (count + pinNr > capLetters.Length - 1) //else if(GenerateCapLetters(str[i], pin[2]))
                    {
                        output += capLetters[(count + pinNr) % (capLetters.Length)];
                    }
                    else
                    {
                        output += capLetters[count + pinNr];
                    }
                }
                else
                {
                    pinNr = Convert.ToInt32(pin[3].ToString());
                    count = numbers.IndexOf(str[i]);
                    if (count + pinNr > numbers.Length - 1) //else(GenerateNumbers(str[i], pin[3]))
                    {
                        output += numbers[(count + pinNr) % (numbers.Length)];
                    }
                    else
                    {
                        output += numbers[count + pinNr];
                    }
                }
            }
            return output;
        }

        static string TranslateCode(string str, string pin)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string special = "!\"@#£¤$%&/{([)]=}?+´`|¨^~'*-_.:,; ";
            string output = "";
            int count = 0;
            int pinNr = 0;

            //TODO split into methods
            //TODO create pincode reader
            for (int i = 0; i < str.Length; i++)
            {
                if (special.Contains(str[i]))
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
                else if (letters.Contains(str[i]))
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
                else if (capLetters.Contains(str[i]))
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
                else
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
            return output;
        }

        /*static char GenerateSpecial(char c, char cPin)
        {

        }

        static char GenerateLetters(char c, char cPin)
        {

        }

        static char GenerateCapLetters(char c, char cPin)
        {

        }

        static char GenerateNumbers(char c, char cPin)
        {

        }*/
    }
}
