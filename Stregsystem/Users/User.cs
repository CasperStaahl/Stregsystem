﻿using System;
using System.Net.Mail;
using src.Shared;
using Stregsystem.Shared;

namespace src.Users
{
    public class User : IComparable<User>
    {
        public event EventHandler BelowBalanceThreshold;

        private static Ddk _balanceThreshold = new Ddk(50);

        public Id<User> Id { get => _id; }

        // public Name FirstName { get => _firstName; }

        // public Name LastName { get => _lastName; }

        // public MailAddress Email { get => _email; }

        // public Username Username { get => _userName; }

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

        private Id<User> _id = new Id<User>();

        private Name _firstName = new Name();

        private Name _lastName = new Name();

        private MailAddress _email = new MailAddress("nil@nil");

        private Username _userName = new Username();

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

        public User(Name firstName, Name lastName, MailAddress email, Username username)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }
    }
}