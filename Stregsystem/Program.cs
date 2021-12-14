using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Stregsystem.Loggers;
using Stregsystem.Parsers;
using Stregsystem.Products;
using Stregsystem.Shared;
using Stregsystem.Users;

namespace Stregsystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IParser<IProduct> productParser = new ProductParser();
            IList<IProduct> products = 
                productParser.Parse(File.ReadLines(@"../../../products.csv").Skip(1), new IdProvider());

            IParser<IUser> userParser = new UserParser();
            IList<IUser> users = 
                userParser.Parse(File.ReadLines(@"../../../users.csv").Skip(1), new IdProvider());

            IStregsystem stregsystem = new Stregsystem(products, users, new IdProvider(), new Logger());

            IStregsystemUI ui = new StregsystemCLI(stregsystem);
            StregsystemController sc = new StregsystemController(ui, stregsystem);

            ui.Start();
        }
    }
}
