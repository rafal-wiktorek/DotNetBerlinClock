using BerlinClock.Models;
using System;

namespace BerlinClock.Parsers
{
    public interface ITimeParser
    {
        Time Parse(string time);
    }

    public class TimeParser : ITimeParser
    {
        public Time Parse(string time)
        {
            var timeParts = time.Split(':');
            if (timeParts.Length != 3)
                throw new Exception("Wrong time format");

            var hour = int.Parse(timeParts[0]);
            var minute = int.Parse(timeParts[1]);
            var second = int.Parse(timeParts[2]);

            return new Time(hour, minute, second);
        }
    }
}
