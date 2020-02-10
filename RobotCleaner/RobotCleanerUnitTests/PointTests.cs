using NUnit;
using NUnit.Framework;
using RobotCleaner;
using System;

namespace RobotCleanerUnitTests
{
    
    public class PointTests
    {
        [Test]
        public void Equals_InputIsNull_ReturnsFalse()
        {
            // Arrange
            Point point = new Point();

            Assert.IsFalse(point.Equals(null));
        }

        [Test]
        public void Equals_InputIsDifferentFromTestEntity_ReturnsFalse()
        {
            //Arrange
            Point initialPoint = new Point(0, 0);
            Point differentX = new Point(1, 0);
            Point differentY = new Point(0, 1);

            
            Assert.IsFalse(initialPoint.Equals(differentX));
            Assert.IsFalse(initialPoint.Equals(differentY));
        }

        [Test]
        public void Equals_InputIsEqualToTestEntity_ReturnsTrue()
        {
            //Arrange
            Point initialPoint = new Point(0, 0);
            Point input = new Point(0, 0);


            Assert.IsTrue(initialPoint.Equals(input));
        }

        [Test]
        public void CompareTo_InputXIsGreater_ReturnsNegative()
        {
            //Arrange
            Point initialPoint = new Point(0, 0);
            Point input = new Point(1, 0);

            Assert.Less(initialPoint.CompareTo(input), 0);
        }

        [Test]
        public void CompareTo_InputXIsLess_ReturnsPositive()
        {
            //Arrange
            Point initialPoint = new Point(1, 0);
            Point input = new Point(0, 0);

            Assert.Greater(initialPoint.CompareTo(input), 0);
        }

        [Test]
        public void CompareTo_InputXIsEqualYIsGreater_ReturnsNegative()
        {
            //Arrange
            Point initialPoint = new Point(0, 0);
            Point input = new Point(0, 1);

            Assert.Less(initialPoint.CompareTo(input), 0);
        }

        [Test]
        public void CompareTo_InputXIsEqualYIsLess_ReturnsPositive()
        {
            //Arrange
            Point initialPoint = new Point(0, 1);
            Point input = new Point(0, 0);

            Assert.Greater(initialPoint.CompareTo(input), 0);
        }

        [Test]
        public void CompareTo_InputIsEqual_ReturnsZero()
        {
            //Arrange
            Point initialPoint = new Point(0, 0);
            Point input = new Point(0, 0);

            Assert.AreEqual(initialPoint.CompareTo(input), 0);
        }

        [Test]
        public void CompareTo_InputIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            Point initialPoint = new Point(0, 0);

            Assert.Throws<ArgumentNullException>(() => initialPoint.CompareTo(null));
        }
    }
}
