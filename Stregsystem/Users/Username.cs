using System;
using System.Text.RegularExpressions;

namespace Stregsystem.Users
{
    public class Username
    {
        private static readonly Regex _validator = new Regex(@"^([a-z0-9_])+$");

        public string String
        {
            private get { return _string; }
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

        public override string ToString()
        {
            return _string;
        }
    }
}
