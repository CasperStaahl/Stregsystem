using System.Collections.Generic;
using System.Linq;

namespace Stregsystem.Shared
{
    public interface IIdProvider<T>
    {
        public int GetNextId();
        public int TryGetId(int getThis);
    }
}