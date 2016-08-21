namespace AW.Common.Utils
{
    using System;
    using System.Linq;
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

        // Create lambdas for select statement
        public static Expression<Func<T, T>> CreateNewStatement<T>(string fields)
        {
            // input parameter "o"
            var xParameter = Expression.Parameter(typeof(T), "o");

            // new statement "new Data()"
            var xNew = Expression.New(typeof(T));

            // create initializers
            var bindings = fields.Split(',').Select(o => o.Trim())
                .Select(o => {

            // property "Field1"
            var mi = typeof(T).GetProperty(o);

            // original value "o.Field1"
            var xOriginal = Expression.Property(xParameter, mi);

            // set value "Field1 = o.Field1"
            return Expression.Bind(mi, xOriginal);
                }
            );

            // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var xInit = Expression.MemberInit(xNew, bindings);

            // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

            // compile to Func<Data, Data>
            return lambda;
        }
    }
}
