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
            Unit uBefore = new Unit();
            int i = 0;
            bool invalid = false;
            bool keepGoing = true;

            UpdateValidUnits();
            while (keepGoing)
            {
                i = 0;
                invalid = false;
                Console.WriteLine(ValidUnits.Count());
                foreach (Unit u in ValidUnits)
                {
                    
                    if (i > 0)
                    {
                        if (u.Char != uBefore.Char && char.ToUpperInvariant(u.Char) == char.ToUpperInvariant(uBefore.Char))
                        {
                            uBefore.Valid = false;
                            u.Valid = false;
                            invalid = true;
                            break;
                        }
                    }
                    uBefore = u;
                    i++;
                }
                if(invalid)
                {
                    UpdateValidUnits();
                }
                else
                {
                    keepGoing = false;
                }
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


            Console.ReadKey();
        }

    }

    
}
