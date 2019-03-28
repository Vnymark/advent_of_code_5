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
            //Add data
            var inputPath = @"../../../input.txt";
            string inputString = File.ReadAllText(inputPath);
            char[] inputArray = inputString.ToCharArray();
            List<Unit> UnitList = new List<Unit>();

            foreach (char c in inputArray)
            {
                Unit unit = new Unit
                {
                    Char = c
                };
                UnitList.Add(unit);
            }
            
            Polymer poly = new Polymer
            {
                OriginalUnits = new List<Unit>(UnitList),
                ReactedUnits = new List<Unit>(UnitList)
            };

            //Calculate Polymer
            Console.WriteLine("Original Polymer lenght: {0}", UnitList.Count());
            poly.CalculatePolymer();

            //Print result
            Console.WriteLine("Original Polymer lenght after reacting: {0}", poly.LatestPolymerCount);


            //******* Part 2 *******//
            //Getting a list of distinctive chars
            List<char> charList = new List<char>();
            foreach (char c in inputArray.Distinct())
            {
                if(!charList.Contains(char.ToUpper(c))) {
                    charList.Add(char.ToUpper(c));
                }
            }

            //Calculating shortest Polymer
            Console.WriteLine("Calculating the shortest Polymer from {0} different units takes roughly 2 minutes.", charList.Count());
            poly.CalculatePolymerDistinctive(charList);

            //Print result
            Console.WriteLine("Shortest polymer count: {0} Achived by removing unit type: {1}", poly.LowestPolymerCount, poly.LowestChar);
            Console.ReadKey();
        }
    }
}
