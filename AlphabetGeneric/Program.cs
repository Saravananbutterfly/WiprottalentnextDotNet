using System;
using System.Collections.Generic;
using System.Linq;
namespace AlphabetGeneric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.Write("Enter a string with alphabets and digits: ");
                string input = Console.ReadLine();

                List<char> AlphaList = new List<char>();
                List<char> DigitList = new List<char>();

                foreach (char ch in input)
                {
                    if (char.IsLetter(ch))
                        AlphaList.Add(ch);
                    else if (char.IsDigit(ch))
                        DigitList.Add(ch);
                }

                AlphaList.Sort();
                DigitList.Sort();

                Console.WriteLine("Sorted Alphabets: " + string.Join("", AlphaList));
                Console.WriteLine("Sorted Digits: " + string.Join("", DigitList));
            }
        }
    }
}