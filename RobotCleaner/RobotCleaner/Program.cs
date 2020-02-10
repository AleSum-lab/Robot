using RobotCleaner.BasicStructures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Segment> path = new SortedSet<Segment>(); // Try me instead
            //BinarySearchTree<Segment> tree = new BinarySearchTree<Segment>();

            SegmentFactory factory = new SegmentFactory();
            
            MinHeap<Point> points = new MinHeap<Point>();

            CleaningAnalyst analyst = new CleaningAnalyst(path, points);


            Console.WriteLine("Please enter the number of commands:");
            int commandCount = Convert.ToInt32(Console.ReadLine());
            

            Console.WriteLine("Please enter the start point:");
            string start = Console.ReadLine();
            string[] coordinates = start.Split(" ");

            int x = Convert.ToInt32(coordinates[0]);
            int y = Convert.ToInt32(coordinates[1]);


            for(int i = 0; i < commandCount; i++)
            {
                Console.WriteLine("Please enter the next command:");
                string input = Console.ReadLine();
                Segment segment;
                if (i == 0)
                {
                    segment = factory.CreateNextSegment(input, x, y, 0);
                }
                else
                {
                    segment = factory.CreateNextSegment(input, x, y, 1);
                }
                var max = segment.Maximum;
                var min = segment.Minimum;

                points.Add(max);
                points.Add(min);
                path.Add(segment);
                

                x = factory.CurrentEnd.X;
                y = factory.CurrentEnd.Y;
            }
            Console.WriteLine("I have cleaned: " + analyst.Report() + " unique places.");

        }


    }

}
