using BerlinClock.Models;
using System.Text;

namespace BerlinClock.Renderers
{
    public interface IBerlinClockRowRenderer
    {
        string Render(BerlinClockRendererRequest request);
    }

    public class BerlinClockRowRenderer : IBerlinClockRowRenderer
    {
        private const char TurnedOffLampSign = 'O';

        public string Render(BerlinClockRendererRequest request)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(request.TurnedOnLampSign, request.AmountOfTurnedOnLamps);
            stringBuilder.Append(TurnedOffLampSign, request.AmountOfTurnedOffLamps);

            var row = stringBuilder.ToString();
            return request.AdditionalFormatting != null
                ? request.AdditionalFormatting(row) : row;
        }
    }
}
