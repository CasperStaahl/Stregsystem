using Stregsystem.Shared;

namespace StregsystemTests.Fakes
{
    public class FakeId<T> : IId<T>
    {
        public int Number { get; set; }

        public FakeId()
        {
            Number = 1;
        }

        public FakeId(int number)
        {
            Number = number;
        }
    }
}