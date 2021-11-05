using Stregsystem.Shared;

namespace Stregsystem.Product
{
    class Product
    {
        private Id _id = new Id();

        private Name _name = new Name();

        private DDK _price = new DDK(0, 0);

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