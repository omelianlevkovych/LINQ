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
        /// The Select operator validation part.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TResult">The selector result type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The <see cref="IEnumerable{TResult}"/></returns>
        public static IEnumerable<TResult> Select<TSource,TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return SelectIterator(source, selector);
        }

        /// <summary>
        /// The Select operator iterator.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TResult">The selector result type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The <see cref="IEnumerable{TResult}"/></returns>
        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        /// <summary>
        /// The Select operator with index, validation part.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TResult">The selector result type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return WhereIterator(source, selector);
        }

        /// <summary>
        /// The Select operator with index iterator.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TResult">The selector result type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        private static IEnumerable<TResult> WhereIterator<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            var index = -1;
            foreach (var element in source)
            {
                checked { ++index; }
                yield return selector(element, index);
            }
        }
    }
}
