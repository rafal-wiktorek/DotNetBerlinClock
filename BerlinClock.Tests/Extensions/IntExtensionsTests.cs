using BerlinClock.Extensions;
using NUnit.Framework;

namespace BerlinClock.Tests.Extensions
{
    [TestFixture]
    public class IntExtensionsTests
    {
        [Test]
        public void IsEven_ShouldReturnTrue_WhenEvenNumberIsGiven()
        {
            var evenNumber = 2;

            var result = evenNumber.IsEven();

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsEven_ShouldReturnFalse_WhenOddNumberIsGiven()
        {
            var oddNumber = 3;

            var result = oddNumber.IsEven();

            Assert.That(result, Is.False);
        }
    }
}
