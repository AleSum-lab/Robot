using NUnit;
using NUnit.Framework;
using RobotCleaner;
using System;

namespace RobotCleanerUnitTests
{
    public class SegmentTests
    {
        [Test]
        public void Segment_CorrectlySettsExtremaByXAxys()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);

            //Act
            Segment segment = new Segment(min, max, Segment.Position.Horizontal);

            Assert.AreEqual(segment.Minimum, min);
            Assert.AreEqual(segment.Maximum, max);
            Assert.Greater(segment.Maximum, segment.Minimum);
            Assert.AreEqual(segment.Minimum.End, SegmentEnd.Left);
            Assert.AreEqual(segment.Maximum.End, SegmentEnd.Right);
        }

        [Test]
        public void Segment_CorrectlySettsExtremaByYAxys()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(1, 3);

            //Act
            Segment segment = new Segment(min, max, Segment.Position.Horizontal);

            Assert.AreEqual(segment.Minimum, min);
            Assert.AreEqual(segment.Maximum, max);
            Assert.Greater(segment.Maximum, segment.Minimum);
            Assert.AreEqual(segment.Minimum.End, SegmentEnd.Left);
            Assert.AreEqual(segment.Maximum.End, SegmentEnd.Right);
        }

        [Test]
        public void Equals_VerticalSegmentsInputIsDifferentFromTestEntity_ReturnsFalse()
        {
            //Arrange vertical
            Point min = new Point(1, 1);
            Point max = new Point(1, 3);
            Point minWithDifX = new Point(2, 1);
            Point maxWithDifX = new Point(2, 3);
            Point minWithDifY = new Point(1, 2);
            Point maxWithDifY = new Point(1, 4);
            Segment initial = new Segment(min, max, Segment.Position.Vertical);

            Segment withDiffX = new Segment(minWithDifX, maxWithDifX, Segment.Position.Vertical);
            Segment withDiffY = new Segment(minWithDifY, maxWithDifY, Segment.Position.Vertical);

            Assert.IsFalse(initial.Equals(withDiffX));
            Assert.IsFalse(initial.Equals(withDiffY));
        }

        [Test]
        public void Equals_HorizontalSegmentsInputIsDifferentFromTestEntity_ReturnsFalse()
        {
            //Arrange vertical
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);
            Point minWithDifX = new Point(2, 1);
            Point maxWithDifX = new Point(4, 1);
            Point minWithDifY = new Point(3, 4);
            Point maxWithDifY = new Point(0, 4);
            Segment initial = new Segment(min, max, Segment.Position.Vertical);

            Segment withDiffX = new Segment(minWithDifX, maxWithDifX, Segment.Position.Vertical);
            Segment withDiffY = new Segment(minWithDifY, maxWithDifY, Segment.Position.Vertical);

            Assert.IsFalse(initial.Equals(withDiffX));
            Assert.IsFalse(initial.Equals(withDiffY));
        }

        [Test]
        public void Equals_PerpendicularSegments_ReturnsFalse()
        {
            //Arrange vertical
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);
            Point otherMin = new Point(2, 0);
            Point otherMax = new Point(2, 2);
            Segment initial = new Segment(min, max, Segment.Position.Vertical);

            Segment withDiffX = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.IsFalse(initial.Equals(withDiffX));
        }

        [Test]
        public void Equals_InputIsEqual_ReturnsTrue()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(1, 3);
            Point otherMin = new Point(1, 1);
            Point otherMax = new Point(1, 3);

            Segment initial = new Segment(min, max, Segment.Position.Vertical);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.IsTrue(initial.Equals(other));
        }

        [Test]
        public void CompareTo_VerticalSegmentsInputMinYIsLess_ReturnsNegative()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(1, 3);
            Point otherMin = new Point(1, 0);
            Point otherMax = new Point(1, 3);

            Segment initial = new Segment(min, max, Segment.Position.Vertical);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.Greater(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_VerticalSegmentsInputMinYIsGreater_ReturnsNegative()
        {
            //Arrange
            Point min = new Point(1, 0);
            Point max = new Point(1, 3);
            Point otherMin = new Point(1, 1);
            Point otherMax = new Point(1, 3);

            Segment initial = new Segment(min, max, Segment.Position.Vertical);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.Less(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_VerticalSegmentsInputMinYIsEqualMaxYIsGreater_ReturnsNegative()
        {
            //Arrange
            Point min = new Point(1, 0);
            Point max = new Point(1, 3);
            Point otherMin = new Point(1, 0);
            Point otherMax = new Point(1, 4);

            Segment initial = new Segment(min, max, Segment.Position.Vertical);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.Less(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_VerticalSegmentsInputMinYIsEqualMaxYIsLess_ReturnsPositive()
        {
            //Arrange
            Point min = new Point(1, 0);
            Point max = new Point(1, 3);
            Point otherMin = new Point(1, 0);
            Point otherMax = new Point(1, 2);

            Segment initial = new Segment(min, max, Segment.Position.Vertical);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.Greater(initial.CompareTo(other), 0);
        }




        [Test]
        public void CompareTo_HorizontalSegmentsInputMinXIsLess_ReturnsPositive()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);
            Point otherMin = new Point(0, 1);
            Point otherMax = new Point(3, 1);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Horizontal);

            Assert.Greater(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_HorizontalSegmentsInputMinXIsGreater_ReturnsNegative()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);
            Point otherMin = new Point(2, 1);
            Point otherMax = new Point(3, 1);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Horizontal);

            Assert.Less(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_HorizontalSegmentsInputMinXIsEqualMaxXIsGreater_ReturnsNegative()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);
            Point otherMin = new Point(1, 1);
            Point otherMax = new Point(5, 1);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Horizontal);

            Assert.Less(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_HorizontalSegmentsInputMinXIsEqualMaxXIsLess_ReturnsPositive()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);
            Point otherMin = new Point(1, 1);
            Point otherMax = new Point(2, 1);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Horizontal);

            Assert.Greater(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_PerpendicularSegmentsInputMinYIsGreater_ReturnsNegative()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);
            Point otherMin = new Point(1, 2);
            Point otherMax = new Point(1, 4);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.Less(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_PerpendicularSegmentsInputMinYIsLess_ReturnsPositive()
        {
            //Arrange
            Point min = new Point(1, 1);
            Point max = new Point(3, 1);
            Point otherMin = new Point(1, 0);
            Point otherMax = new Point(1, 4);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.Greater(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_PerpendicularSegmentsInputMinYIsEqualMaxYIsLess_ReturnsPositive()
        {
            //Arrange
            Point min = new Point(1, 2);
            Point max = new Point(3, 2);
            Point otherMin = new Point(1, 2);
            Point otherMax = new Point(1, 1);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.Greater(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_PerpendicularSegmentsInputMinYIsEqualMaxYIsGreater_ReturnsNegative()
        {
            //Arrange
            Point min = new Point(1, 2);
            Point max = new Point(3, 2);
            Point otherMin = new Point(1, 2);
            Point otherMax = new Point(1, 4);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Vertical);

            Assert.Less(initial.CompareTo(other), 0);
        }

        [Test]
        public void CompareTo_InputIsEqualSegment_ReturnsZero()
        {
            //Arrange
            Point min = new Point(1, 2);
            Point max = new Point(3, 2);
            Point otherMin = new Point(1, 2);
            Point otherMax = new Point(3, 2);

            Segment initial = new Segment(min, max, Segment.Position.Horizontal);
            Segment other = new Segment(otherMin, otherMax, Segment.Position.Horizontal);

            Assert.AreEqual(initial.CompareTo(other), 0);
        }
    }
}
