using System.Collections.Generic;
using System.Linq;

namespace Stregsystem.Shared
{
    public interface IIdProvider
    {
        public int GetNextId();
        public int TryGetId(int getThis);
    }
}