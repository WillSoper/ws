using System;
using System.Collections.Generic;
using AdventOfCodeShared;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day1
    {
        internal static string GetSolutionPart1(IEnumerable<String> input)
        {            
            foreach (var item in input)
            {
                int Sum =0;
                //FOREACH Not really needed, as real solution has only one line

                //Add the first item to the end, so we can pretend it's really circular
                var arr = item.ToCharArray().Append(item.ToCharArray().First());
                char PrevChar = '@';
                foreach (var ThisChr in arr)
                {
                    if (PrevChar == ThisChr)
                    {
                        Sum += int.Parse(ThisChr.ToString());
                        PrevChar = ThisChr;
                    }
                    else
                    {
                        PrevChar = ThisChr;
                    }
                }
                Console.WriteLine(Sum.ToString());
            } 
            
            return "Done";
        }

        internal static string GetSolutionPart2(IEnumerable<String> input)
        {
            // Rather than foreach, use a for and access the array by num
            // Then - if  arr[this] == arr[this+1]  - add  (this is above solution)

            foreach (var item in input)
            {
                //double the array, so it's all there again - we pretend it's circular, which 
                // holds while we're looking 50% of the way forward
                List<int> tmp = new List<int>();
                tmp.AddRange(item.Select(x => int.Parse(x.ToString())).ToArray());
                tmp.AddRange(item.Select(x => int.Parse(x.ToString())).ToArray());
                for (int i = 0; i < tmp.Count/2 ; i++) //div by 2 - Make sure that we're not more than half way through, otherwise IndexOutOfRange
                {
                    // if (tmp[i])
                    // {
                        
                    // }
                }

                // if[arrthis] == arr[this+halfArrLength]
                  
            }
            return "Done";
        }
    }
}