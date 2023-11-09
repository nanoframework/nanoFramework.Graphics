using System.Drawing;
using nanoFramework.TestFramework;

namespace nanoFramework.Graphics.Core.UnitTests.System.Drawing
{
    [TestClass]
    public class Point_UnitTests
    {
        [TestMethod]
        public void Add_should_move_Point()
        {
            var size = new Size(456, 123);
            var sut = new Point(123, 456);

            var actual = sut + size;

            Assert.AreEqual(579, actual.X);
            Assert.AreEqual(579, actual.Y);
        }

        [TestMethod]
        public void Equals_should_return_false()
        {
            var pointA = new Point(123, 456);
            var pointB = new Point(789, 012);

            Assert.IsFalse(pointA.Equals(pointB));
            Assert.IsFalse(pointA.Equals((object)pointB));
            Assert.IsFalse(pointA == pointB);
            Assert.IsTrue(pointA != pointB);
        }

        [TestMethod]
        public void Equals_should_return_true()
        {
            var pointA = new Point(123, 456);
            var pointB = new Point(123, 456);

            Assert.IsTrue(pointA.Equals(pointB));
            Assert.IsTrue(pointA.Equals((object) pointB));
            Assert.IsTrue(pointA == pointB);
            Assert.IsFalse(pointA != pointB);
        }

        [TestMethod]
        public void Empty_should_have_correct_properties()
        {
            var sut = Point.Empty;

            Assert.AreEqual(0, sut.X);
            Assert.AreEqual(0, sut.Y);
        }

        [TestMethod]
        public void IsEmpty_should_return_false()
        {
            var sut = new Point(1, 1);

            Assert.IsFalse(sut.IsEmpty);
        }

        [TestMethod]
        public void IsEmpty_should_return_true()
        {
            var sut = new Point(0, 0);

            Assert.IsTrue(sut.IsEmpty);
        }

        [TestMethod]
        public void Offset_should_move_Point()
        {
            var sut = new Point(123, 456);
            sut.Offset(new Point(456, 123));

            Assert.AreEqual(579, sut.X);
            Assert.AreEqual(579, sut.Y);
        }

        [TestMethod]
        public void Should_cast_to_Size()
        {
            var sut = new Point(123, 456);
            var actual = (Size) sut;

            Assert.AreEqual(sut.X, actual.Width);
            Assert.AreEqual(sut.Y, actual.Height);
        }

        [TestMethod]
        public void Subtract_should_move_Point()
        {
            var size = new Size(456, 123);
            var sut = new Point(123, 456);

            var actual = sut - size;

            Assert.AreEqual(-333, actual.X);
            Assert.AreEqual(333, actual.Y);
        }
    }
}
