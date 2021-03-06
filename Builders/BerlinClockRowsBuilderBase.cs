﻿using BerlinClock.Models;
using BerlinClock.Renderers;
using System;

namespace BerlinClock.Builders
{
    public interface IBerlinClockRowsBuilder
    {
        BerlinClockRows Build(Time time);
    }

    public abstract class BerlinClockRowsBuilderBase : IBerlinClockRowsBuilder
    {
        protected abstract int FirstRowLampsAmount { get; }
        protected abstract int FirstRowLampValue { get; }
        protected abstract int SecondRowLampsAmount { get; }
        protected abstract int SecondRowLampValue { get; }
        protected abstract char TurnedOnLampSign { get; }
        protected virtual Func<string, string> FirstRowAdditionalFormatting { get; }

        private readonly IBerlinClockRowRenderer _berlinClockRowRenderer;

        public BerlinClockRowsBuilderBase(IBerlinClockRowRenderer berlinClockRowRenderer)
        {
            _berlinClockRowRenderer = berlinClockRowRenderer;
        }

        public BerlinClockRows Build(Time time)
        {
            var timePart = ExtractTimePart(time);
            var amountOfTurnedOnLampsAtFirstRow = timePart / FirstRowLampValue;
            var amountOfTurnedOffLampsAtFirstRow = FirstRowLampsAmount - amountOfTurnedOnLampsAtFirstRow;

            var amountOfTurnedOnLampsAtSecondRow = (timePart - (amountOfTurnedOnLampsAtFirstRow * FirstRowLampValue)) / SecondRowLampValue;
            var amountOfTurnedOffLampsAtSecondRow = SecondRowLampsAmount - amountOfTurnedOnLampsAtSecondRow;

            return new BerlinClockRows
            {
                FirstRow = _berlinClockRowRenderer.Render(new BerlinClockRendererRequest
                {
                    AmountOfTurnedOnLamps = amountOfTurnedOnLampsAtFirstRow,
                    AmountOfTurnedOffLamps = amountOfTurnedOffLampsAtFirstRow,
                    TurnedOnLampSign = TurnedOnLampSign,
                    AdditionalFormatting = FirstRowAdditionalFormatting
                }),
                SecondRow = _berlinClockRowRenderer.Render(new BerlinClockRendererRequest
                {
                    AmountOfTurnedOnLamps = amountOfTurnedOnLampsAtSecondRow,
                    AmountOfTurnedOffLamps = amountOfTurnedOffLampsAtSecondRow,
                    TurnedOnLampSign = TurnedOnLampSign
                })
            };
        }

        protected abstract int ExtractTimePart(Time time);
    }
}
