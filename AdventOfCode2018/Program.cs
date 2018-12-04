using System;
using System.IO;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Day3Solution day3 = new Day3Solution();
            var contentDay3 = File.ReadAllLines("inputs/day3.txt");
            Console.WriteLine("Day3 part 1:");
            Console.WriteLine(day3.GetSolutionPart1(contentDay3));
            
            
            Day1Solution day1 = new Day1Solution();
            var contentPart1 = File.ReadLines("inputs/day1.txt");
            Console.WriteLine("Solution part 1:");
            Console.WriteLine(day1.GetSolutionPart1(contentPart1));
            Console.WriteLine();

            var contentPart2 = File.ReadLines("inputs/day1pt2.txt");
            Console.WriteLine("Solution part 2:");
            Console.WriteLine(day1.GetSolutionPart2(contentPart2));
            Console.WriteLine();

            Day2Solution day2 = new Day2Solution();
            var contentDay2 = File.ReadAllLines("inputs/day2.txt");
            Console.WriteLine("Day 2 part 1:");
            Console.WriteLine(day2.GetSolutionPart1(contentDay2));

            Console.WriteLine("Day 2 part 2:");
            Console.WriteLine(day2.GetSolutionPart2(contentDay2));

        }
    }
}
