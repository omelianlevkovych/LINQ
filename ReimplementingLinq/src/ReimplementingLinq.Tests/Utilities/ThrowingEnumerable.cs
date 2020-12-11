using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ReimplementingLinq.Tests.Utilities
{
    /// <summary>
    /// The class responsible for verifying that linq operator is deferred.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ThrowingExceptionEnumerable<T> : IEnumerable<T>
    {
        /// <summary>
        /// The methods throws <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// The method which checks that the given <see cref="deferredFunction"/> actually uses deferred execution.
        /// When the function just call itself it should not throw an exception. But, when using the result
        /// by calling <see cref="GetEnumerator"/> and than GetNext() methods should throws the <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <typeparam name="TSource">The deferred function source type.</typeparam>
        /// <typeparam name="TResult">The deferred function result type.</typeparam>
        /// <param name="deferredFunction">The deferred function (unit of work under the test).</param>
        public static void AssertDeferred<TSource,TResult>(
            Func<IEnumerable<TSource>, IEnumerable<TResult>> deferredFunction)
        {
            var source = new ThrowingExceptionEnumerable<TSource>();
            
            // Does not throw any exception here, because GetEnumerator() method is not yet used.
            var result = deferredFunction(source);

            // Does not throw InvalidOperationException even here, despite the fact that we retrieve the enumerator.
            using var iterator = result.GetEnumerator();

            Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
        }
    }
}
