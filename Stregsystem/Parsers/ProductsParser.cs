using System;
using System.Collections.Generic;
using Stregsystem.Shared;
using Stregsystem.Products;
using System.Text.RegularExpressions;

namespace Stregsystem.Parsers
{
    public class ProductParser : IParser<IProduct>
    {
        public IList<IProduct> Parse(IEnumerable<string> lines, IIdProvider idProvider)
        {
            IList<IProduct> products = new List<IProduct>();

            foreach (string line in lines)
            {
                string[] subs = line.Split(';');

                string idString = subs[0];
                int id = Convert.ToInt32(idString);

                string nameString = subs[1];
                nameString = Regex.Replace(nameString, "<.*?>", string.Empty);
                nameString = nameString.Replace("\"", string.Empty);
                Name name = new Name(nameString);

                string priceString = subs[2];
                int priceInt = Convert.ToInt32(priceString);
                Ddk price = new Ddk(priceInt);

                string isActiveString = subs[3];
                int isActiveInt = Convert.ToInt32(isActiveString);
                bool isActive = Convert.ToBoolean(isActiveInt);

                Product product =
                    new Product(id, idProvider, name, price, isActive, false);
                products.Add(product);
            }

            return products;
        }
    }
}