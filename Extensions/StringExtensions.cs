using System;
using System.Linq;

namespace BerlinClock.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceEveryNthOccurence(this string value, char valueToReplace, char newValue, int n)
        {
            var chars = value.Select((val, index) => 
                val == valueToReplace && (index + 1) % n == 0 ? newValue : val);

            return new string(chars.ToArray());
        }
    }
}
