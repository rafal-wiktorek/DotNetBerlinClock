using BerlinClock.Builders;
using BerlinClock.Parsers;

namespace BerlinClock.Converters
{
    public interface ITimeConverter
    {
        string ConvertTime(string aTime);
    }

    public class TimeConverter : ITimeConverter
    {
        private readonly IBerlinClockEntityBuilder _berlinClockEntityBuilder;
        private readonly ITimeParser _timeParser;

        public TimeConverter() : this(new BerlinClockEntityBuilder(), new TimeParser())
        {

        }

        public TimeConverter(IBerlinClockEntityBuilder berlinClockEntityBuilder, ITimeParser timeParser)
        {
            _berlinClockEntityBuilder = berlinClockEntityBuilder;
            _timeParser = timeParser;
        }

        public string ConvertTime(string aTime)
        {
            var time = _timeParser.Parse(aTime);
            var berlinClockEntity = _berlinClockEntityBuilder.Build(time);
            return berlinClockEntity.ToString();
        }
    }
}
