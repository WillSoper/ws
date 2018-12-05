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
           
            var inputArray = input.ToArray();
            //Array.Sort(inputArray, StringComparer.InvariantCulture);
            //We don't need to sort - I think there's another way to do this using that though.

            string compareOuter = string.Empty;
            string compareTo = string.Empty;

            List<string> matchingLetters = new List<string>();

            //Outer counter goes through whole list starting at 0
            for (int outerCounter = 0; outerCounter < inputArray.Length; outerCounter++)
            {                        
                compareOuter = inputArray[outerCounter];
                var compareOuterArr = compareOuter.ToCharArray();

                //Inner counter goes through whole list starting from outer +1 (prev ones already compared)
                for (int innerCounter = outerCounter; innerCounter < (inputArray.Length)-outerCounter; innerCounter++)
                {
                    compareTo = inputArray[innerCounter];
                    var compareToArr = compareTo.ToCharArray();

                    int numLettersDifferent = 0;
                    for (int c = 0; c < compareToArr.Length; c++)
                    {
                         if (compareToArr[c] == compareOuterArr[c])
                         {
                            //if letters are same, add to list
                             matchingLetters.Add(compareOuterArr[c].ToString());
                         }
                         else
                         {
                            //if letters not same, increment diff counter
                             numLettersDifferent++;
                         }

                        //and if differences >1 break - remember to clear list of same letters
                        if (numLettersDifferent > 1)
                        {
                            matchingLetters.Clear();
                            break;
                        }
                    }
                    //If we get here with only one difference, we found the right one, break.
                    if (numLettersDifferent == 1)
                    {
                        Console.WriteLine("Solution found.");
                        foreach (var item in matchingLetters)
                        {
                            Console.Write(item);
                        }
                        Console.WriteLine();
                    }    
                }
            }
            
            //Then, remove the different chars, and the answer is the shared chars
            return "Day 2 pt 2 done";
        }
    }
}