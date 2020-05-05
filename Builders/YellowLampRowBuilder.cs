using BerlinClock.Extensions;
using BerlinClock.Models;

namespace BerlinClock.Builders
{
    public interface IYellowLampRowBuilder
    {
        char Build(Time time);
    }

    public class YellowLampRowBuilder : IYellowLampRowBuilder
    {
        private const char LampOnSign = 'Y';
        private const char LampOffSign = 'O';

        public char Build(Time time)
        {
            return time.Second.IsEven() 
                ? LampOnSign 
                : LampOffSign;
        }
    }
}
