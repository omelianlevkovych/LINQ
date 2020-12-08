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

        [Fact]
        public void ConvertToMilesPerHour_10_6()
        {
            // arrange
            var speedConverter = new SpeedConversionService();

            // act
            var milesPerHour = speedConverter.ConvertToMilesPerHour(10);

            //
            Assert.Equal(6, milesPerHour);
        }
    }
}
