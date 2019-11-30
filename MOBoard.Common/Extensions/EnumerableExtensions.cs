using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOBoard.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static ReadOnlyCollection<T> ToReadOnly<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList().AsReadOnly();
        }
    }
}