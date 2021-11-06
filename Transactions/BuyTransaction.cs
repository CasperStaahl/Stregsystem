using System;
using Stregsystem.Shared;
using Stregsystem.Users;
using Stregsystem.Products;

namespace Stregsystem.Transactions
{
    internal class BuyTransaction : Transaction
    {
        private Product _product;

        public override void Execute()
        {
            base.Execute();
            DDK userProxyBalance = _user.Balance;
            userProxyBalance = userProxyBalance - _amount;  

            if (userProxyBalance < new DDK(0) && _product is not SeasonalProduct)
            {
                throw new Exception(); // TODO this should be InsufficientCredistException
            }
            else
            {
                _user.Balance = _user.Balance - _amount; 
            }
        }

        public override string ToString()
        {
            return $"Buy {_product.ToString()}: {base.ToString()}";
        }

        public BuyTransaction(User user, Product product) : base(user, product.Price)
        {
            _product = product;
            _product = product;
        }
    }
}