using System;
using System.Collections.Generic;
using System.Text;

namespace ReimplementingLinq.Operators
{
    /// <summary>
    /// The class which contains all rewritten LINQ, in this file Where operator.
    /// </summary>
    public partial class Enumerable
    {
        /// <summary>
        /// The Range static method, validation part.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static IEnumerable<int> Range(int start, int count)
        {
            long max = ((long) start) + count - 1;
            if (count < 0 || max > Int32.MaxValue) throw new ArgumentOutOfRangeException(nameof(count));
            return RangeIterator(start, count);
        }

        /// <summary>
        /// The Range operator iterator.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        static IEnumerable<int> RangeIterator(int start, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return start + i;
            }
        }
    }
}
