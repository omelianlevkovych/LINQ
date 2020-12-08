using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedConverter
{
    public class SpeedConversionService
    {
        public int ConvertToMilesPerHour(int kilometersPerHour)
        {
            return (int)Math.Round(kilometersPerHour * 0.62137);
        }
    }
}
