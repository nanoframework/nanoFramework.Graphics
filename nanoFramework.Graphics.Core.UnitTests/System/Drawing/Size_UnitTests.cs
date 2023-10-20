using nanoFramework.TestFramework;
using System.Drawing;

namespace nanoFramework.Graphics.Core.UnitTests.System.Drawing
{
    [TestClass]
    public class Size_UnitTests
    {
        [TestMethod]
        public void Add_should_increase_Size()
        {
            var size = new Size(456, 123);
            var sut = new Size(123, 456);

            var actual = sut + size;

            Assert.AreEqual(579, actual.Width);
            Assert.AreEqual(579, actual.Height);
        }

        [TestMethod]
        public void Divide_should_decrease_size()
        {
            var sut = new Size(222, 444);

            var actual = sut / 2;

            Assert.AreEqual(111, actual.Width);
            Assert.AreEqual(222, actual.Height);
        }

        [TestMethod]
        public void Equals_should_return_false()
        {
            var pointA = new Size(123, 456);
            var pointB = new Size(789, 012);

            Assert.IsFalse(pointA.Equals(pointB));
            Assert.IsFalse(pointA.Equals((object)pointB));
            Assert.IsFalse(pointA == pointB);
            Assert.IsTrue(pointA != pointB);
        }

        [TestMethod]
        public void Equals_should_return_true()
        {
            var pointA = new Size(123, 456);
            var pointB = new Size(123, 456);

            Assert.IsTrue(pointA.Equals(pointB));
            Assert.IsTrue(pointA.Equals((object)pointB));
            Assert.IsTrue(pointA == pointB);
            Assert.IsFalse(pointA != pointB);
        }

        [TestMethod]
        public void Empty_should_have_correct_properties()
        {
            var sut = Size.Empty;

            Assert.AreEqual(0, sut.Width);
            Assert.AreEqual(0, sut.Height);
        }


        [TestMethod]
        public void Multiply_should_increase_size()
        {
            var sut = new Size(123, 456);

            var actual = sut * 2;

            Assert.AreEqual(246, actual.Width);
            Assert.AreEqual(912, actual.Height);
        }

        [TestMethod]
        public void Should_cast_to_Point()
        {
            var sut = new Size(123, 456);
            var actual = (Point) sut;

            Assert.AreEqual(sut.Width, actual.X);
            Assert.AreEqual(sut.Height, actual.Y);
        }

        [TestMethod]
        public void Subtract_should_decrease_size()
        {
            var size = new Size(456, 123);
            var sut = new Size(123, 456);

            var actual = sut - size;

            Assert.AreEqual(-333, actual.Width);
            Assert.AreEqual(333, actual.Height);
        }

    }
}
