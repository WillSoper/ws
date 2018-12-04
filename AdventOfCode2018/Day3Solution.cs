using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCodeShared;

namespace AdventOfCode2018
{
    internal class Day3Solution
    {
        public string GetSolutionPart1(IEnumerable<string> input)
        {
            //
            Dictionary<int, Dictionary<int, int>> positions = new Dictionary<int, Dictionary<int, int>>();
            //  <int = X coord,  <int = y coord, int = count> >
            foreach (var item in input)
            {
                var result = parseRecord(item);
            }
            //Each row - Parse x,y

                //if X row is empty, new
                    //and add Y key =this val = 1 at this posision
                //else
                    //if this Y value is empty, add it as 1
                        //else increment it

            //select where values => value.value > 1

            return "done";
        }

        private Coords parseRecord(string recordToParse)
        {   
            //Sample row:
            // #1 @ 1,3: 4x4
            string matchPattern = @"(\d*)[,](\d*)[:].(\d*)[x](\d*)";
            //Group 1 - x start
            //Group 2 - y start
            //Group 3 - x length
            //Group 4 = y length

            var theMatches = Regex.Matches(recordToParse, matchPattern);
            return new Coords() {
                startX = int.Parse(theMatches[0].Groups[1].Value),
                startY = int.Parse(theMatches[0].Groups[2].Value),
                lengthX = int.Parse(theMatches[0].Groups[3].Value),
                lengthY = int.Parse(theMatches[0].Groups[4].Value)
                };

        }

        struct Coords
        {
            public int startX;
            public int startY;
            public int lengthX;
            public int lengthY;
        }
    }
}