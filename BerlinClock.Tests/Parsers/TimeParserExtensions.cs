using BerlinClock.Parsers;
using NUnit.Framework;
using System;

namespace BerlinClock.Tests.Parsers
{
    [TestFixture]
    public class TimeParserExtensions
    {
        private TimeParser _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new TimeParser();
        }

        [Test]
        public void Parse_ShouldThrowException_WhenGivenValueIsNull()
        {
            Assert.Throws<Exception>(() => _sut.Parse(null));
        }

        [Test]
        public void Parse_ShouldThrowException_WhenWrongTimeFormatIsGiven()
        {
            var wrongTime = "123400";

            Assert.Throws<Exception>(() => _sut.Parse(wrongTime));
        }

        [Test]
        public void Parse_ShouldCreateCorrectInstance_WhenCorrectTimeIsGiven()
        {
            var hour = 12;
            var minute = 45;
            var second = 30;
            var timeValue = $"{hour}:{minute}:{second}";

            var result = _sut.Parse(timeValue);

            Assert.That(result.Hour, Is.EqualTo(hour));
            Assert.That(result.Minute, Is.EqualTo(minute));
            Assert.That(result.Second, Is.EqualTo(second));
        }
    }
}
