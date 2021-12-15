using Stregsystem.Model.Shared;

namespace StregsystemTests.Fakes
{
    public class FakeIdProvider : IIdProvider
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