using System;

namespace Stregsystem.Shared
{
    public class DDK
    {
        protected decimal _numericValue = 0;

        public override string ToString()
        {
            return $"{_numericValue.ToString()} DDK";
        }

        public static bool operator <(DDK a, DDK b)
        {
            return a._numericValue < b._numericValue;
        }

        public static bool operator >(DDK a, DDK b)
        {
            return a._numericValue > b._numericValue;
        }

        public static DDK operator +(DDK a, DDK b)
        {
            decimal newNumericValue = a._numericValue + b._numericValue;
            return new DDK(newNumericValue);
        }

        public static DDK operator -(DDK a, DDK b)
        {
            decimal newNumericValue = a._numericValue - b._numericValue;
            return new DDK(newNumericValue);
        }

        public DDK(decimal numericValue)
        {
            _numericValue = numericValue;
        }
    }
}
