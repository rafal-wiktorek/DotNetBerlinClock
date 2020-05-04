using BerlinClock.Extensions;
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

        public BerlinClockEntityBuilder() : this(new HourRowsBuilder(), new MinuteRowsBuilder())
        {

        }

        public BerlinClockEntityBuilder(IHourRowsBuilder hourRowsBuilder, IMinuteRowsBuilder minuteRowsBuilder)
        {
            _hourRowsBuilder = hourRowsBuilder;
            _minuteRowsBuilder = minuteRowsBuilder;
        }

        public BerlinClockEntity Build(Time time)
        {
            var hourRows = _hourRowsBuilder.Build(time);
            var minuteRows = _minuteRowsBuilder.Build(time);

            return new BerlinClockEntity
            {
                YellowLampSign = time.Second.IsEven() ? 'Y' : 'O',
                FirstHoursRow = hourRows.FirstRow,
                SecondHoursRow = hourRows.SecondRow,
                FirstMinutesRow = minuteRows.FirstRow,
                SecondMinutesRow = minuteRows.SecondRow
            };
        }
    }
}
