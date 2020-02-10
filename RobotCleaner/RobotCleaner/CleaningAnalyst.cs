using RobotCleaner.BasicStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static RobotCleaner.Segment;

namespace RobotCleaner
{
    public class CleaningAnalyst
    {
        private SortedSet<Segment> _path;
        private MinHeap<Point> _points;
        private int _counter;

        public CleaningAnalyst(SortedSet<Segment> path, MinHeap<Point> points)
        {
            _path = path;
            _points = points;
        }

        public int Report()
        {           
            SortedSet<Segment> activeTree = new SortedSet<Segment>();
            int pointCount = _points.GetSize();

            // Sweep Line
            for (int i = 0; i < pointCount; i++)
            {
                Point currentPoint = _points.PopMin();
                if (currentPoint.End == SegmentEnd.Left)
                {
                    Segment currentSegment = currentPoint.Segment;

                    foreach (Segment item in activeTree)
                    {
                        _counter -= CheckIntersection(currentSegment, item);
                    }

                    activeTree.Add(currentSegment);
                    
                    _counter += currentSegment.Length;
                   
                }
                else if(currentPoint.End == SegmentEnd.Right)
                {
                    Segment currentSegment = currentPoint.Segment;
                    
                    activeTree.Remove(currentSegment);
                }
            }
            return _counter;
        }


        public int CheckIntersection(Segment current, Segment next)
        {
            if (current.Equals(next)) return current.Length;

            if(current.Layout == Position.Horizontal &&
                next.Layout == Position.Horizontal)
            {
                if (current.Minimum.Y != next.Minimum.Y)
                {
                    return 0;
                }
                else
                {
                    int minX = Math.Max(current.Minimum.X, next.Minimum.X);
                    int maxX = Math.Min(current.Maximum.X, next.Maximum.X);

                    return minX <= maxX ? maxX - minX + 1 : 0;
                }
            }
            else if (current.Layout == Position.Vertical &&
                next.Layout == Position.Vertical)
            {
                if (current.Minimum.X != next.Minimum.X)
                {
                    return 0;
                }
                else
                {
                    int minY = Math.Max(current.Minimum.Y, next.Minimum.Y);
                    int maxY = Math.Min(current.Maximum.Y, next.Maximum.Y);

                    return minY <= maxY ? maxY - minY + 1 : 0;
                }
            }
            else
            {
                Point minCross = new Point(Math.Max(current.Minimum.X, next.Minimum.X), Math.Max(current.Minimum.Y, next.Minimum.Y));
                Point maxCross = new Point(Math.Min(current.Maximum.X, next.Maximum.X), Math.Min(current.Maximum.Y, next.Maximum.Y));

                bool intersect = (minCross.X <= maxCross.X) && (minCross.Y <= maxCross.Y);

                return intersect ? 1 : 0;
            }
        }

    }
}
