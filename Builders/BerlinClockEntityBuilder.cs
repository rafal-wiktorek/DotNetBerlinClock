using BerlinClock.Models;

namespace BerlinClock.Builders
{
    public interface IBerlinClockEntityBuilder
    {
        BerlinClockEntity Build(Time time);
    }

    public class BerlinClockEntityBuilder : IBerlinClockEntityBuilder
    {
        private readonly IHourRowsBuilder _hourRowsBuilder;
        private readonly IMinuteRowsBuilder _minuteRowsBuilder;
        private readonly IYellowLampRowBuilder _yellowLampRowBuilder;

        public BerlinClockEntityBuilder() : this(new HourRowsBuilder(), new MinuteRowsBuilder(),
            new YellowLampRowBuilder())
        {

        }

        public BerlinClockEntityBuilder(IHourRowsBuilder hourRowsBuilder, IMinuteRowsBuilder minuteRowsBuilder,
            IYellowLampRowBuilder yellowLampRowBuilder)
        {
            _hourRowsBuilder = hourRowsBuilder;
            _minuteRowsBuilder = minuteRowsBuilder;
            _yellowLampRowBuilder = yellowLampRowBuilder;
        }

        public BerlinClockEntity Build(Time time)
        {
            var hourRows = _hourRowsBuilder.Build(time);
            var minuteRows = _minuteRowsBuilder.Build(time);
            var yellowLampRow = _yellowLampRowBuilder.Build(time);

            return new BerlinClockEntity
            {
                YellowLampRow = yellowLampRow,
                FirstHoursRow = hourRows.FirstRow,
                SecondHoursRow = hourRows.SecondRow,
                FirstMinutesRow = minuteRows.FirstRow,
                SecondMinutesRow = minuteRows.SecondRow
            };
        }
    }
}
