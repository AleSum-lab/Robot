using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleaner
{
    public class SegmentFactory
    {
        public Point CurrentStart { get; set; }
        public Point CurrentEnd { get; set; }


        public Segment CreateNextSegment(string input, int currentX, int currentY, int previous)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(nameof(input));

            string[] command = input.Split(" ");
            int distance = Convert.ToInt32(command[1]);
            CurrentStart = new Point();
            CurrentEnd = new Point();
            Segment.Position layout = Segment.Position.Horizontal;

            switch (command[0])
            {
                case "N":
                    CurrentStart.X = CurrentEnd.X = currentX;
                    CurrentStart.Y = currentY + previous;
                    CurrentEnd.Y = currentY + distance;
                    layout = Segment.Position.Vertical;
                    break;
                case "S":
                    CurrentStart.X = CurrentEnd.X = currentX;
                    CurrentStart.Y = currentY - previous;
                    CurrentEnd.Y = currentY - distance;
                    layout = Segment.Position.Vertical;
                    break;
                case "E":
                    CurrentStart.Y = CurrentEnd.Y = currentY;
                    CurrentStart.X = currentX + previous;
                    CurrentEnd.X = currentX + distance;
                    layout = Segment.Position.Horizontal;
                    break;
                case "W":
                    CurrentStart.Y = CurrentEnd.Y = currentY;
                    CurrentStart.X = currentX - previous;
                    CurrentEnd.X = currentX - distance;
                    layout = Segment.Position.Horizontal;
                    break;
                default:
                    break;
            }

            Segment segment = new Segment(CurrentStart, CurrentEnd, layout);
            segment.Minimum.Segment = segment;
            segment.Maximum.Segment = segment;

            return segment;
        }
    }
}
