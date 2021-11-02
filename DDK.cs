using System;

namespace User
{
    public class DDK
    {
        public uint Kroner { get; set; }
        public uint Oere { get; set; }
        
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
            if(9 < oere)
                throw new ArgumentException();

            Kroner = kroner;
            Oere = oere;
        }
    }
}
