// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.

using System.Drawing;
using nanoFramework.TestFramework;

namespace nanoFramework.Graphics.Core.UnitTests.System.Drawing
{
    [TestClass]
    public class Color_UnitTests
    {
        [TestMethod]
        public void ColorTestBasicSerialization()
        {
            // Arrange
            var col = Color.Red;

            // Act
            var col2 = Color.FromHex(col.ToString());

            // Assert
            Assert.AreEqual(col, col2);
        }

        [TestMethod]
        public void ColorTestColorSerialization()
        {
            // Arrange
            var col = "Red";

            // Act
            var col2 = Color.FromName(col);

            // Assert
            Assert.IsNotNull(col2);
            Assert.AreEqual(Color.Red, col2);
        }

        [TestMethod]
        public void ColorTestColorCaseSerialization()
        {
            // Arrange
            var col = "rEd";

            // Act
            var col2 = Color.FromName(col);

            // Assert
            Assert.IsNotNull(col2);
            Assert.AreEqual(Color.Red, col2);
        }

        [TestMethod]
        public void ColorEqualTest()
        {
            // Arrange
            var col1 = Color.Red;
            var col2 = Color.Red;

            Assert.AreEqual(col1, col2);
            Assert.IsTrue(col1 == col2);
        }

        [DataRow(new object[] { (byte)0b0000_0111, (byte)0b0000_0011, (byte)0b0000_0111, (ushort)0x0000 })]
        [DataRow(new object[] { (byte)0b0000_1111, (byte)0b0000_0111, (byte)0b0000_1111, (ushort)0b0000_1000_0010_0001 })]
        [DataRow(new object[] { (byte)0b0000_1111, (byte)0b0000_0111, (byte)0b1000_1111, (ushort)0b0000_1000_0011_0001 })]
        [DataRow(new object[] { (byte)0b0000_1111, (byte)0b1000_0111, (byte)0b1000_1111, (ushort)0b0000_1100_0011_0001 })]
        [DataRow(new object[] { (byte)0b1000_1111, (byte)0b1000_0111, (byte)0b1000_1111, (ushort)0b1000_1100_0011_0001 })]
        public void TestBgr565(byte b, byte g, byte r, ushort correctResult)
        {
            // Arrange
            var col = Color.FromArgb(255, r, g, b);

            // Act
            var result = col.ToBgr565();

            // Assert
            Assert.AreEqual(correctResult, result);
        }

        [DataRow(new object[] { (byte)0b0000_0111, (byte)0b0000_0011, (byte)0b0000_0111, (byte)ColorOrder.Rgb, (byte)8, (byte)8, (byte)8, (uint)0b0000_0111_0000_0011_0000_0111 })]
        [DataRow(new object[] { (byte)0b0000_0111, (byte)0b0000_0011, (byte)0b0000_0111, (byte)ColorOrder.Rgb, (byte)5, (byte)6, (byte)5, (uint)0b0000_0000_0000_0000_0000_0000 })]
        [DataRow(new object[] { (byte)0b0000_1111, (byte)0b0000_0111, (byte)0b0000_1111, (byte)ColorOrder.Rgb, (byte)5, (byte)6, (byte)5, (uint)0b0000_0000_0000_1000_0010_0001 })]
        [DataRow(new object[] { (byte)0b0000_1111, (byte)0b0000_0111, (byte)0b0000_1111, (byte)ColorOrder.Rgb, (byte)8, (byte)6, (byte)5, (uint)0b0000_0000_0111_1000_0010_0001 })]
        [DataRow(new object[] { (byte)0b0000_1111, (byte)0b0000_0111, (byte)0b0000_1111, (byte)ColorOrder.Rbg, (byte)8, (byte)6, (byte)5, (uint)0b0000_0000_0111_1000_0100_0001 })]
        public void TestRgbFormat(byte r, byte g, byte b, byte order, byte numR, byte numG, byte numB, uint correctResult)
        {
            // Arrange
            var col = Color.FromArgb(0, r, g, b);

            // Act
            var result = col.ToRgbFormat((ColorOrder)order, numR, numG, numB);

            // Assert
            Assert.AreEqual(correctResult, result);
        }
    }
}
