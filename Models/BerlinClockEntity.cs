using System;

namespace BerlinClock.Models
{
    public class BerlinClockEntity
    {
        public char YellowLampSign { get; set; }
        public string FirstHoursRow { get; set; }
        public string SecondHoursRow { get; set; }
        public string FirstMinutesRow { get; set; }
        public string SecondMinutesRow { get; set; }

        public override string ToString()
        {               
            return string.Join(Environment.NewLine, YellowLampSign, 
                FirstHoursRow, SecondHoursRow, 
                FirstMinutesRow, SecondMinutesRow);
        }
    }
}
