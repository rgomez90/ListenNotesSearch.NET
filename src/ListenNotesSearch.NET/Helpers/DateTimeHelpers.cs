using System;

namespace ListenNotesSearch.NET.Helpers
{
    public class DateTimeHelpers
    {
        public static DateTime DateTimeFromUnixMiliseconds(double miliseconds)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(miliseconds);
        }
    }
}