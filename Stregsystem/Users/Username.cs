using System;
using System.Text.RegularExpressions;

namespace src.Users
{
    public class Username
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
}
