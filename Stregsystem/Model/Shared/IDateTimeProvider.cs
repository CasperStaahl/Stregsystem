using System;

namespace Stregsystem.Model.Shared
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}