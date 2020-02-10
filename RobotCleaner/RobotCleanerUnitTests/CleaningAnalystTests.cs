using NUnit;
using NUnit.Framework;
using RobotCleaner;
using RobotCleaner.BasicStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RobotCleanerUnitTests
{
    public class CleaningAnalystTests
    {
        private SortedSet<Segment> _set = new SortedSet<Segment>();
        private List<Segment> _list = new List<Segment>();

        [Test]
        public void Report_ForGivenSetOfRandomSegments_ReturnsTotalLength()
        {
            //Arrange
            SortedSet<Segment> set = GeneratePath();
            MinHeap<Point> points = ExtractPoints(set);
            CleaningAnalyst analyst = new CleaningAnalyst(set, points);

            //Act
            int result = analyst.Report();

            Assert.AreEqual(9, result);
        }

        [Test]
        public void Report_AsymptotycPerformanceTest()
        {
            //Arrange
            GenerateData();
            
            MinHeap<Point> points = ExtractPoints(_set);
            CleaningAnalyst analyst = new CleaningAnalyst(_set, points);
            NaiveCleaningAnalyst naiveAnalyst = new NaiveCleaningAnalyst(_list);

            //Act
            Stopwatch watch = Stopwatch.StartNew();
            analyst.Report();
            watch.Stop();
            Console.WriteLine("Smart analyst finished in: " + watch.ElapsedMilliseconds);

            watch.Reset();
            watch.Start();
            naiveAnalyst.Report();
            watch.Stop();
            Console.WriteLine("Naive analyst finished in: " + watch.ElapsedMilliseconds);

        }

        [Test]
        public void CheckIntersection_GivenSegmentsHaveOneIntersection_ReturnsOne()
        {
            //Arrange
            SortedSet<Segment> set = GeneratePath();
            MinHeap<Point> points = ExtractPoints(set);
            CleaningAnalyst analyst = new CleaningAnalyst(set, points);
            Segment a = new Segment(new Point(3, 4), new Point(3, 7), Segment.Position.Vertical);
            Segment b = new Segment(new Point(2, 5), new Point(7, 5), Segment.Position.Horizontal);
            Segment c = new Segment(new Point(3, 1), new Point(3, 4), Segment.Position.Vertical);

            //Act
            int result = analyst.CheckIntersection(a, b);
            int result1 = analyst.CheckIntersection(a, c);

            Assert.AreEqual(1, result);
            Assert.AreEqual(1, result1);
        }

        [Test]
        public void CheckIntersection_GivenSegmentsHaveFourIntersections_ReturnsFour()
        {
            //Arrange
            SortedSet<Segment> set = GeneratePath();
            MinHeap<Point> points = ExtractPoints(set);
            CleaningAnalyst analyst = new CleaningAnalyst(set, points);
            Segment a = new Segment(new Point(3, 4), new Point(3, 7), Segment.Position.Vertical);
            Segment c = new Segment(new Point(3, 1), new Point(3, 7), Segment.Position.Vertical);

            //Act
            int result = analyst.CheckIntersection(a, c);

            Assert.AreEqual(4, result);
        }



        public SortedSet<Segment> GeneratePath()
        {
            SortedSet<Segment> set = new SortedSet<Segment>();

            Point a = new Point(1, 1);
            Point b = new Point(1, 3);
            Segment s1 = new Segment(a, b, Segment.Position.Vertical);
            a.Segment = s1;
            b.Segment = s1;
            set.Add(s1);

            Point c = new Point(2, 3);
            Point d = new Point(3, 3);
            Segment s2 = new Segment(c, d, Segment.Position.Horizontal);
            c.Segment = s2;
            d.Segment = s2;
            set.Add(s2);

            Point e = new Point(3, 2);
            Point f = new Point(3, 2);
            Segment s3 = new Segment(e, f, Segment.Position.Vertical);
            e.Segment = s3;
            f.Segment = s3;
            set.Add(s3);

            Point g = new Point(2, 2);
            Point h = new Point(2, 2);
            Segment s4 = new Segment(g, h, Segment.Position.Horizontal);
            g.Segment = s4;
            h.Segment = s4;
            set.Add(s4);

            Point i = new Point(2, 3);
            Point j = new Point(2, 5);
            Segment s5 = new Segment(i, j, Segment.Position.Vertical);
            i.Segment = s5;
            j.Segment = s5;
            set.Add(s5);

            return set;
        }

        public MinHeap<Point> ExtractPoints(SortedSet<Segment> path)
        {
            MinHeap<Point> points = new MinHeap<Point>();

            foreach(Segment item in path)
            {
                points.Add(item.Minimum);
                points.Add(item.Maximum);
            }

            return points;
        }

        public void GenerateData()
        {
            SortedSet<Segment> set = new SortedSet<Segment>();
            int MAXLIMIT = 100000;
            int MINLIMIT = -100000;

            for (int i = 0; i < 10000; i++)
            {
                Point a, b;
                Segment.Position layout;

                if(i%2 == 0)
                {
                    layout = Segment.Position.Vertical;
                    int x = RandomNumber(MINLIMIT, MAXLIMIT);
                    a = new Point(x, RandomNumber(MINLIMIT, MAXLIMIT));
                    b = new Point(x, RandomNumber(MINLIMIT, MAXLIMIT));
                }
                else
                {
                    layout = Segment.Position.Horizontal;
                    int y = RandomNumber(MINLIMIT, MAXLIMIT);
                    a = new Point(RandomNumber(MINLIMIT, MAXLIMIT), y);
                    b = new Point(RandomNumber(MINLIMIT, MAXLIMIT), y);
                }

                Segment segment = new Segment(a, b, layout);
                segment.Minimum.Segment = segment;
                segment.Maximum.Segment = segment;
                _set.Add(segment);
                _list.Add(segment);
            }
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
