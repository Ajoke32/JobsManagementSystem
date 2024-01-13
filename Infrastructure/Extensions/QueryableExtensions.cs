using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class QueryableExtensions
{
    public static void IncludeStringProperties<T>(this IQueryable<T> q, string props) where T:class
    {
        foreach (var includeProperty in props.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            q = q.Include(includeProperty);
        }
    }
}