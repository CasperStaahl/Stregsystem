using Stregsystem.Shared;

namespace Stregsystem.Products
{

    public class Product : IProduct
    {
        public virtual bool IsActive { get; set; }

        public bool CanBeBoughtOnCredit { get; set; }

        public Ddk Price { get => _price; }

        public IId<IProduct> Id { get => _id; }

        private IId<IProduct> _id;

        private Name _name;

        private Ddk _price = new Ddk(0);

        public override string ToString()
        {
            return _id.Number + " " + _name.String + " " + _price.ToString();
        }

        public Product(IId<IProduct> id, Name name, Ddk price, bool isActive, bool canBeBoughtOnCredit)
        {
            _id = id;
            _name = name;
            _price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
    }
}