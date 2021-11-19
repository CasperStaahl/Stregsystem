using System;

namespace Stregsystem.Shared
{
    public class Ddk
    {
        protected int _oere;

        public override string ToString()
        {
            return $"{_oere / 100} DDK";
        }

        public static bool operator <(Ddk a, Ddk b)
        {
            return a._oere < b._oere;
        }

        public static bool operator >(Ddk a, Ddk b)
        {
            return a._oere > b._oere;
        }

        public static bool operator <=(Ddk a, Ddk b)
        {
            return a._oere <= b._oere;
        }

        public static bool operator >=(Ddk a, Ddk b)
        {
            return a._oere >= b._oere;
        }

        public static Ddk operator +(Ddk a, Ddk b)
        {
            int newNumericValue = a._oere + b._oere;
            return new Ddk(newNumericValue);
        }

        public static Ddk operator -(Ddk a, Ddk b)
        {
            int newNumericValue = a._oere - b._oere;
            return new Ddk(newNumericValue);
        }

        public Ddk(int oere)
        {
            _oere = oere;
        }
    }
}
