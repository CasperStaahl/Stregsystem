using Stregsystem.Model.Products;
using Stregsystem.Model.Shared;

namespace StregsystemTests.Fakes
{
    public class FakeProduct : IProduct
    {
        public bool IsActive { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Ddk Price { get; set; }

        public int Id { get; set; }
    }
}