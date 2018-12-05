using System;
using System.Collections.Generic;

namespace AdventOfCodeShared
{
    public class FileHandlers
    {

        public List<int> ConvertInputToInts(IEnumerable<string> input)
        {
            List<int> retVal = new List<int>();
            int lineNum = 0;
            foreach (var thisLine in input)
            {   
                lineNum++;
                int thisNum;
                if(int.TryParse(thisLine,out thisNum))
                {
                    retVal.Add(thisNum);
                }
                else
                {
                    Console.WriteLine("Error - [{0}] is not an integer. Line {1}",thisLine, lineNum);
                }
            }
            return retVal;
        }
    }
}
