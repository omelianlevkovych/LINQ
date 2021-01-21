using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ReimplementingLinq.Tests
{
    public class CountTests
    {
        /// <summary>
        /// Verify that Empty returned sequence is empty.
        /// </summary>
        [Fact (Skip = "takes some time")]
        public void VerifyCountShouldOverflow()
        {
            // arrange
            var veryLargSequence = Enumerable.Range(0, int.MaxValue)
                .Concat(Enumerable.Range(0, 1));

            // act, assert
            Assert.Throws<OverflowException>(() => veryLargSequence.Count());
        }
    }
}
