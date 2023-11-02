//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

// TODO: Remove this once https://github.com/nanoframework/CoreLibrary/pull/207 is merged and we can access MathInternal
namespace nanoFramework.UI
{
    /// <summary>
    /// Simple Min/Max for the wpf measures.
    /// </summary>
    public static class Mathematics
    {
        /// <summary>
        /// Finds the maximum between 2 ints.
        /// </summary>
        /// <param name="a">First int.</param>
        /// <param name="b">Second int.</param>
        /// <returns>The maximum value between a and b.</returns>
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        /// <summary>
        /// Finds the minimum between 2 ints.
        /// </summary>
        /// <param name="a">First int.</param>
        /// <param name="b">Second int.</param>
        /// <returns>The minimum value between a and b.</returns>
        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        /// <summary>
        /// Returns the absolute value of an int.
        /// </summary>
        /// <param name="a">The int.</param>
        /// <returns>The absolute value.</returns>
        public static int Abs(int a)
        {
            return a < 0 ? a*-1 : a;
        }
    }
}
