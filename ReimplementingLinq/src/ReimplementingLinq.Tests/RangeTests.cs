using System;
using System.Collections.ObjectModel;
using ReimplementingLinq.Operators;
using ReimplementingLinq.Tests.Utilities;
using Xunit;

namespace ReimplementingLinq.Tests
{
    public class RangeTests
    {
        [Fact]
        public void VerifyRangeWhenNegativeCountParameter()
        { 
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(0, -1));
        }

        [Fact]
        public void VerifyRangeWhenCountParameterIsTooHuge()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(2, int.MaxValue));
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(int.MaxValue, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(int.MaxValue / 2, int.MaxValue / 2 + 3));

        }

        [Fact]
        public void VerifyRangeWhenSingleValueOfMaxInt32ShouldBeValid()
        {
            var result = Enumerable.Range(int.MaxValue, 1);
            Assert.Equal(new Collection<int> {Int32.MaxValue }, result);
        }

        [Fact]
        public void VerifyRangeWhenEmptyRangeStartingAtMinInt32ShouldBeValid()
        {
            var result = Enumerable.Range(int.MinValue, 0);
            Assert.Equal(new Collection<int>(), result);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void VerifyRangeWhenParametersAreHugeButStillValid()
        {
            // The edge cases.
            Enumerable.Range(int.MaxValue, 1);
            Enumerable.Range(1, int.MaxValue);
            Enumerable.Range(int.MaxValue / 2, int.MaxValue / 2 + 2);
        }

        [Fact]
        public void VerifyRangeWhen_0_0_ShouldReturnsEmptyCollection()
        {
            var result = Enumerable.Range(0, 0);
            Assert.Equal(new Collection<int>(), result);
        }

        [Fact]
        public void VerifyRangeWithEmptyCountShouldBeValid()
        {
            var result = Enumerable.Range(101, 0);
            Assert.Equal(new Collection<int>(), result);
        }

        [Fact]
        public void VerifyRangeShouldReturnsValidCollection()
        {
            var result = Enumerable.Range(1, 10);
            Assert.Equal(new Collection<int>{1, 2, 3, 4, 5, 6 ,7, 8, 9 ,10}, result);
        }

        [Fact]
        public void VerifyRangeWithNegativeStartShouldBeValid()
        {
            var result = Enumerable.Range(-101, 1);
            Assert.Equal(new Collection<int>{ -101 }, result);
        }

        /// <summary>
        /// Should check that Range operator is deferred.
        /// </summary>
        [Fact]
        public void VerifyRangeWhenExecutionIsDeferred()
        {
            ThrowingExceptionEnumerable<int>.AssertDeferred<int, int>(source => Enumerable.Range(1, 1));
        }
    }
}
