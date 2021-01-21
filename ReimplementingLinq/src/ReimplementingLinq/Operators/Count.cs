using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ReimplementingLinq.Operators
{
    /// <summary>
    /// The class which contains all rewritten LINQ, in this file Count operator.
    /// </summary>
    public static partial class Enumerable
    {
        public static int Count<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            // Note: We are not using the iterator block, so we do not need to split the implemenation and validation logic.
            int count = 0;
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    checked { ++count; }
                }
            }
            return count;
        }

        public static int Count<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentException(nameof(source));

            ICollection<TSource> genericCollection = source as ICollection<TSource>;
            if (genericCollection != null)
            {
                return genericCollection.Count;
            }

            ICollection nonGenericCollection = source as ICollection;
            if (nonGenericCollection != null)
            {
                return nonGenericCollection.Count;
            }

            int count = 0;
            using var iterator = source.GetEnumerator();
            while (iterator.MoveNext())
            {
                checked { ++count; }
            }
            return count;
        }
    }
}
