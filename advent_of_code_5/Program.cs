using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_5
{
    class Program
    {
        public static List<Unit> UnitList;
        static void Main(string[] args)
        {
            var inputPath = @"../../../input.txt";
            string inputString = File.ReadAllText(inputPath);
            char[] inputArray = inputString.ToCharArray();
            
            List<Unit> UnitList = new List<Unit>();
            foreach (char c in inputArray)
            {
                Unit unit = new Unit
                {
                    Char = c,
                    Valid = true
                };
                UnitList.Add(unit);
            }
            Console.ReadKey();
        }

    }

    
}
