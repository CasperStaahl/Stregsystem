using System;
using Stregsystem.Model.Shared;
using Stregsystem.Model.Users;

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