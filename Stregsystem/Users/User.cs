using System;
using System.Net.Mail;
using Stregsystem.Users;
using Stregsystem.Shared;

namespace Stregsystem.Users
{
    public class User : IComparable<User>
    {
        public event EventHandler BelowBalanceThreshold;

        private static Ddk _balanceThreshold = new Ddk(50);

        public Id<User> Id { get => _id; }

        // public Name FirstName { get => _firstName; }

        // public Name LastName { get => _lastName; }

        // public MailAddress Email { get => _email; }

        public Username Username { get => _userName; }

        public Ddk Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                if (_balance < _balanceThreshold)
                    OnBelowBalanceThreshold(new EventArgs());
            }
        }

        private Id<User> _id;

        private Name _firstName;

        private Name _lastName;

        private MailAddress _email = new MailAddress("nil@nil");

        private Username _userName;

        private Ddk _balance = new Ddk(0);

        public override string ToString()
        {
            return _firstName.String + " " + _lastName.String + "(" + _email.Address + ")";
        }

        public override bool Equals(object obj)
        {
            User other = obj as User;
            if (other == null)
                return false;

            if (GetHashCode() == other.GetHashCode())
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return _id.Number;
        }

        public int CompareTo(User other)
        {
            return Id.Number.CompareTo(other.Id.Number);
        }

        protected virtual void OnBelowBalanceThreshold(EventArgs e)
        {
            EventHandler handler = BelowBalanceThreshold;
            handler?.Invoke(this, e);
        }

        public User(Id<User> id, Name firstName, Name lastName, Username username, Ddk balance, MailAddress email)
        {
            _id = id;
            _userName = username;
            _firstName = firstName;
            _lastName = lastName;
            _balance = balance;
            _email = email;
        }
    }
}
