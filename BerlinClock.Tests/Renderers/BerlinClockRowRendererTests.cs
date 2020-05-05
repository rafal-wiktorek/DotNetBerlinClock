using BerlinClock.Models;
using BerlinClock.Renderers;
using NUnit.Framework;
using System;

namespace BerlinClock.Tests.Renderers
{
    [TestFixture]
    public class BerlinClockRowRendererTests
    {
        private BerlinClockRowRenderer _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new BerlinClockRowRenderer();
        }

        [Test]
        public void Render_ShouldNotModifyResult_WhenAdditionalFormattingIsNull()
        {
            var expectedValue = "XO";
            var request = new BerlinClockRendererRequest
            {
                AdditionalFormatting = null,
                TurnedOnLampSign = 'X',
                AmountOfTurnedOnLamps = 1,
                AmountOfTurnedOffLamps = 1
            };

            var result = _sut.Render(request);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Render_ShouldModifyResult_WhenAdditionalFormattingIsGiven()
        {
            var expectedValue = "TEST";
            var request = new BerlinClockRendererRequest
            {
                AdditionalFormatting = (row) => expectedValue,
                TurnedOnLampSign = 'X',
                AmountOfTurnedOnLamps = 1,
                AmountOfTurnedOffLamps = 1
            };

            var result = _sut.Render(request);

            Assert.That(result, Is.EqualTo(expectedValue));
        }
        
        [Test]
        public void Render_ShouldThrowException_WhenNegativeTurnedOnLampsValueIsGiven()
        {
            var request = new BerlinClockRendererRequest
            {
                TurnedOnLampSign = 'X',
                AmountOfTurnedOnLamps = -1,
                AmountOfTurnedOffLamps = 1
            };

            Assert.Throws<Exception>(() => _sut.Render(request));
        }

        [Test]
        public void Render_ShouldThrowException_WhenNegativeTurnedOffLampsValueIsGiven()
        {
            var request = new BerlinClockRendererRequest
            {
                TurnedOnLampSign = 'X',
                AmountOfTurnedOnLamps = 1,
                AmountOfTurnedOffLamps = -1
            };

            Assert.Throws<Exception>(() => _sut.Render(request));
        }
    }
}
