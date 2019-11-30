using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MOBoard.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName, bool ascending = true)
        {
            var entityType = typeof(TSource);
            propertyName = propertyName.FirstCharToUpper();

            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);

            var selector = Expression.Lambda(property, arg);

            var methodOrderName = ascending ? "OrderBy" : "OrderByDescending";

            var enumerableType = typeof(Queryable);
            var method = enumerableType.GetMethods()
                .Where(m => m.Name == methodOrderName && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters().ToList();
                    return parameters.Count == 2;
                })
                .Single();

            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                .Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }
    }
}