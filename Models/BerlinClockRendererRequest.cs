using System;

namespace BerlinClock.Models
{
    public class BerlinClockRendererRequest
    {
        public int AmountOfTurnedOnLamps { get; set; }
        public int AmountOfTurnedOffLamps { get; set; }
        public char TurnedOnLampSign { get; set; }
        public Func<string, string> AdditionalFormatting { get; set; }
    }
}
