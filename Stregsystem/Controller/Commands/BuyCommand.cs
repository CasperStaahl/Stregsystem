using System.Collections.Generic;
using System.Linq;
using Stregsystem.Model;
using Stregsystem.Model.Products;
using Stregsystem.Model.Transactions;
using Stregsystem.Model.Users;
using Stregsystem.View;

namespace Stregsystem.Controller.Commands
{
    public class BuyCommand : ICommand
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private Username _username;
        private IList<int> _productIdList;

        public BuyCommand(IStregsystem stregsystem, IStregsystemUI ui, Username username, IList<int> productIdList)
        {
            _stregsystem = stregsystem;
            _ui = ui;
            _username = username;
            _productIdList = productIdList;
        }

        public void Execute()
        {
            IUser user = _stregsystem.GetUserByUsername(_username);

            IEnumerable<IProduct> products = _productIdList.Select(id =>
                _stregsystem.GetProductById(id));

            foreach (Product product in products)
            {
                BuyTransaction transaction = _stregsystem.BuyProduct(user, product);
                _ui.DisplayUserBuysProduct(transaction);
            }

        }
    }
}