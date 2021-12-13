using System;
using Stregsystem.Shared;
using Stregsystem.Users;

namespace StregsystemTests.Fakes
{
    public class FakeUser : IUser
    {
        public int Id { get; set; }

        public Username Username { get; set; }

        public Ddk Balance { get; set; }

        public event EventHandler<EventArgs> BelowBalanceThreshold;

        public int CompareTo(User other)
        {
            return 1;
        }
    }
}