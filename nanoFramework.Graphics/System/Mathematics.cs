//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.UI
{
    /// <summary>
    /// Simple Min/Max for the wpf measures
    /// </summary>
    public static class Mathematics
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public int Max(int a, int b)
        {
            return a > b ? a : b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public int Min(int a, int b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static public int Abs(int a)
        {
            return a < 0 ? a*-1 : a;
        }
    }
}
