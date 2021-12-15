using System;

namespace Stregsystem.Model.Shared
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now { get => DateTime.Now; }
    }
}