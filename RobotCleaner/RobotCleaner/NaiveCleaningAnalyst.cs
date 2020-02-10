using System;
using System.Collections.Generic;
using System.Text;
using static RobotCleaner.Segment;

namespace RobotCleaner
{
    // Use this class to compare performance of the naive and smart algorithms
    public class NaiveCleaningAnalyst
    {
        private List<Segment> _path;
        private int _counter;

        public NaiveCleaningAnalyst(List<Segment> path)
        {
            _path = path;
        }

        public int Report()
        {
            int pathLength = _path.Count;

            for (int i = 0; i < pathLength; i++)
            {
                _counter += _path[i].Length;

                for (int j = 0; j < pathLength; j++)
                {
                    if (i == j) continue;

                    _counter -= CheckIntersection(_path[i], _path[j]);
                }
            }

            return _counter;
        }


        public int CheckIntersection(Segment current, Segment next)
        {
            if (current.Equals(next)) return current.Length;

            if (current.Layout == Position.Horizontal &&
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
