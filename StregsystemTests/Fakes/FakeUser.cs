using System;
using Stregsystem.Shared;
using Stregsystem.Users;

namespace StregsystemTests.Fakes
{
    public class FakeUser : IUser
    {
        public IId<IUser> Id => new FakeId<IUser>();

        public Username Username { get; set; } = new Username("stub");

        public Ddk Balance { get; set; } = new Ddk(0);

        public event EventHandler<EventArgs> BelowBalanceThreshold;

        public int CompareTo(User other) { return 1; }
    }
}