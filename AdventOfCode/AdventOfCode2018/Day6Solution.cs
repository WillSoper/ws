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

        public box GetLargestArea(List<string> testInput)
        {
            //Parse all start points, take min and max X & Y, draw a box
            // (Should return 2 points, bottom left, top right)
            point minXY = new point() {X=int.MaxValue, Y=int.MaxValue};
            point maxXY = new point() {X=int.MinValue, Y=int.MinValue};

            foreach (var row in testInput)
            {
                point thisRow = parseInputLine(row);
                if(minXY.X > thisRow.X) minXY.X = thisRow.X;
                if(minXY.Y > thisRow.Y) minXY.Y = thisRow.Y;
                if(maxXY.X < thisRow.X) maxXY.X = thisRow.X;
                if(maxXY.Y < thisRow.Y) maxXY.Y = thisRow.Y;
            }

            return new box(){bottomLeft = minXY, topRight = maxXY};
        }

        public int GetSolutionPt1(List<string> fileInput)
        {
            //To hold our grid and the owner of each reference - NULL if joint owner
            Dictionary<point, Nullable<point>> GridRefAndOwner = new Dictionary<point, Nullable<point>>();

            //Find all startPoints             
            List<point> StartingPoints = new List<point>();
            foreach (var inputRow in fileInput)
            {
                StartingPoints.Add(parseInputLine(inputRow));
            }            
            
            box LargestArea = GetLargestArea(fileInput);

            //Iterate over all X - add one to top and bottom for infinite areas in X plane
            for (int x = LargestArea.bottomLeft.X - 1; x <= LargestArea.topRight.X+1; x++)
            {
                //Iterate over all Y - add one to top and bottom for infinite areas Y plane
                for (int y = LargestArea.bottomLeft.Y - 1; y <= LargestArea.topRight.Y+1; y++)
                {
                    Dictionary<point, int> PossibleOwnerAndDistance = new Dictionary<point, int>();
                    point thisLocation = new point(){X =x, Y=y};

                    foreach (var startPoint in StartingPoints)
                    {
                        PossibleOwnerAndDistance.Add(startPoint, getDistanceBetweenPoints(startPoint, thisLocation));                       
                    }
                    
                    int shortestDistance = PossibleOwnerAndDistance.Values.Min();
                    if (PossibleOwnerAndDistance.Where(p => p.Value == shortestDistance).Count() > 1 )
                    {
                        //owned by many
                        GridRefAndOwner.Add(thisLocation, null);
                    }
                    else
                    {
                        //owned by one
                        var owner = PossibleOwnerAndDistance.Where(p => p.Value == shortestDistance).SingleOrDefault().Key;
                        GridRefAndOwner.Add(thisLocation, owner);
                    }

                    //Add points in the StartingPoints list that show up in the absolute edge to a Discard list
                }
            }
            
            //For each point *not* in the discard list, count total spaces owned

            return 0;
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