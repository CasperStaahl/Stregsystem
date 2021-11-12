using System;
using src.Products;
using src.Shared;
using src.Users;

namespace src.Transactions
{
    internal class BuyTransaction : Transaction
    {
        private Product _product;

        public BuyTransaction(User user, Product product) : base(user, product.Price)
        {
            _product = product;
            _product = product;
        }

        public override void Execute()
        {
            if (TransactionIsLegal())
            {
                _user.Balance = _user.Balance - _amount;
                base.Execute();
            }
            else if (!_product.IsActive)
            {
                throw new ProductIsNotActiveException($"{_product.ToString()} is not Active");
            }
            else if (!_product.CanBeBoughtOnCredit)
            {
                throw new InsufficientCredistException($"{_user.ToString()} does not have enough credit to buy {_product.ToString()}");
            }
            else
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return $"Buy {_product.ToString()}: {base.ToString()}";
        }

        private bool TransactionIsLegal()
        {
            DDK userProxyBalance = _user.Balance;
            userProxyBalance = userProxyBalance - _amount;
            bool baseTransactionIsLegal = _product.IsActive && (new DDK(0) <= userProxyBalance || _product.CanBeBoughtOnCredit);

            if (_product is not SeasonalProduct)
            {
                return baseTransactionIsLegal;
            }
            else if (_product is SeasonalProduct)
            {
                SeasonalProduct product = _product as SeasonalProduct;
                return baseTransactionIsLegal && product.SeasonStartDate < DateTime.Now && DateTime.Now < product.SeasonEndDate;
            }
            else
            {
                throw new Exception();
            }
        }

    }
}