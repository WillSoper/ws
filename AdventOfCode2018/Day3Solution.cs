using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCodeShared;

namespace AdventOfCode2018
{
    internal class Day3Solution
    {
        public string GetSolutionPart1(IEnumerable<string> fileInput)
        {
            //My answer was 119551
            
            Dictionary<int, List<int>> positionsUsed = new Dictionary<int, List<int>>();
            //  Dict<int = X coord,  <List<X coords> >

            Dictionary<int, List<int>> positionsDuplicated = new Dictionary<int, List<int>>();            

            foreach (var fileLine in fileInput)
            {
                //Parse raw text for this row in to x,y and lengths
                Coords lineAsCoords = parseRecord(fileLine);
                
                for (int x = lineAsCoords.startX; x < lineAsCoords.startX + lineAsCoords.lengthX; x++)
                {
                    if (!positionsUsed.ContainsKey(x))
                    {
                        positionsUsed.Add(x, new List<int>());
                    }
                    for (int y = lineAsCoords.startY; y < lineAsCoords.startY + lineAsCoords.lengthY; y++)
                    {
                        if(!positionsUsed[x].Contains(y))
                        {
                            positionsUsed[x].Add(y);
                        }
                        else
                        {
                            if (positionsDuplicated.TryAdd(x, new List<int>()))
                            {
                                positionsDuplicated[x].Add(y);
                            }
                            else if (!positionsDuplicated[x].Contains(y))
                            {
                                positionsDuplicated[x].Add(y);
                            }
                        }
                    }
                }

                //file row finished                
            }
                       
            int totalDupes = 0;
            foreach (var item in positionsDuplicated)
            {
                totalDupes += item.Value.Count();
            }
            Console.WriteLine("Total duplicate points {0}", totalDupes);


            //SOLUTION PART 2
            //Now re-parse the file lines, and check each one against the found duplicates
            foreach (var fileLine in fileInput)
            {
                //Parse raw text for this row in to x,y and lengths
                Coords lineAsCoords = parseRecord(fileLine);
                bool anyDupesForThis= false;

                for (int x = lineAsCoords.startX; x < lineAsCoords.startX + lineAsCoords.lengthX; x++)
                {
                    for (int y = lineAsCoords.startY; y < lineAsCoords.startY + lineAsCoords.lengthY; y++)
                    {
                        if (positionsDuplicated.ContainsKey(x))
                        {
                            if (positionsDuplicated[x].Contains(y))
                            {
                                anyDupesForThis = true;
                                break;
                            }
                        }
                    }
                }

                if (!anyDupesForThis)
                {
                    Console.WriteLine("Founds one {0}", fileLine);
                }
            }
            
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
                startX = int.Parse(theMatches[0].Groups[1].Value)+1,   //Plus 1 because file specifies an offset, not a start position
                startY = int.Parse(theMatches[0].Groups[2].Value)+1,   // "      "       "
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