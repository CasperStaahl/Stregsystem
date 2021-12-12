using System;
using Stregsystem.Shared;

namespace Stregsystem.Users
{
    public interface IUser
    {
        IId<IUser> Id { get; }
        Username Username { get; }
        Ddk Balance { get; set; }

        event EventHandler BelowBalanceThreshold;

        int CompareTo(User other);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}
