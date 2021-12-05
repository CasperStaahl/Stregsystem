using Stregsystem.Shared;

namespace Stregsystem.Products
{
    public class Product
    {
        public virtual bool IsActive { get; set; }

        public bool CanBeBoughtOnCredit { get; set;}

        public Ddk Price { get => _price; }

        public Id<Product> Id { get => _id; }

        private Id<Product> _id;

        private Name _name;

        private Ddk _price = new Ddk(0);

        public override string ToString()
        {
            return _id.Number + " " + _name.String + " " + _price.ToString();
        }

        public Product(int id, Name name, Ddk price, bool isActive, bool canBeBoughtOnCredit)
        {
            _id = new Id<Product>(id);
            _name = name;
            _price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
    }
}