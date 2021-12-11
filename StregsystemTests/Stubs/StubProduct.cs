using Stregsystem.Products;
using Stregsystem.Shared;

namespace StregsystemTests.Stubs
{
    public class StubProduct : IProduct
    {
        public bool IsActive { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Ddk Price { get; set; }

        public IId<IProduct> Id => new StubId<IProduct>();
    }
}