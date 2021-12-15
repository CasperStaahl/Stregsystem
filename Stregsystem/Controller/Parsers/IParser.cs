using System.Collections.Generic;
using Stregsystem.Model.Shared;

namespace Stregsystem.Controller.Parsers
{
    public interface IParser<T>
    {
        IList<T> Parse(IEnumerable<string> lines, IIdProvider idProvider);
    }
}