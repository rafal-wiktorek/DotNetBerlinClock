using BerlinClock.Builders;
using BerlinClock.Models;
using NUnit.Framework;

namespace BerlinClock.Tests.Builders
{
    [TestFixture]
    public class YellowLampRowBuilderTests
    {
        private YellowLampRowBuilder _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new YellowLampRowBuilder();
        }

        [Test]
        public void Build_ShouldReturnDifferentResult_WhenOddAndEvenNumbersAreGiven()
        {
            var oddValue = 1;
            var evenValue = 2;

            var resultForOddValue = _sut.Build(new Time(0, 0, oddValue));
            var resultForEvenValue = _sut.Build(new Time(0, 0, evenValue));

            Assert.That(resultForEvenValue, Is.Not.EqualTo(resultForOddValue));
        }
    }
}
