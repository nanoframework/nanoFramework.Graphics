using System;
using System.Drawing;
using nanoFramework.TestFramework;

namespace nanoFramework.Graphics.Core.UnitTests.System.Drawing
{
    [TestClass]
    public class Rectangle_UnitTests
    {
        [TestMethod]
        public void Contains_Point_should_return_false()
        {
            var point = new Point(123, 123);
            var sut = new Rectangle(Point.Empty, new Size(100, 100));

            Assert.IsFalse(sut.Contains(point));
        }

        [TestMethod]
        public void Contains_Point_should_return_true()
        {
            var point = new Point(50, 50);
            var sut = new Rectangle(Point.Empty, new Size(100, 100));

            Assert.IsTrue(sut.Contains(point));
        }

        [TestMethod]
        public void Contains_Rectangle_should_return_false()
        {
            var rectangle = new Rectangle(Point.Empty, new Size(200, 200));
            var sut = new Rectangle(Point.Empty, new Size(100, 100));

            Assert.IsFalse(sut.Contains(rectangle));
        }

        [TestMethod]
        public void Contains_Rectangle_should_return_true()
        {
            var rectangle = new Rectangle(Point.Empty, new Size(50, 50));
            var sut = new Rectangle(Point.Empty, new Size(100, 100));

            Assert.IsTrue(sut.Contains(rectangle));
        }

        [TestMethod]
        public void Empty_should_have_correct_properties()
        {
            var sut = Rectangle.Empty;

            Assert.AreEqual(0, sut.X);
            Assert.AreEqual(0, sut.Y);
            Assert.AreEqual(0, sut.Width);
            Assert.AreEqual(0, sut.Height);
        }

        [TestMethod]
        public void FromLRTB_should_return_correct_Rectangle()
        {
            var expect = new Rectangle(10, 20, 30, 30);
            var actual = Rectangle.FromLTRB(10, 20, 40, 50);

            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Inflate_should_inflate_the_Rectangle()
        {
            var sut = new Rectangle(10, 10, 10, 10);
            sut.Inflate(10, 10);

            Assert.AreEqual(0, sut.X);
            Assert.AreEqual(0, sut.Y);
            Assert.AreEqual(30, sut.Width);
            Assert.AreEqual(30, sut.Height);
        }

        [TestMethod]
        public void Intersect_should_create_correct_Rectangle()
        {
            var rectangleA = new Rectangle(Point.Empty, new Size(100, 100));
            var rectangleB = new Rectangle(new Point(50, 50), new Size(100, 100));

            var expect = new Rectangle(new Point(50, 50), new Size(50, 50));

            rectangleA.Intersect(rectangleB);

            Assert.AreEqual(expect, rectangleA);
        }

        [TestMethod]
        public void IntersectsWith_should_return_false()
        {
            var rectangleA = new Rectangle(Point.Empty, new Size(100, 100));
            var rectangleB = new Rectangle(new Point(100, 100), new Size(100, 100));

            var actual = rectangleA.IntersectsWith(rectangleB);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IntersectsWith_should_return_true()
        {
            var rectangleA = new Rectangle(Point.Empty, new Size(100, 100));
            var rectangleB = new Rectangle(new Point(50, 50), new Size(100, 100));

            var actual = rectangleA.IntersectsWith(rectangleB);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsEmpty_should_return_false()
        {
            var sut = new Rectangle(1, 1, 1, 1);

            Assert.IsFalse(sut.IsEmpty);
        }

        [TestMethod]
        public void IsEmpty_should_return_true()
        {
            var sut = new Rectangle(0, 0, 0, 0);

            Assert.IsTrue(sut.IsEmpty);
        }

        [TestMethod]
        public void Left_should_be_correct()
        {
            var sut = new Rectangle(1, 2, 3, 4);

            Assert.AreEqual(sut.X, sut.Left);
        }

        [TestMethod]
        public void Location_should_be_correct()
        {
            var sut = new Rectangle(1, 2, 3, 4);
            var expect = new Point(1, 2);

            Assert.AreEqual(expect, sut.Location);
        }

        [TestMethod]
        public void Offset_should_move_rectangle()
        {
            var sut = new Rectangle(Point.Empty, new Size(50, 50));
            var offset = new Point(10, 10);

            var expect = new Rectangle(offset, sut.Size);

            sut.Offset(offset);

            Assert.AreEqual(expect, sut);
        }

        [TestMethod]
        public void Right_should_be_correct()
        {
            var sut = new Rectangle(1, 2, 3, 4);

            Assert.AreEqual(sut.X + sut.Width, sut.Right);
        }

        [TestMethod]
        public void Size_should_be_correct()
        {
            var sut = new Rectangle(1, 2, 3, 4);
            var expect = new Size(3, 4);

            Assert.AreEqual(expect, sut.Size);
        }

        [TestMethod]
        public void Union_should_create_correct_Rectangle()
        {
            var rectangleA = new Rectangle(Point.Empty, new Size(100, 100));
            var rectangleB = new Rectangle(new Point(50, 50), new Size(100, 100));

            var expect = new Rectangle(new Point(50, 50), new Size(50, 50));

            var actual = Rectangle.Union(rectangleA, rectangleB);

            Assert.AreEqual(expect, actual);
        }
    }
}
