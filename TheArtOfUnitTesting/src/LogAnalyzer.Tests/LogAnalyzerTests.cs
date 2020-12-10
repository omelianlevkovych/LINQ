using System;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using LogAnalyzer = TheArtOfUnitTesting.LogAnalyzer;

namespace LogAnalyzer.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        // For some reason VS can not find the right namespace for the LogAnalyzer class.
        // For the learning purpose despite it is a bit annoying to put the namespace before each class I will proceed with the current approach.
        private TheArtOfUnitTesting.LogAnalyzer logAnalyzer;

        // Interesting why we do not use class constructor for this, probably will be explained in next chapter of the book.
        [SetUp]
        public void Setup()
        {
            logAnalyzer = new TheArtOfUnitTesting.LogAnalyzer();
        }

        [Test]
        public void VerifyIsValidLogFileNameGoodExtensionLowercaseReturnsTrue()
        {
            // arrange, act
            var result = logAnalyzer.IsValidLogFileName("whatever.slf");

            // assert
            Assert.IsTrue(result, "filename should be valid!");
        }

        [Test]
        public void VerifyIsValidLogFileNameGoodExtensionUppercaseReturnsTrue()
        {
            // arrange, act
            var result = logAnalyzer.IsValidLogFileName("whatever.SLF");

            // assert
            Assert.IsTrue(result, "filename should be valid!");
        }

        [Test]
        public void VerifyIsValidFileNameWithEmptyFileNameThrowsException()
        {
            // the exception we expect thrown from the IsValidFileName method
            var ex = Assert.Throws<ArgumentException>(() => logAnalyzer.IsValidLogFileName(string.Empty));

            // now we can test the exception itself
            Assert.That(ex.Message == "no filename provided!");
        }

        [Test]
        [Category("Fast tests")]
        public void VerifyIsValidLogFileNameValidTestReturnsTrue()
        {

        }

        [Test]
        public void VerifyIsValidFileNameWhenCalledChangesWasLastFileNameValid()
        {
            var analyzer = new TheArtOfUnitTesting.LogAnalyzer();

            analyzer.IsValidLogFileName("badname.foo");

            Assert.False(analyzer.WasLastFileNameValid);
        }

        // Ignore attribute should be used rarely
        [Ignore("there is a problem with this test")]
        public void VerifyIsValidFileNameIgnore()
        {

        }

        // I assume the NUnit use such approach to not inherit from IDisposable pattern.
        // Honestly, I do not like it for now, especially that setup will be called each time before new test.
        // The only benefit for this which I can see for now is that you can be sure you have no dependencies between tests.
        // However, I can see more elegant way of doing it.
        // Okay now in the end of the chapter I can see the suggestion: Don't use [SetUp] and [TearDown] because they
        // make tests less understandable.
        [TearDown]
        public void TearDown()
        {
            logAnalyzer = null;
        }
    }
}
