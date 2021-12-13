using Stregsystem.Shared;

namespace StregsystemTests.Fakes
{
    public class FakeIdProvider<T> : IIdProvider<T>
    {
        public int GetNextId()
        {
            return 0;
        }

        public int TryGetId(int getThis)
        {
            return getThis;
        }
    }

}