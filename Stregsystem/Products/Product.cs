using Stregsystem.Shared;

namespace Stregsystem.Products
{
    public class Product
    {
        public Ddk Price { get => _price; }

        public Id<Product> Id { get => _id; }

        public bool IsActive { get => _IsActive; }

        public bool CanBeBoughtOnCredit { get => _canBeBoughtOnCredit; }

        private Id<Product> _id;

        private Name _name;

        private Ddk _price = new Ddk(0);

        private bool _IsActive = false;

        private bool _canBeBoughtOnCredit = false;

        public override string ToString()
        {
            return _id.Number + " " + _name.String + " " + _price.ToString();
        }

        public Product(int id, Name name, Ddk price, bool isActive, bool canBeBoughtOnCredit)
        {
            _id = new Id<Product>(id);
            _name = name;
            _price = price;
            _IsActive = isActive;
            _canBeBoughtOnCredit = canBeBoughtOnCredit;
        }
    }
}