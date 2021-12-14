using System.Collections.Generic;
using Stregsystem.Shared;

namespace Stregsystem.Parsers
{
    public interface IParser<T>
    {
        IList<T> Parse(IEnumerable<string> lines, IIdProvider idProvider);
    }
}