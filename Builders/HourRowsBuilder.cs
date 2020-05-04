using BerlinClock.Models;
using BerlinClock.Renderers;

namespace BerlinClock.Builders
{
    public interface IHourRowsBuilder : IBerlinClockRowsBuilder
    {

    }

    public class HourRowsBuilder : BerlinClockRowsBuilderBase, IHourRowsBuilder
    {
        public HourRowsBuilder() : this(new BerlinClockRowRenderer())
        {

        }
        public HourRowsBuilder(IBerlinClockRowRenderer berlinClockRowRenderer) : base(berlinClockRowRenderer)
        {
        }

        protected override char TurnedOnLampSign => 'R';
        protected override int FirstRowLampsAmount => 4;
        protected override int FirstRowLampsValue => 5;
        protected override int SecondRowLampsAmount => 4;
        protected override int SecondRowLampsValue => 1;
        protected override int ExtractTimePart(Time time)
        {
            return time.Hour;
        }
    }
}
