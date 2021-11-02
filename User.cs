using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stregsystem
{
    internal class User
    {
        private class Name
        {
            public string String
            {
                get { return _string; }
                set
                {
                    if (value != null)
                    {
                        _string = value;
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
            }

            private string _string = "nil";
        }

        private class Username
        {
            private static readonly Regex _validator = new Regex(@"^([a-z0-9_])+$");

            public string String
            {
                get { return _string; }
                set
                {
                    if (_validator.IsMatch(value))
                    {
                        _string = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                }
            }

            private string _string = "nil";
        }

        public class DDK
        {
            private uint _kroner = 0;
            private uint _oere = 0;

            public void SetBalance(uint kroner, uint oere)
            {
                _kroner = kroner;
                _oere = oere;
            }

            public DDK(uint kroner, uint oere)
            {
                _kroner = kroner;
                _oere = oere;
            }
        }

        // public uint Id { get => _id; }
        // public string FirstName { get => _firstName.String; }
        // public string LastName { get => _lastName.String; }
        // public MailAddress Email { get => _email; }
        // public string UserUsername { get => _userName.String; }
        // public Balance UserBalance { get => _balance; }

        static int nextId = 1;

        private int _id = 0;

        private Name _firstName = new Name();

        private Name _lastName = new Name();

        private MailAddress _email = new MailAddress("nil@nil");

        private Username _userName = new Username();

        private DDK _balance = new DDK(0, 0);


        public override string ToString()
        {
            return _firstName.String + " " + _lastName.String;
        }

        public override bool Equals(object obj)
        {
            User that = obj as User;
            if (that == null)
                return false;

            if (this.GetHashCode() != that.GetHashCode())
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return _id;
        }

        public User(string firstName, string lastName, MailAddress email, string username)
        {
            _id = nextId++;
            _firstName.String = firstName;
            _lastName.String = lastName;
            _email = email;
        }
    }
}
