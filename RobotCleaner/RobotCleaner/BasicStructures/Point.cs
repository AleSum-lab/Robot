using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner
{
    public class Point : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SegmentEnd End { get; set; }
        public Segment Segment { get; set; }

        public Point()
        {

        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Point;

            if (item == null) return false;

            if (this.X.Equals(item.X) && this.Y.Equals(item.Y)) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var item = obj as Point;
            int result = 0;

            if (item == null) throw new ArgumentNullException(nameof(item));

            if (X < item.X)
            {
                result = -1;
            }
            else if (X > item.X)
            {
                result = 1;
            }
            else if (X == item.X)
            {
                if(Y < item.Y)
                {
                    result = -1;
                }
                else if(Y > item.Y)
                {
                    result = 1;
                }
            }

            return result;
        }
    }

    public enum SegmentEnd
    {
        Left,
        Right,
        None
    }
}
