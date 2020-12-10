using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAnalyzer.Tests
{
    [TestFixture]
    public class SumCalculatorTests
    {
        [Test]
        public void VerifySumByDefaultReturnsZero()
        {
            var calculator = MakeCalculator();

            int lastSum = calculator.Sum();

            Assert.AreEqual(0, lastSum);
        }

        [Test]
        public void VerifyAddWhenCalledChangeSum()
        {
            var calculator = MakeCalculator();

            calculator.Add(1);

            int lastSum = calculator.Sum();

            Assert.AreEqual(1, lastSum);
        }

        // factory method to initialize MemCalculator.
        // In case the constructor for the MemCalculator will be changed, the only place which should be updated.
        private static MemCalculator MakeCalculator()
        {
            return new MemCalculator();
        }
    }
}
