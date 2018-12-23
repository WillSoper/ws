using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

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

        public Dictionary<char, HashSet<char>> buildGraph(IEnumerable<string> inputFile)
        {
            Dictionary<char, HashSet<char>> retval =  new Dictionary<char, HashSet<char>>();
            foreach (var line in inputFile)
            {
                Tuple<char,char> Dependency = parseInputLine(line);
                //Make sure we add ones that don't have a dependency
                retval.TryAdd(Dependency.Item1, new HashSet<char>());

                if(!retval.TryAdd(Dependency.Item2, new HashSet<char>(){Dependency.Item1}))
                {
                    retval[Dependency.Item2].Add(Dependency.Item1);
                }
            }
            return retval;
        }

        public string getSolutionPt1(IEnumerable<string> inputFile)
        {
            var Dependencies = buildGraph(inputFile);
            StringBuilder sb = new StringBuilder();

            while (Dependencies.Count > 0)
            {
                //Find chars with no dependencies left
                var charsWithNoDependencies = Dependencies.Where(d => d.Value.Count == 0);
                
                //Find the minimum char if more than one
                char minChar = char.MaxValue;
                foreach (var thisChar in charsWithNoDependencies)
                {
                    if(thisChar.Key < minChar)
                    { 
                        minChar = thisChar.Key;
                    }
                }

                //Add this char to the return string
                sb.Append(minChar);

                //Remove this char from dictionary
                Dependencies.Remove(minChar);

                //And from all dependencies
                foreach (var item in Dependencies)
                {
                    item.Value.Remove(minChar);
                }

            }

            return sb.ToString();
        }
    }
}