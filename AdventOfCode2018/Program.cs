using System;
using System.IO;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            var contentPart1 = File.ReadLines("inputs/day1.txt");
            Day1Solution day1 = new Day1Solution();
            Console.WriteLine("Solution part 1:");
            Console.WriteLine(day1.GetSolutionPart1(contentPart1));
            Console.WriteLine();

            var contentPart2 = File.ReadLines("inputs/day1pt2.txt");
            Console.WriteLine("Solution part 2:");
            Console.WriteLine(day1.GetSolutionPart2(contentPart2));
            Console.WriteLine();
        }
    }
}
