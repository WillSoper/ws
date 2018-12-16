using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day5Solution
    {
        public string getPt1AnswerString(string exampleInput)
        {
            List<char> stringAsChar = exampleInput.ToCharArray().ToList();

            bool noneRemoved = false;
            while (!noneRemoved)
            {
                noneRemoved = true;
                        //Start from 1 not 0, as we always want to compare -1 anyway
                for (int i = 1; i < stringAsChar.Count(); i++)
                {
                    //check last vs this and if same ignoring case, but different not ignoring
                    if ((stringAsChar[i] != stringAsChar[i-1]) && (char.ToUpperInvariant(stringAsChar[i]) == char.ToUpperInvariant(stringAsChar[i-1])))
                    {                                                        
                        //Remove this pair
                        stringAsChar.RemoveAt(i-1);
                        stringAsChar.RemoveAt(i-1);

                        //Make sure we scan again (logically, should need to if we go back one? Check)
                        noneRemoved = false;
                        //Skip back one to check whether that caused another reaction
                        i = i-2;
                        if (i <0 )
                        {
                            i = 0;
                        }
                    }                  
                }
            }
            
            return string.Join("", stringAsChar);
        }

        private string removeAllOfThisType(string puzzleInput, char typeToRemove)
        {
            List<char> stringAsChar = puzzleInput.ToCharArray().ToList();
            for (int i = 0; i < stringAsChar.Count; i++)
            {
                if (char.ToUpperInvariant(typeToRemove) == char.ToUpperInvariant(stringAsChar[i]))
                {
                    stringAsChar.RemoveAt(i);
                    i--;
                }
            }
            return string.Join("", stringAsChar);
        }

        public List<char> getAllCharsInFile(string puzzleInput)
        {
            List<char> stringAsChar = puzzleInput.ToCharArray().ToList();
            SortedSet<char> allChars = new SortedSet<char>();
            foreach (var thisChar in stringAsChar)
            {
                allChars.Add(char.ToUpperInvariant(thisChar));
            }
            return allChars.ToList();
        }

        public int getPt2Answer(string puzzleInput)
        {
             //Find Upper variant of all chars in this input
            List<char> allCharFoundInFine = getAllCharsInFile(puzzleInput);

            //Store count of fully reacted output for each, after removing all
            Dictionary<char, int> charAndFullyReactedLength = new Dictionary<char, int>();
            foreach (var thisChar in allCharFoundInFine)
            {
                string removed = removeAllOfThisType(puzzleInput, thisChar);
                charAndFullyReactedLength.Add(thisChar, getPt1Answer(removed));
            }

            //Return the fully reacted 
            return charAndFullyReactedLength.Where(d => d.Value == charAndFullyReactedLength.Values.Min()).SingleOrDefault().Value;
        }



        public int getPt1Answer(string puzzleInput)
        {
            return getPt1AnswerString(puzzleInput).Length;
        }
    }
}