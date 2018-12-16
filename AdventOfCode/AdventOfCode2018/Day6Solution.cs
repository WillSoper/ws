using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day6Solution
    {

        public int getDistanceBetweenPoints(point PointFrom, point PointTo)
        {
            int xDist = totalDistanceBetweenTwoInts(PointFrom.X, PointTo.X);
            int yDist = totalDistanceBetweenTwoInts(PointFrom.Y, PointTo.Y);

            return xDist + yDist;
        }

        private int totalDistanceBetweenTwoInts(int from, int to)
        {
            return Math.Abs(from < to ? from - to : to - from);
        }

        public point parseInputLine(string inputString)
        {
            var tmp = inputString.Split(",");
            return new point(){X = int.Parse(tmp[0]), Y = int.Parse(tmp[1])};
        }
    }
    public struct point
    {
        public int X;
        public int Y;
    }

    public struct box
    {
        public point bottomLeft;
        public point topRight;
    }
}