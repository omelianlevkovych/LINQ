using System;
using System.Collections.Generic;

namespace ReimplementingLinq.Operators
{
    /// <summary>
    /// The class which contains all rewritten LINQ, in this file Where operator.
    /// </summary>
    public static partial class Enumerable
    {
        /// <summary>
        /// The Where operator validation part.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return WhereImplementation(source, predicate);
        }

        /// <summary>
        /// The Where operator implementation part.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TSource> WhereImplementation<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// The Where operator with index, validation part.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return WhereImplementation(source, predicate);
        }

        /// <summary>
        /// The Where operator with index, implementation part.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TSource> WhereImplementation<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var index = -1;
            foreach (var item in source)
            {
                checked { ++index; }
                if (predicate(item, index))
                {
                    yield return item;
                }
            }
        }

        private static IEnumerable<TSource> WrongWhere<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            // Differed execution so no of this validation will word, do to the fact we do not iterate throw source in our tests.
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
