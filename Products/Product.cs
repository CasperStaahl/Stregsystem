using Stregsystem.Shared;

namespace Stregsystem.Products
{
    public class Product
    {
        public DDK Price { get => _price; }

        private Id<Product> _id = new Id<Product>();

        private Name _name = new Name();

        private DDK _price = new DDK(0);

        private bool _Active = false;

        private bool _canBeBoughtOnCredit = false;

        public override string ToString()
        {
            return _id + " " + _name.String + " " + _price.ToString();
        }

        public Product(Name name, DDK price, bool active, bool canBeBoughtOnCredit)
        {
            _name = name;
            _price = price;
            _Active = active;
            _canBeBoughtOnCredit = canBeBoughtOnCredit;
        }
    }
}