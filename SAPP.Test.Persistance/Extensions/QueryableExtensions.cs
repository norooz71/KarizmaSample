using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Karizma.Sample.Persistance.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyIncludes<T>(this IQueryable<T> queryable, params string[] includes) where T : class
        {
            foreach (var include in includes)
                queryable = queryable.Include(include);

            return queryable;
        }

    }
}
