using System;
using Stregsystem.Products;
using Stregsystem.Shared;

namespace src.Products
{
    internal class SeasonalProduct : Product
    {
        public override bool IsActive
        {
            get
            {
                return _isActive 
                       && SeasonStartDate <= DateTime.Now 
                       && DateTime.Now <= SeasonEndDate;
            }
            set => _isActive = value;
        }

        private DateTime SeasonStartDate
        {
            get => _seasonStartDate;
            set
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

        private DateTime SeasonEndDate
        {
            get => SeasonEndDate;
            set
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

        private bool _isActive;

        private DateTime _seasonStartDate = new DateTime();
        private DateTime _seasonEndDate = new DateTime();

        public SeasonalProduct(int id, Name name, Ddk price, bool active, bool canBeBoughtOnCredit,
        DateTime seasonStartDate, DateTime seasonEndDate)
        : base(id, name, price, active, canBeBoughtOnCredit)
        {
            _seasonStartDate = seasonStartDate;
            _seasonEndDate = seasonEndDate;
        }
    }
}
