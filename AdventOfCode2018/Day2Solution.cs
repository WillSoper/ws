using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeShared;

namespace AdventOfCode2018
{
    internal class Day2Solution
    {
        public string GetSolutionPart1(IEnumerable<string> input)
        {
            //Key is count of letters in row, value is count of rows with that
            //Dictionary<int,int> numbersAndCounts = new Dictionary<int, int>();
            
//Test data gives 12
// abcdef
// bababc
// abbcde
// abcccd
// aabcdd
// abcdee
// ababab

//My answer was 6200
            int numberOfTwos = 0;
            int numberOfThrees = 0;

            foreach (var testRow in input)
            {
                //Each row in the file is a box
                Dictionary<string, int> lettersAndCounts = new Dictionary<string, int>();
                foreach (var thisChar in testRow.ToCharArray())
                {
                    if (lettersAndCounts.ContainsKey(thisChar.ToString()))
                    {
                        lettersAndCounts[thisChar.ToString()]++;
                    }
                    else
                    {
                        lettersAndCounts.Add(thisChar.ToString(), 1);
                    }
                }

                //Once we've processed that string, find out how many chars appear exactly twice...
                if(lettersAndCounts.AsEnumerable().Where(t => t.Value == 2).Count()>0)
                {
                    numberOfTwos++;
                }
                //...and exactly three times
                if(lettersAndCounts.AsEnumerable().Where(t => t.Value == 3).Count()>0)
                {
                    numberOfThrees++;
                }

                // Console.WriteLine("NumTwos {0}", numberOfTwos.ToString());
                // Console.WriteLine("NumThrees {0}", numberOfThrees.ToString());
            }
            Console.WriteLine("Final Answer {0}", numberOfThrees*numberOfTwos);

            return "Done";
        }

        public string GetSolutionPart2(IEnumerable<string> input)
        {
            //Compare all strings, find those that differ by only 1 char in the same position

            //Then, remove the different chars, and the answer is the shared chars
        }
    }
}