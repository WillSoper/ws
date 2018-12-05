using System;
using System.IO;
using AdventOfCodeShared;

namespace AdventOfCode2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var Day1pt1input = File.ReadAllLines("inputs/day1pt1.txt");
            Console.WriteLine("Day1pt1:");
            Console.WriteLine(Day1.GetSolutionPart1(Day1pt1input));

            Console.WriteLine("Day1pt2:");
            Console.WriteLine(Day1.GetSolutionPart2(Day1pt1input));
            Console.WriteLine();
        }
    }
}
