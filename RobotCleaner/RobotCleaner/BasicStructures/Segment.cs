using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RobotCleaner
{
    public class Segment : IComparable<Segment>
    {
        public int Length { get; set; }
        public Point Minimum { get; set; }
        public Point Maximum { get; set; }
        public Position Layout { get; set; }

        public Segment(Point a, Point b, Position layout)
        {
            Layout = layout;
            if (a.X == b.X)
            {
                if (b.Y > a.Y)
                {
                    Length = b.Y - a.Y + 1;
                    Minimum = a;
                    Maximum = b;
                }
                else
                {
                    Length = a.Y - b.Y + 1;
                    Minimum = b;
                    Maximum = a;
                }
            }
            else if(a.Y == b.Y)
            {
                if (b.X > a.X)
                {
                    Length = b.X - a.X + 1;
                    Minimum = a;
                    Maximum = b;
                }
                else
                {
                    Length = a.X - b.X + 1;
                    Minimum = b;
                    Maximum = a;
                }
            }
            Minimum.End = SegmentEnd.Left;
            Maximum.End = SegmentEnd.Right;
        }


        public override bool Equals(object obj)
        {
            var item = obj as Segment;

            if (item == null) return false;

            if (Minimum.X.Equals(item.Minimum.X) && 
                Minimum.Y.Equals(item.Minimum.Y) && 
                Maximum.X.Equals(item.Maximum.X) &&
                Maximum.Y.Equals(item.Maximum.Y)) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo([AllowNull] Segment other)
        {
            int result = 0;

            if (other == null) throw new ArgumentNullException(nameof(other));

            if(Layout == other.Layout)
            {
                if(Layout == Position.Vertical)
                {
                    if (Minimum.Y < other.Minimum.Y)
                    {
                        result = -1;
                    }
                    else if (Minimum.Y > other.Minimum.Y)
                    {
                        result = 1;
                    }
                    else if (Minimum.Y == other.Minimum.Y)
                    {
                        if (Maximum.Y < other.Maximum.Y)
                        {
                            result = -1;
                        }
                        else if(Maximum.Y > other.Maximum.Y)
                        {
                            result = 1;
                        }
                    }
                }
                else
                {
                    if (Minimum.X < other.Minimum.X)
                    {
                        result = -1;
                    }
                    else if (Minimum.X > other.Minimum.X)
                    {
                        result = 1;
                    }
                    else if (Minimum.X == other.Minimum.X)
                    {
                        if (Maximum.X < other.Maximum.X)
                        {
                            result = -1;
                        }
                        else if (Maximum.X > other.Maximum.X)
                        {
                            result = 1;
                        }
                    }
                }
            }
            else
            {
                if (Minimum.Y < other.Minimum.Y)
                {
                    result = -1;
                }
                else if (Minimum.Y > other.Minimum.Y)
                {
                    result = 1;
                }
                else if(Minimum.Y == other.Minimum.Y)
                {
                    if (Maximum.Y > other.Maximum.Y)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                }
            }
            return result;
        }

        public enum Position
        {
            Horizontal,
            Vertical
        }

    }
}
