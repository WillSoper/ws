using System;
using System.Collections.Generic;
using AdventOfCodeShared;

namespace AdventOfCode2018
{
    internal class Day1Solution
    {
        public string GetSolutionPart1(IEnumerable<string> input)
        {
            //My correct answer was 500
            var fh = new FileHandlers();
            int result = 0;
            foreach (int thisNum in fh.ConvertInputToInts(input))
            {
                result += thisNum;
            }
            return result.ToString();
        }

        public string GetSolutionPart2(IEnumerable<string> input)
        {
            //My correct answer was 709
            var fh = new FileHandlers();
            int result = 0;
            int rowNum = 0;
            Dictionary<int,int> numberReachedandLineNumber = new Dictionary<int, int>();
            numberReachedandLineNumber.Add(result, rowNum); //handle starting at zero


            //Need to loop through this indefinitely, until repeated value found
            while(true)
            {
                foreach (int thisNum in fh.ConvertInputToInts(input))
                {
                    result+=thisNum;
                    rowNum++;
                    if (numberReachedandLineNumber.ContainsKey(result))
                    {
                        Console.WriteLine("Reached {0} at line number {1}", result, rowNum);
                        return result.ToString();
                    }   
                    else
                    {
                        numberReachedandLineNumber.Add(result,rowNum);
                    }
                } 
            }
        }

        
    }
}