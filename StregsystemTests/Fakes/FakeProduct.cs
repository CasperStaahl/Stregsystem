using Stregsystem.Products;
using Stregsystem.Shared;

namespace StregsystemTests.Fakes
{
    public class FakeProduct : IProduct
    {
        public bool IsActive { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Ddk Price { get; set; }

        public IId<IProduct> Id => new FakeId<IProduct>();
    }
}