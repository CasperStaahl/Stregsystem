using System;
using Stregsystem.Model.Shared;

namespace Stregsystem.Model.Users
{
    public interface IUser
    {
        int Id { get; }
        Username Username { get; }
        Ddk Balance { get; set; }

        event EventHandler<EventArgs> BelowBalanceThreshold;

        int CompareTo(User other);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}
