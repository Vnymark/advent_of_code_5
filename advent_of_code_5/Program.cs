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
                    Char = c,
                    Valid = true
                };
                UnitList.Add(unit);
            }

            //Calculate Polymer
            List<Unit> ValidUnits = new List<Unit>();
            UpdateValidUnits();
            Console.WriteLine("Original Polymer lenght: {0}", UnitList.Count());
            Console.WriteLine("Original Polymer lenght after reacting: {0}", CalculatePolymer());
            
            //Calculating the polymer takes about 5 seconds.
            //WIP to speed the calculation up.
            int CalculatePolymer()
            {
                Unit uNow = new Unit();
                Unit uBefore = new Unit();
                int i = 0;
                bool invalid = false;
                bool keepGoing = true;
                while (keepGoing)
                {
                    i = 0;
                    invalid = false;
                    foreach (Unit u in ValidUnits)
                    {
                        if (i > 0)
                        {
                            if (u.Char != uBefore.Char && char.ToUpperInvariant(u.Char) == char.ToUpperInvariant(uBefore.Char))
                            {
                                invalid = true;
                                uNow = u;
                                break;
                            }
                        }
                        uBefore = u;
                        i++;
                    }
                    if (invalid)
                    {
                        ValidUnits.Remove(uBefore);
                        ValidUnits.Remove(uNow);
                    }
                    else
                    {
                        keepGoing = false;
                    }
                }
                return ValidUnits.Count();
            }

            //Function to update which units still exist in the Polymer
            void UpdateValidUnits()
            {
                ValidUnits = new List<Unit>();
                foreach (Unit u in UnitList)
                {
                    if (u.Valid)
                    {
                        ValidUnits.Add(u);
                    }
                }
            }

            //Function to replace ValidUnits with the list the part2 calculation should be using.
            void ReplaceValidUnits(List<Unit> SUnit)
            {
                ValidUnits = new List<Unit>(SUnit);
            }

            //Function to cleanse the polymer from all units with the given char, both lower and uppercase.
            void RemoveUnitsFromPolymer(char c)
            {
                List<Unit> RemainingPolymer = new List<Unit>(UnitList);
                RemainingPolymer.RemoveAll(x => char.ToUpper(x.Char) == c);
                ReplaceValidUnits(RemainingPolymer);
            }

            //Part 2
            List<char> charList = new List<char>();
            int latestPolymerCount = 0;
            int lowestPolymerCount = 0;
            char lowestString = new char();

            //Getting a list of distinctive letters.
            foreach (char c in inputArray.Distinct())
            {
                if(!charList.Contains(char.ToUpper(c))) {
                    charList.Add(char.ToUpper(c));
                }
            }
            Console.WriteLine("Calculating the shortest Polymer from {0} different units takes roughly 2 minutes.", charList.Count());

            //Calculating polymer based on 
            foreach (char c in charList)
            {
                Console.WriteLine("Calculating Polymer without the unit type: {0}", c);
                RemoveUnitsFromPolymer(c);
                latestPolymerCount = CalculatePolymer();

                Console.WriteLine("Polymer lenght without {0}: {1}", c, latestPolymerCount);
                if (lowestPolymerCount == 0 || lowestPolymerCount > latestPolymerCount)
                {
                    lowestPolymerCount = latestPolymerCount;
                    lowestString = c;
                }
            }
            Console.WriteLine("Shortest polymer count: {0} Achived by removing unit type: {1}", lowestPolymerCount, lowestString);
            Console.ReadKey();
        }

    }

    
}
