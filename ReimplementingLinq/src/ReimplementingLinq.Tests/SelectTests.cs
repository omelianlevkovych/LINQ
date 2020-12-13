using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReimplementingLinq.Operators;
using ReimplementingLinq.Tests.Utilities;
using Xunit;
using linqEnumerable = System.Linq.Enumerable;

namespace ReimplementingLinq.Tests
{
    /// <summary>
    /// The tests for <see cref="Enumerable"/>.
    /// </summary>
    public class SelectTests
    {
        /// <summary>
        /// Verify that Select operator can project to different type.
        /// </summary>
        [Fact]
        public void VerifySelectShouldProjectToDifferentType()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> {2, -2, 8};
            var selector = new Func<int, string>(x => x.ToString());

            // act
            var result = source.Select(selector);
            
            // assert
            Assert.Equal(new Collection<string>{"2", "-2", "8"}, result);
        }

        /// <summary>
        /// Test showing the possible unexpected behavior using Select operator.
        /// </summary>
        [Fact]
        public void VerifySelectHasSideEffectsInProjection()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> {0, 0, 0, 0};
            var counter = 0;

            // act, assert
            // Note that Select was called only once, but the result changed drastically.
            var selectQuery = source.Select(x => ++counter);
            var firstSelectQueryResult = linqEnumerable.ToList(selectQuery);
            Assert.Equal(new Collection<int>{1, 2, 3, 4}, firstSelectQueryResult);

            var secondSelectQueryResult = linqEnumerable.ToList(selectQuery);
            Assert.Equal(new Collection<int> { 5, 6, 7, 8 }, secondSelectQueryResult);
        }

        /// <summary>
        /// Verify that select and where operators in query expression filters out int sequence.
        /// </summary>
        [Fact]
        public void VerifySelectWithWhereQueryExpressionShouldFilersOutIntSequence()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> { 2, 2, 8, 1, 4, -5, 0, 4, -3 };

            // act
            // The compiler translates this into lambda expression which after all be converted into a delegate
            var result = from x in source
                where x < 2
                select x * x;

            // assert
            Assert.Equal(new Collection<int> { 1, 25, 0, 9 }, result);
        }

        /// <summary>
        /// Should throws <see cref="ArgumentNullException"/> when Select operator has null as source.
        /// </summary>
        [Fact]
        public void VerifySelectWhenNullSourceShouldThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act, assert
            // The important note here is that arguments being validated immediately, without any iteration.
            Assert.Throws<ArgumentNullException>(() => source.Select(x => x == 0));
        }

        /// <summary>
        /// Should throws <see cref="ArgumentNullException"/> when Select operator has null as predicate.
        /// </summary>
        [Fact]
        public void VerifySelectWhenNullPredicateShouldThrowsNullArgumentException()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> { 1, 2, 2, 8, -5 };
            Func<int, bool> predicate = null;

            // act, assert
            // Without any iteration, the Where operator immediately knows about null predicate.
            Assert.Throws<ArgumentNullException>(() => source.Select(predicate));
        }

        /// <summary>
        /// Should check that Select operator is deferred.
        /// </summary>
        [Fact]
        public void VerifySelectWhenExecutionIsDeferred()
        {
            ThrowingExceptionEnumerable<int>.AssertDeferred<int, int>(source => source.Select(x => x));
        }

        /// <summary>
        /// Should check that Select operator does not mutate the source.
        /// </summary>
        [Fact]
        public void VerifySelectShouldNotMutateTheSourceParameter()
        {
            // arrange
            IEnumerable<int> source = new Collection<int> { 2, 2, 8, 1, 4, -5, 0, 4, -3 };
            IEnumerable<int> expectedResult = new Collection<int> { 2, 2, 8, 1, 4, -5, 0, 4, -3 };

            // act
            var selector = new Func<int, int>(x => ++x);
            var result = source.Select(selector);

            // assert
            Assert.Equal(expectedResult, source);
            Assert.Equal(new Collection<int>{3, 3, 9, 2, 5, -4, 1, 5, -2}, result);
        }
    }
}
