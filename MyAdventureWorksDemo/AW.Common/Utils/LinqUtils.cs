namespace AW.Common.Utils
{
    using System;
    using System.Linq.Expressions;

    public static class LinqUtils
    {
        public static Func<T, int> CreateFunc<T>(string propertyName)
        {
            ParameterExpression input = Expression.Parameter(typeof(T));

            var expr = Expression.Property(input, typeof(T).GetProperty(propertyName));

            return Expression.Lambda<Func<T, int>>(expr, input).Compile();
        }

        public static Expression<Func<T, object>> CreateExpression<T>(string propertyName)
        {
            ParameterExpression input = Expression.Parameter(typeof(T));

            var expr = Expression.Property(input, typeof(T).GetProperty(propertyName));

            return Expression.Lambda<Func<T, object>>(expr, input);
        }

        //makes expression for specific prop
        public static Expression<Func<TSource, object>> GetExpression<TSource>(string propertyName)
        {
            var param = Expression.Parameter(typeof(TSource), "x");
            Expression conversion = Expression.Convert(Expression.Property
            (param, propertyName), typeof(object));   //important to use the Expression.Convert
            return Expression.Lambda<Func<TSource, object>>(conversion, param);
        }

        public static Expression<Func<T, object>> GetPropertySelector<T>(string propertyName)
        {
            var arg = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(arg, propertyName);
            //return the property as object
            var conv = Expression.Convert(property, typeof(object));
            var exp = Expression.Lambda<Func<T, object>>(conv, new ParameterExpression[] { arg });
            return exp;
        }
    }
}
