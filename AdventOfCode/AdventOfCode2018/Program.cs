using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Day6Solution day6pt1 = new Day6Solution();
            var contentDay6 = File.ReadAllLines("inputs/day6.txt").ToList();
            Console.WriteLine("Day 6 pt1 answer: {0}", day6pt1.GetSolutionPt1(contentDay6));

            Console.ReadLine();            

            Day5Solution day5pt2 = new Day5Solution();
            var contentDay5pt2 = File.ReadAllText("inputs/day5.txt");
            Console.WriteLine("Day 5 pt2 answer: {0}", day5pt2.getPt2Answer(contentDay5pt2));

            Day5Solution day5 = new Day5Solution();
            var contentDay5 = File.ReadAllText("inputs/day5.txt");
            Console.WriteLine("Day 5 answer: {0}", day5.getPt1Answer(contentDay5));
            
            Day4Solution day4 = new Day4Solution();
            var contentDay4 = File.ReadAllLines("inputs/day4.txt");
            Console.WriteLine("Day4 part 1:");
            day4.GetSolutionPart1(contentDay4);
            
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
