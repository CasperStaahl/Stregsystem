using System;

namespace Stregsystem.Shared
{
    public class DDK
    {
        public uint Kroner { get; set; }
        public uint Oere { get; set; }

        public override string ToString()
        {
            switch (Oere)
            {
                case < 9:
                    return Kroner.ToString() + "." + Oere.ToString();
                case >= 0:
                    return Kroner.ToString() + "." + "0" + Oere.ToString();
                default:
                    throw new FormatException();
            }
        }

        public static bool operator <(DDK a, DDK b)
        {
            if (a.Kroner < b.Kroner)
                return true;
            else if (a.Oere < b.Oere)
                return true;
            else
                return false;
        }

        public static bool operator >(DDK a, DDK b)
        {
            if (a.Kroner > b.Kroner)
                return true;
            else if (a.Oere > b.Oere)
                return true;
            else
                return false;
        }

        public DDK(uint kroner, uint oere)
        {
            if (99 < oere)
                throw new ArgumentException();

            Kroner = kroner;
            Oere = oere;
        }
    }
}
