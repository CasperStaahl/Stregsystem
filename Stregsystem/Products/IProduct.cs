using Stregsystem.Shared;

namespace Stregsystem.Products
{
    public interface IProduct
    {
        bool IsActive { get; set; }
        bool CanBeBoughtOnCredit { get; set; }
        Ddk Price { get; }
        IId<IProduct> Id { get; }

        string ToString();
    }
}