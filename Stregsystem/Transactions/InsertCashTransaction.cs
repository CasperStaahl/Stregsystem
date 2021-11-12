using src.Shared;
using src.Users;
using System;

namespace src.Transactions
{
    internal class InsertCashTransaction : Transaction
    {
        public override void Execute()
        {
            _user.Balance = _user.Balance + _amount;
            base.Execute();
        }

        public override string ToString()
        {
            return $"Insert: {base.ToString()}";
        }

        public InsertCashTransaction(User user, DateTime date, DDK amount) : base(user, amount) { }
    }
}
