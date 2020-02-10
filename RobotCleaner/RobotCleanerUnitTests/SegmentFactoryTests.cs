using NUnit;
using NUnit.Framework;
using RobotCleaner;
using System;

namespace RobotCleanerUnitTests
{
    public class SegmentFactoryTests
    {
        [Test]
        public void CreateNextSegment_InputDirectionNorth_ReturnsVerticalSegment()
        {
            //Arrange
            SegmentFactory factory = new SegmentFactory();
            string command = "N 4";

            //Act
            Segment segment = factory.CreateNextSegment(command, 1, 1, 0);

            Assert.AreEqual(segment.Layout, Segment.Position.Vertical);
        }

        [Test]
        public void CreateNextSegment_InputDirectionSouth_ReturnsVerticalSegment()
        {
            //Arrange
            SegmentFactory factory = new SegmentFactory();
            string command = "S 4";

            //Act
            Segment segment = factory.CreateNextSegment(command, 1, 1, 0);

            Assert.AreEqual(segment.Layout, Segment.Position.Vertical);
        }

        [Test]
        public void CreateNextSegment_InputDirectionEast_ReturnsHorizontalSegment()
        {
            //Arrange
            SegmentFactory factory = new SegmentFactory();
            string command = "E 4";

            //Act
            Segment segment = factory.CreateNextSegment(command, 1, 1, 0);

            Assert.AreEqual(segment.Layout, Segment.Position.Horizontal);
        }

        [Test]
        public void CreateNextSegment_InputDirectionWest_ReturnsHorizontalSegment()
        {
            //Arrange
            SegmentFactory factory = new SegmentFactory();
            string command = "W 4";

            //Act
            Segment segment = factory.CreateNextSegment(command, 1, 1, 0);

            Assert.AreEqual(segment.Layout, Segment.Position.Horizontal);
        }

        [Test]
        public void CreateNextSegment_InputCommandIncludesTenSteps_ReturnsSegmentOfLengthTen()
        {
            //Arrange
            SegmentFactory factory = new SegmentFactory();
            string command = "E 10";

            //Act
            Segment segment = factory.CreateNextSegment(command, 1, 1, 1);

            Assert.AreEqual(segment.Length, 10);
        }
    }
}
