using System;
using Stregsystem.DateTimeProvider;
using Stregsystem.Shared;

namespace Stregsystem.Products
{
    public class SeasonalProduct : Product
    {
        public override bool IsActive
        {
            get
            {
                return _isActive
                       && SeasonStartDate <= _dateTimeProvider.Now
                       && _dateTimeProvider.Now <= SeasonEndDate;
            }
            set => _isActive = value;
        }

        private DateTime SeasonStartDate
        {
            get => _seasonStartDate;
            set
            {
                if (value < _seasonEndDate)
                    _seasonStartDate = value;
                else
                    throw new ArgumentException();
            }
        }

        private DateTime SeasonEndDate
        {
            get => _seasonEndDate;
            set
            {
                if (_seasonStartDate < value)
                    _seasonEndDate = value;
                else
                    throw new ArgumentException();
            }
        }

        private bool _isActive;

        private IDateTimeProvider _dateTimeProvider;

        private DateTime _seasonStartDate;
        private DateTime _seasonEndDate;

        public SeasonalProduct(int id, 
                               IIdProvider idProvider, 
                               Name name, 
                               Ddk price, 
                               bool active, 
                               bool canBeBoughtOnCredit,
                               DateTime seasonStartDate, 
                               DateTime seasonEndDate, 
                               IDateTimeProvider dateTimeProvider)
                               : base(id, idProvider, name, price, active, canBeBoughtOnCredit)
        {
            _seasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
            _dateTimeProvider = dateTimeProvider;
        }
    }
}
