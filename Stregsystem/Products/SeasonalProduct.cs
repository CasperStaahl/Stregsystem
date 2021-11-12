using System;
using src.Shared;

namespace src.Products
{
    internal class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate
        {
            get => _seasonStartDate;
            private set
            {
                if (value < _seasonEndDate)
                {
                    _seasonStartDate = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public DateTime SeasonEndDate
        {
            get => SeasonEndDate;
            private set
            {
                if (_seasonStartDate < value)
                {
                    _seasonEndDate = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private DateTime _seasonStartDate = new DateTime();
        private DateTime _seasonEndDate = new DateTime();

        public SeasonalProduct(Name name, DDK price, bool active, bool canBeBoughtOnCredit,
        DateTime seasonStartDate, DateTime seasonEndDate)
        : base(name, price, active, canBeBoughtOnCredit)
        {
            _seasonStartDate = seasonStartDate;
            _seasonEndDate = seasonEndDate;
        }
    }
}
