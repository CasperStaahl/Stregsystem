using System;

namespace Stregsystem.Shared
{
    public class Ddk
    {
        protected decimal _numericValue = 0;

        public override string ToString()
        {
            return $"{_numericValue.ToString()} DDK";
        }

        public static bool operator <(Ddk a, Ddk b)
        {
            return a._numericValue < b._numericValue;
        }

        public static bool operator >(Ddk a, Ddk b)
        {
            return a._numericValue > b._numericValue;
        }

        public static bool operator <=(Ddk a, Ddk b)
        {
            return a._numericValue <= b._numericValue;
        }

        public static bool operator >=(Ddk a, Ddk b)
        {
            return a._numericValue >= b._numericValue;
        }

        public static Ddk operator +(Ddk a, Ddk b)
        {
            decimal newNumericValue = a._numericValue + b._numericValue;
            return new Ddk(newNumericValue);
        }

        public static Ddk operator -(Ddk a, Ddk b)
        {
            decimal newNumericValue = a._numericValue - b._numericValue;
            return new Ddk(newNumericValue);
        }

        public Ddk(decimal numericValue)
        {
            _numericValue = numericValue;
        }
    }
}
