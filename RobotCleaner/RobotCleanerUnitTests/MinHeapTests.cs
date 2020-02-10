using NUnit;
using NUnit.Framework;
using RobotCleaner;
using RobotCleaner.BasicStructures;
using System;

namespace RobotCleanerUnitTests
{
    public class MinHeapTests
    {
        [Test]
        public void PopMin_ReturnsMinimalElementAndRemovesItFromQueue()
        {
            //Arrange
            MinHeap<Point> heap = GenerateHeap();
            int initialHeapSize = heap.GetSize();
            Point min = new Point(1, 1);

            //Act
            Point popResult = heap.PopMin();
            Point getMinResult = heap.GetMin();
            int currentHeapSize = heap.GetSize();

            Assert.AreEqual(min, popResult);
            Assert.AreNotEqual(getMinResult, popResult);
            Assert.GreaterOrEqual(getMinResult, popResult);
            Assert.Less(currentHeapSize, initialHeapSize);
        }

        [Test]
        public void Add_AppendsNewElementToItsPriorityPosition()
        {
            //Arrange
            MinHeap<Point> heap = GenerateHeap();
            int initialHeapSize = heap.GetSize();
            Point min = new Point(0, 0);

            //Act
            Point currentMin = heap.GetMin();
            heap.Add(min);
            int currentHeapSize = heap.GetSize();
            Point newMin = heap.GetMin();

            Assert.AreEqual(min, newMin);
            Assert.Greater(currentHeapSize, initialHeapSize);
            Assert.AreNotEqual(currentMin, newMin);
            Assert.LessOrEqual(newMin, currentMin);
        }



        private MinHeap<Point> GenerateHeap()
        {
            MinHeap<Point> heap = new MinHeap<Point>();

            
            heap.Add(new Point(5, 1));
            heap.Add(new Point(7, 1));
            heap.Add(new Point(2, 2));
            heap.Add(new Point(3, 2));
            heap.Add(new Point(1, 3));
            heap.Add(new Point(3, 3));
            heap.Add(new Point(1, 1));
            heap.Add(new Point(3, 4));
            heap.Add(new Point(6, 4));
            heap.Add(new Point(2, 5));
            heap.Add(new Point(7, 5));
            heap.Add(new Point(5, 6));
            heap.Add(new Point(6, 6));
            heap.Add(new Point(3, 7));

            return heap;
        }
    }
}
