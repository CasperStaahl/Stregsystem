using System;

namespace Stregsystem.Shared
{
    public struct Ddk
    {
        private int _oere;

        public override string ToString()
        {
            return $"{(double)_oere / 100} DDK";
        }

        public override bool Equals(object obj)
        {
            return obj is Ddk ddk &&
                   _oere == ddk._oere;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_oere);
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

        public static bool operator ==(Ddk a, Ddk b)
        {
            return a._oere == b._oere; 
        }

        public static bool operator !=(Ddk a, Ddk b)
        {
            return a._oere != b._oere; 
        }

        public Ddk(int oere)
        {
            _oere = oere;
        }
    }
}
