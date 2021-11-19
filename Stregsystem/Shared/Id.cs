using System.Collections.Generic;
using System.Linq;

namespace Stregsystem.Shared
{
    public class Id<T>
    {
        private static List<int> _activeIds = new();

        private int _number;

        public int Number
        {
            get => _number;
            private set
            {
                if (!_activeIds.Contains(value))
                {
                    _number = value;
                    _activeIds.Add(_number);
                }
                else
                {
                    throw new System.ArgumentException("Id has allready been used");
                }
            }
        }

        public Id(int number)
        {
            Number = number;
        }

        public Id()
        {
            try
            {
                Number = _activeIds.Max() + 1;
            }
            catch (System.InvalidOperationException)
            {
                Number = 1;
            }
        }
    }
}