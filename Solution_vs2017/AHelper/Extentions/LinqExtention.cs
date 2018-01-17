using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Auction.Utility.Extentions
{
    public static class LinqExtention
    {
        public static IQueryable<TSource> HasWhere<TSource>(this IQueryable<TSource> query, string target, Expression<Func<TSource, bool>> predicate)
        {
            if (!string.IsNullOrEmpty(target))
            {
                return query.Where(predicate);
            }
            return query;
        }
        public static IQueryable<TSource> HasWhere<TSource, T2>(this IQueryable<TSource> query, T2? target, Expression<Func<TSource, bool>> predicate)
            where T2 : struct
        {
            if (target.HasValue)
            {
                return query.Where(predicate);
            }
            return query;
        }

        public static IEnumerable<TSource> HasWhere<TSource>(this IEnumerable<TSource> query, string target, Func<TSource, bool> predicate)
        {
            if (!string.IsNullOrEmpty(target))
            {
                return query.Where(predicate);
            }
            return query;
        }
    }
}
