using Stregsystem.Model.Shared;
using Stregsystem.Model.Users;
using System;

namespace Stregsystem.Model.Transactions
{
    public class InsertCashTransaction : Transaction
    {
        public override void Execute()
        {
            _user.Balance += _amount;
            base.Execute();
        }

        public override string ToString()
        {
            return $"Insert: {base.ToString()}";
        }

        public InsertCashTransaction(IUser user, Ddk amount, IIdProvider idProvider)
            : base(user, amount, idProvider) { }
    }
}
