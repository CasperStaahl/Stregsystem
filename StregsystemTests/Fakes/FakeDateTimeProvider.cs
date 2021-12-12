using System;
using Stregsystem.DateTimeProvider;

namespace StregsystemTests.Fakes
{
    class FakeDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now { get; private set;}

        public FakeDateTimeProvider(DateTime fakeNow)
        {
            Now = fakeNow; 
        }
    }
}