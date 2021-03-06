using System;
using System.Net.Mail;
using Stregsystem.Model.Shared;

namespace Stregsystem.Model.Users
{
    public class User : IComparable<User>, IUser
    {
        public event EventHandler<EventArgs> BelowBalanceThreshold;

        private static Ddk _balanceThreshold = new Ddk(50);

        public int Id { get => _id; }

        public Username Username { get => _userName; }

        public Ddk Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                if (_balance < _balanceThreshold)
                    OnBelowBalanceThreshold(EventArgs.Empty);
            }
        }

        private int _id;

        private Name _firstName;

        private Name _lastName;

        private MailAddress _email = new MailAddress("nil@nil");

        private Username _userName;

        private Ddk _balance = new Ddk(0);

        public override string ToString()
        {
            return $"{_firstName.String} {_lastName.String} ({_email.Address}) BALANCE : {_balance}";
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
            return _id;
        }

        public int CompareTo(User other)
        {
            return Id.CompareTo(other.Id);
        }

        protected virtual void OnBelowBalanceThreshold(EventArgs e)
        {
            EventHandler<EventArgs> handler = BelowBalanceThreshold;
            handler?.Invoke(this, e);
        }

        public User(int id, IIdProvider idprovider, Name firstName, Name lastName, Username username, Ddk balance, MailAddress email)
        {
            _id = idprovider.TryGetId(id);
            _userName = username;
            _firstName = firstName;
            _lastName = lastName;
            _balance = balance;
            _email = email;
        }
    }
}
