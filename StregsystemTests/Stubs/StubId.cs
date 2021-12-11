using Stregsystem.Shared;

namespace StregsystemTests.Stubs
{
    public class StubId<T> : IId<T>
    {
        public int Number => 1;
    }
}