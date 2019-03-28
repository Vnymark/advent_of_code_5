using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace advent_of_code_5
{
    class Polymer
    {
        public List<Unit> OriginalUnits { get; set; }
        public List<Unit> ReactedUnits { get; set; }
        public int LatestPolymerCount { get; set; }
        public int LowestPolymerCount { get; set; }
        public char LatestChar { get; set; }
        public char LowestChar { get; set; }


        //Calculating the polymer takes about 5 seconds.
        //WIP to speed the calculation up.
        public void CalculatePolymer()
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
                foreach (Unit u in ReactedUnits)
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
                    ReactedUnits.Remove(uBefore);
                    ReactedUnits.Remove(uNow);
                }
                else
                {
                    keepGoing = false;
                }
            }

            this.LatestPolymerCount = ReactedUnits.Count();
            if (this.LowestPolymerCount == 0 || this.LatestPolymerCount < this.LowestPolymerCount)
            {
                this.LowestPolymerCount = this.LatestPolymerCount;
                this.LowestChar = this.LatestChar;
            }
            
        }
        
        //Function to cleanse the polymer from all units with the given char, both lower and uppercase.
        public void RemoveUnitsFromPolymer(char c)
        {
            List<Unit> RemainingPolymer = new List<Unit>(this.OriginalUnits);
            RemainingPolymer.RemoveAll(x => char.ToUpper(x.Char) == c);
            this.LatestChar = c;
            this.ReactedUnits = new List<Unit>(RemainingPolymer);
        }

        //Calculating polymer with the removal of distinctive chars
        public void CalculatePolymerDistinctive(List<char> charList)
        {
            foreach (char c in charList)
            {
                Console.WriteLine("Calculating Polymer without the unit type: {0}", c);
                this.RemoveUnitsFromPolymer(c);
                this.CalculatePolymer();
                Console.WriteLine("Polymer lenght without {0}: {1}", c, this.LatestPolymerCount);
            }
        }
            
    }
}
