using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineCancellationApi.Extensions
{
    /// <summary>
    /// I give credit where credit is due see: https://exceptionnotfound.net/using-conditional-csharp-linq-clauses-to-make-a-multiple-input-search-engine/
    /// </summary>
    public static class LINQExtensions
    {
        public static IQueryable<T> If<T>(
            this IQueryable<T> query,
            bool should,
            params Func<IQueryable<T>, IQueryable<T>>[] transforms)
        {
            return should
                ? transforms.Aggregate(query,
                    (current, transform) => transform.Invoke(current))
                : query;
        }

        public static IEnumerable<T> If<T>(
            this IEnumerable<T> query,
            bool should,
            params Func<IEnumerable<T>, IEnumerable<T>>[] transforms)
        {
            return should
                ? transforms.Aggregate(query,
                    (current, transform) => transform.Invoke(current))
                : query;
        }
    }
}
