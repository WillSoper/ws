using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day12Solution
    {
        public Dictionary<int, bool> parseRow(string initialState)
        {
            Dictionary<int, bool> retVal = new Dictionary<int, bool>();
            
            for (int i = 0; i < initialState.Length; i++)
            {
                retVal.Add(i, initialState[i] == '#');
            }

            return retVal;
        }
    }
}