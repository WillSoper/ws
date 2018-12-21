using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day7Solution
    {
        public Tuple<char, char> parseInputLine(string inputString)
        {
            //  0   1  2   3   4        5      6   7  8   9
            //"Step C must be finished before step A can begin."
            var splitString = inputString.Split(" ");
            return new Tuple<char, char>(Char.Parse(splitString[1]), Char.Parse(splitString[7]));
        }
    }
}