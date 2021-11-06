using Stregsystem.Shared;
using Stregsystem.Users;
using System;

namespace Stregsystem.Transactions
{
    internal class InsertCashTransaction : Transaction
    {
        public override void Execute()
        {
            base.Execute();
           _user.Balance = _user.Balance + _amount; 
        }

        public override string ToString()
        {
            return $"Insert: {base.ToString()}";
        }

        public InsertCashTransaction(User user, DateTime date, DDK amount) : base(user, amount) { }
    }
}
