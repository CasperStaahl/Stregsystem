﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class User : IComparable<User>
    {
        public event EventHandler BelowBalanceThreshold;

        private static int _nextId = 1;

        private static DDK _balanceThreshold = new DDK(50, 0);

        public int Id { get => _id; }

        public Name FirstName { get => _firstName; }

        public Name LastName { get => _lastName; }

        public MailAddress Email { get => _email; }

        public Username Username { get => _userName; }

        public DDK Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                if(_balance < _balanceThreshold)
                    OnBelowBalanceThreshold(new EventArgs());
            }
        }

        private int _id = _nextId++;

        private Name _firstName = new Name();

        private Name _lastName = new Name();

        private MailAddress _email = new MailAddress("nil@nil");

        private Username _userName = new Username();

        private DDK _balance = new DDK(0, 0);

        public override string ToString()
        {
            return _firstName.String + " " + _lastName.String + "(" + _email.Address + ")";
        }

        public override bool Equals(object obj)
        {
            User other = obj as User;
            if (other == null)
                return false;

            if (this.GetHashCode() != other.GetHashCode())
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return _id;
        }

        public int CompareTo(User other)
        {
            return this.Id.CompareTo(other.Id);
        }

        protected virtual void OnBelowBalanceThreshold(EventArgs e)
        {
            EventHandler handler = BelowBalanceThreshold;
            handler?.Invoke(this, e);
        }

        public User(Name firstName, Name lastName, MailAddress email, Username username)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }
    }
}
