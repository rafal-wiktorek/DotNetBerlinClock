using BerlinClock.Extensions;
using BerlinClock.Models;
using BerlinClock.Renderers;
using System;

namespace BerlinClock.Builders
{
    public interface IMinuteRowsBuilder : IBerlinClockRowsBuilder
    {

    }

    public class MinuteRowsBuilder : BerlinClockRowsBuilderBase, IMinuteRowsBuilder
    {
        private const char QuarterSign = 'R';

        public MinuteRowsBuilder() : this(new BerlinClockRowRenderer())
        {

        }

        public MinuteRowsBuilder(IBerlinClockRowRenderer berlinClockRowRenderer) : base(berlinClockRowRenderer)
        {
        }

        protected override int FirstRowLampsAmount => 11;
        protected override int FirstRowLampsValue => 5;
        protected override int SecondRowLampsAmount => 4;
        protected override int SecondRowLampsValue => 1;
        protected override char TurnedOnLampSign => 'Y';
        protected override int ExtractTimePart(Time time)
        {
            return time.Minute;
        }

        protected override Func<string, string> FirstRowAdditionalFormatting => (row) =>
        {
            var n = 3;
            return row.ReplaceEveryNthOccurence(TurnedOnLampSign, QuarterSign, n);
        };
    }
}
