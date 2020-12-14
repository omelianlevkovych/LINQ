using System;
using System.Collections.Generic;
using System.Text;
using ReimplementingLinq.Operators;
using Xunit;

namespace ReimplementingLinq.Tests
{
    public class EmptyTests
    {
        /// <summary>
        /// Verify that Empty returned sequence is empty.
        /// </summary>
        [Fact]
        public void VerifyEmptyContainsNoElements()
        {
            // arrange
            using var empty = Enumerable.Empty<int>().GetEnumerator();

            // act, assert
            Assert.False(empty.MoveNext());
        }

        /// <summary>
        /// Verify that Empty is a singleton per element type.
        /// </summary>
        [Fact]
        public void VerifyEmptyIsSingletonPerElementType()
        {
            Assert.Same(Enumerable.Empty<int>(), Enumerable.Empty<int>());
            Assert.Same(Enumerable.Empty<double>(), Enumerable.Empty<double>());
            Assert.Same(Enumerable.Empty<long>(), Enumerable.Empty<long>());
            Assert.Same(Enumerable.Empty<object>(), Enumerable.Empty<object>());
            Assert.Same(Enumerable.Empty<string>(), Enumerable.Empty<string>());

            Assert.NotSame(Enumerable.Empty<int>(), Enumerable.Empty<long>());
            Assert.NotSame(Enumerable.Empty<string>(), Enumerable.Empty<object>());
            Assert.NotSame(Enumerable.Empty<object>(), Enumerable.Empty<long>());
            Assert.NotSame(Enumerable.Empty<long>(), Enumerable.Empty<string>());


        }
    }
}
