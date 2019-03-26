using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = @"../../../input.txt";
            string inputString = File.ReadAllText(inputPath);
            char[] inputArray = inputString.ToCharArray();

            int i = 0;
            int j = i;
            List<char> charList = new List<char>();
            foreach (char c in inputArray)
            {
                
                if (i != 0)
                {
                    j = i - 1;
                }
                if (char.ToUpperInvariant(c) != char.ToUpperInvariant(inputArray[j]))
                {
                    charList.Add(inputArray[i]);
                }
                i++;
            }
            Console.ReadKey();
        }

    }

    
}
