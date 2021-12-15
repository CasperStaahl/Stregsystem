using System;

namespace Stregsystem.Model.Shared
{
    public class Name
    {
        public string String
        {
            get { return _string; }
            private set
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

        public Name(string nameString)
        {
            String = nameString;
        }
    }
}
