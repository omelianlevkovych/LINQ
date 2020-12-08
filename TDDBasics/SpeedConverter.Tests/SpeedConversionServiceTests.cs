using System;
using Xunit;

namespace SpeedConverter.Tests
{
    public class SpeedConversionServiceTests
    {
        [Fact]
        public void ConvertToMilesPerHour_0_0()
        {
            // arrange
            var speedConverter = new SpeedConversionService();

            // act
            var milesPerHour = speedConverter.ConvertToMilesPerHour(0);

            //
            Assert.Equal(0, milesPerHour);
        }
    }
}
