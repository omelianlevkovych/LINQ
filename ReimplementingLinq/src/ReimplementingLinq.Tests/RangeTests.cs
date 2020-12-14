using System;
using System.Collections.ObjectModel;
using ReimplementingLinq.Operators;
using Xunit;

namespace ReimplementingLinq.Tests
{
    public class RangeTests
    {
        /// <summary>
        /// Verify that Range when called with negative count parameter should throws an exception.
        /// </summary>
        [Fact]
        public void VerifyRangeWhenNegativeCountParameterShouldThrowsException()
        { 
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(0, -1));
        }

        /// <summary>
        /// Verify that Range when called with count or start too big parameter should throws an exception.
        /// </summary>
        [Fact]
        public void VerifyRangeWhenCalledWithBigParametersShouldThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(2, int.MaxValue));
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(int.MaxValue, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(int.MaxValue / 2, int.MaxValue / 2 + 3));

        }

        /// <summary>
        /// Verify when Range operator is called with single value of max int32 should have correct result. 
        /// </summary>
        [Fact]
        public void VerifyRangeWhenSingleValueOfMaxInt32ShouldBeValid()
        {
            var result = Enumerable.Range(int.MaxValue, 1);
            Assert.Equal(new Collection<int> {Int32.MaxValue }, result);
        }

        /// <summary>
        /// Verify that Range operator when called with empty count starting at min int32 should produce correct result.
        /// </summary>
        [Fact]
        public void VerifyRangeWhenEmptyCountStartingAtMinInt32ShouldBeValid()
        {
            var result = Enumerable.Range(int.MinValue, 0);
            Assert.Equal(new Collection<int>(), result);
        }

        /// <summary>
        /// Verify the edge cases for input parameters.
        /// </summary>
        [Fact]
        public void VerifyRangeWhenParametersAreHugeButStillValid()
        {
            // The edge cases.
            Enumerable.Range(int.MaxValue, 1);
            Enumerable.Range(1, int.MaxValue);
            Enumerable.Range(int.MaxValue / 2, int.MaxValue / 2 + 2);
        }

        /// <summary>
        /// Verify that Range operator when count=0 and start=0 should returns empty collection.
        /// </summary>
        [Fact]
        public void VerifyRangeWhen_0_0_ShouldReturnsEmptyCollection()
        {
            var result = Enumerable.Range(0, 0);
            Assert.Equal(new Collection<int>(), result);
        }

        /// <summary>
        /// Verify Range with empty count should be valid.
        /// </summary>
        [Fact]
        public void VerifyRangeWithEmptyCountShouldBeValid()
        {
            var result = Enumerable.Range(101, 0);
            Assert.Equal(new Collection<int>(), result);
        }

        /// <summary>
        /// Verify that Range should returns valid collection.
        /// </summary>
        [Fact]
        public void VerifyRangeShouldReturnsValidCollection()
        {
            var result = Enumerable.Range(1, 10);
            Assert.Equal(new Collection<int>{1, 2, 3, 4, 5, 6 ,7, 8, 9 ,10}, result);
        }

        /// <summary>
        /// Verify that Range with negative start should produce valid result.
        /// </summary>
        [Fact]
        public void VerifyRangeWithNegativeStartShouldBeValid()
        {
            var result = Enumerable.Range(-101, 1);
            Assert.Equal(new Collection<int>{ -101 }, result);
        }
    }
}
