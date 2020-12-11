using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReimplementingLinq.Operators;
using ReimplementingLinq.Tests.Utilities;
using Xunit;

namespace ReimplementingLinq.Tests
{
    /// <summary>
    /// The tests for <see cref="Enumerable"/>.
    /// </summary>
    public class WhereTests
    {
        /// <summary>
        /// Should filters out the int32 sequence when using Where operator.
        /// </summary>
        [Fact]
        public void VerifyWhereShouldFiltersOutIntSequence()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> {2, 2, 8, 1, 4, -5, 0, 4, -3};

            // act
            var predicate = new Func<int, bool>(x => x < 2);
            var result = source.Where(predicate);
            
            // assert
            // Be aware that result has WhereEnumerableIterator<int32> type, while expected result is Collection<int32>
            Assert.Equal(new Collection<int>{1, -5, 0, -3}, result);
        }

        /// <summary>
        /// Should filters out the int32 sequence when using Where query expression.
        /// </summary>
        [Fact]
        public void VerifyWhereQueryExpressionShouldFilersOutIntSequence()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> { 2, 2, 8, 1, 4, -5, 0, 4, -3 };

            // act
            // The compiler translates this into lambda expression which after all be converted into a delegate
            var result = from x in source
                where x < 2
                select x;

            Assert.Equal(new Collection<int> { 1, -5, 0, -3 }, result);
        }

        /// <summary>
        /// Should filters out the int32 sequence when using Where operator with index predicate.
        /// </summary>
        [Fact]
        public void VerifyWhereWithIndexPredicateShouldFiltersOut()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> { 0, 20, 80, 10, 40, -50, 0, 40, -30 };

            // act
            // The compiler translates this into lambda expression which after all be converted into a delegate
            var result = source.Where((number, index) => number <= index * 10);

            Assert.Equal(new Collection<int> { 0, 10, 40, -50, 0, 40, -30 }, result);
        }

        /// <summary>
        /// Should throws <see cref="ArgumentNullException"/> when Where operator has null as source.
        /// </summary>
        [Fact]
        public void VerifyWhereWhenNullSourceShouldThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act, assert
            // The important note here is that arguments being validated immediately, without any iteration.
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x == 0));
        }

        /// <summary>
        /// Should throws <see cref="ArgumentNullException"/> when Where operator has null as predicate.
        /// </summary>
        [Fact]
        public void VerifyWhereWhenNullPredicateShouldThrowsNullArgumentException()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> {1, 2, 2, 8, -5};
            Func<int, bool> predicate = null;

            // act, assert
            // Without any iteration, the Where operator immediately knows about null predicate.
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        /// <summary>
        /// Should check that Where operator is deferred.
        /// </summary>
        [Fact]
        public void VerifyWhereWhenExecutionIsDeferred()
        {
            ThrowingExceptionEnumerable<int>.AssertDeferred<int, int>(source => source.Where(x => x == 0));
        }

        /// <summary>
        /// Should check that Where operator does not mutate the source.
        /// </summary>
        [Fact]
        public void VerifyWhereShouldNotMutateTheSourceParameter()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> { 2, 2, 8, 1, 4, -5, 0, 4, -3 };
            IEnumerable<int> expectedResult = new Collection<int> { 2, 2, 8, 1, 4, -5, 0, 4, -3 };

            // act
            var predicate = new Func<int, bool>(x => x < 2);
            source.Where(predicate);

            // assert
            Assert.Equal(expectedResult, source);
        }
    }
}
