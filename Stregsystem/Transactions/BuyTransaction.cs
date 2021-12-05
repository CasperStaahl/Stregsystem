using System;
using src.Products;
using src.Transactions;
using Stregsystem.Products;
using Stregsystem.Shared;
using Stregsystem.Users;

namespace Stregsystem.Transactions
{
    internal class BuyTransaction : Transaction
    {
        private Product _product;

        public BuyTransaction(User user, Product product) : base(user, product.Price)
        {
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
                throw new InsufficientCredistException
                    ($"{_user.ToString()} does not have enough credit to buy {_product.ToString()}");
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
            Ddk userProxyBalance = _user.Balance;
            userProxyBalance = userProxyBalance - _amount;
            return _product.IsActive
                   && (new Ddk(0) <= userProxyBalance || _product.CanBeBoughtOnCredit);
        }
    }
}