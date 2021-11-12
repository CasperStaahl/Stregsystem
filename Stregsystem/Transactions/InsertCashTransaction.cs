﻿using src.Users;
using Stregsystem.Shared;
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

        public InsertCashTransaction(User user, DateTime date, Ddk amount) : base(user, amount) { }
    }
}