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
            Console.WriteLine(CalculatePolymer()); 
            
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

            //Part 2
            char[] distinctArray = inputArray.Distinct().ToArray();
            string[] stringArray = distinctArray.Select(x => x.ToString()).ToArray();
            string[] distinctStringArray = stringArray.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
            int latestPolymerCount = 0;
            int lowestPolymerCount = 0;
            string lowestString = null;
            foreach (string s in distinctStringArray)
            {
                Console.WriteLine("Calculating Polymer without the unit type: {0}", s);
                char c = char.Parse(s);
                foreach (Unit u in UnitList)
                {
                    if(char.ToUpper(u.Char) == char.ToUpper(c))
                    {
                        u.Valid = false;
                    }
                    else
                    {
                        u.Valid = true;
                    }
                }
                UpdateValidUnits();
                latestPolymerCount = CalculatePolymer();
                if (lowestPolymerCount == 0 || lowestPolymerCount > latestPolymerCount)
                {
                    lowestPolymerCount = latestPolymerCount;
                    lowestString = s;
                }
                

            }
            Console.WriteLine("Polymer count: {0} Achived by removing unit type: {1}", lowestPolymerCount, lowestString);
            Console.ReadKey();
        }

    }

    
}
