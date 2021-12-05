﻿using Stregsystem.Shared;
using Stregsystem.Users;
using System;

namespace Stregsystem.Transactions
{
    internal class InsertCashTransaction : Transaction
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

        public InsertCashTransaction(User user, Ddk amount) : base(user, amount) { }
    }
}
