namespace AW.Common.Extensions
{
    #region Using
    using Constants;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion
    public static class QueryableExtension
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> items, string propertyName, SortDirection direction)
        {
            var typeOfT = typeof(T);
            var parameter = Expression.Parameter(typeOfT, "parameter");
            var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
            var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
            var orderExpression = Expression.Lambda(propertyAccess, parameter);

            string orderbyMethod = (direction == SortDirection.Ascending ? "OrderBy" : "OrderByDescending");
            var expression = Expression.Call(typeof(Queryable), orderbyMethod, new[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
            return items.Provider.CreateQuery<T>(expression);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> items, string propertyName)
        {
            var typeOfT = typeof(T);
            var parameter = Expression.Parameter(typeOfT, "parameter");
            var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
            var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
            var orderExpression = Expression.Lambda(propertyAccess, parameter);

            string orderbyMethod = "Where";
            var expression = Expression.Call(typeof(Queryable), orderbyMethod, new[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
            return items.Provider.CreateQuery<T>(expression);
        }
    }
}
