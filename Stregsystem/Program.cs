using System;

namespace Stregsystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stregsystem stregsystem = new Stregsystem(
                @"../../../products.csv", 
                @"../../../users.csv");
        }
    }
}
