using src.Shared;
using Stregsystem.Shared;

namespace src.Products
{
    public class Product
    {
        public Ddk Price { get => _price; }

        public bool IsActive { get => _IsActive; }

        public bool CanBeBoughtOnCredit { get => _canBeBoughtOnCredit; }

        private Id<Product> _id = new Id<Product>();

        private Name _name = new Name();

        private Ddk _price = new Ddk(0);

        private bool _IsActive = false;

        private bool _canBeBoughtOnCredit = false;

        public override string ToString()
        {
            return _id + " " + _name.String + " " + _price.ToString();
        }

        public Product(Name name, Ddk price, bool isActive, bool canBeBoughtOnCredit)
        {
            _name = name;
            _price = price;
            _IsActive = isActive;
            _canBeBoughtOnCredit = canBeBoughtOnCredit;
        }
    }
}