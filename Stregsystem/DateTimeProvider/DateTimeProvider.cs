using System;

namespace Stregsystem.DateTimeProvider
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now { get => DateTime.Now; }
    }
}