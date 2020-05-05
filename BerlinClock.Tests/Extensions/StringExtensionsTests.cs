using BerlinClock.Extensions;
using NUnit.Framework;

namespace BerlinClock.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        private string _value;
        private char _valueToReplace;
        private char _newValue;

        [SetUp]
        public void SetUp()
        {
            _value = "OOOOOOO";
            _valueToReplace = 'O';
            _newValue = 'X';
        }

        [TestCase(null)]
        [TestCase("")]
        public void ReplaceEveryNthOccurence_ShouldReturnSameValue_WhenNullOrEmptyStringIsGiven(string value)
        {
            var result = value.ReplaceEveryNthOccurence(_valueToReplace, _newValue, 1);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void ReplaceEveryNthOccurence_ShouldNotReplaceAnyValue_WhenNValueIsOutOfRange()
        {
            var outOfRangeNValue = _value.Length + 1;

            var result = _value.ReplaceEveryNthOccurence(_valueToReplace, _newValue, outOfRangeNValue);

            Assert.That(result, Is.EqualTo(_value));
        }

        [Test]
        public void ReplaceEveryNthOccurence_ShouldReplaceEvery3thOccurence_WhenValueOccurred()
        {
            var value = "OOROOOOOO";
            var expectedValue = "OOROOXOOX";
            var n = 3;

            var result = value.ReplaceEveryNthOccurence(_valueToReplace, _newValue, n);

            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}
