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

            //To hold points that have areas which are infinite
            List<point> DiscardList = new List<point>(); 

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

                        //If this is a point outside the largest box in any direction, it must be an infinite area. Add owner to discard list
                        if (y == LargestArea.bottomLeft.Y-1 || y == LargestArea.topRight.Y+1 || x == LargestArea.bottomLeft.X-1 || x == LargestArea.bottomLeft.X+1)
                        {
                            if (!DiscardList.Any(p => p.X == thisLocation.X && p.Y == thisLocation.Y))
                            {
                                DiscardList.Add(owner);
                            }
                        }
                    }                    
                }
            }
            
            //For each point *not* in the discard list, count total spaces owned
            int MaxOwned = 0;
            foreach (point StartingLocation in StartingPoints.Where(p => !DiscardList.Any(d => d.X == p.X && d.Y == p.Y)))
            {
                int theNumOwnedByThisPoints = GridRefAndOwner.Where(p => p.Value.HasValue && p.Value.Value.X == StartingLocation.X && p.Value.Value.Y == StartingLocation.Y).Count();
                if (theNumOwnedByThisPoints > MaxOwned)
                {
                    MaxOwned = theNumOwnedByThisPoints;
                }
            }

            return MaxOwned;
        }

        public int GetSolutionPt2(List<string> fileInput)
        {
            //Find all startPoints             
            List<point> StartingPoints = new List<point>();
            foreach (var inputRow in fileInput)
            {
                StartingPoints.Add(parseInputLine(inputRow));
            }            
            
            box LargestArea = GetLargestArea(fileInput);

            //To hold points that have areas which are infinite
            List<point> DiscardList = new List<point>(); 

            int TotalAreaCloserthan10k = 0;
            //Iterate over all X - add one to top and bottom for infinite areas in X plane
            for (int x = LargestArea.bottomLeft.X; x <= LargestArea.topRight.X; x++)
            {
                //Iterate over all Y - add one to top and bottom for infinite areas Y plane
                for (int y = LargestArea.bottomLeft.Y; y <= LargestArea.topRight.Y; y++)
                {
                    point thisLocation = new point() {X=x, Y=y};                    
                    int TotalDistanceToAllPoints = 0;
                    foreach (point StartingPoint in StartingPoints)
                    {
                        TotalDistanceToAllPoints += getDistanceBetweenPoints(thisLocation, StartingPoint);
                    }
                    if (TotalDistanceToAllPoints < 10000)
                    {
                        TotalAreaCloserthan10k++;
                    }
                }
            }

            return TotalAreaCloserthan10k;
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