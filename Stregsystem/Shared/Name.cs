using System;

namespace src.Shared
{
    public class Name
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
}
