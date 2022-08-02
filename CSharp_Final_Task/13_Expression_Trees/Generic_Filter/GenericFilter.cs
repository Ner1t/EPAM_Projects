using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Generic_Filter
{
    public class GenericFilter<T> where T : class
    {
        internal class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _parameter;

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return base.VisitParameter(_parameter);
            }

            internal ParameterReplacer(ParameterExpression parameter)
            {
                _parameter = parameter;
            }
        }

        Expression<Func<T, bool>> finalCondition;

        private (ParameterExpression parameter, MemberExpression property) ReturnParameterAndProperty<Tout>(Expression<Func<T, Tout>> expression)
        { 
            ParameterExpression parameter = Expression.Parameter(expression.Parameters[0].Type, expression.Parameters[0].Name);

            var expressionProperty = expression.Body as MemberExpression;

            if (expressionProperty == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' does not refer to a property.", expression.Body.ToString()));
            }

            MemberInfo selectedProperty = expression.Parameters[0].Type.GetProperty(expressionProperty.Member.Name);

            MemberExpression property = Expression.MakeMemberAccess(parameter, selectedProperty);

            return (parameter, property);
        }

        private void Combine(Expression expression, ParameterExpression parameter)
        {
            Expression<Func<T, bool>> condition = Expression.Lambda<Func<T, bool>>(expression, parameter);

            BinaryExpression body = Expression.AndAlso(finalCondition.Body, condition.Body);
            body = (BinaryExpression)new ParameterReplacer(parameter).Visit(body);

            finalCondition = Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public GenericFilter<T> IsGreaterThan<Tout>(Expression<Func<T, Tout>> expression, Tout value)
        {
            (ParameterExpression parameter, MemberExpression valueInProperty) = ReturnParameterAndProperty(expression);

            ConstantExpression constant = Expression.Constant(value);

            BinaryExpression elementGreaterThan = Expression.GreaterThan(valueInProperty, constant);

            if (finalCondition is null)
            {
                finalCondition = Expression.Lambda<Func<T, bool>>(elementGreaterThan, parameter);
            }
            else
            {
                Combine(elementGreaterThan, parameter);
            }
            return this;
        }

        public GenericFilter<T> IsEqual<Tout>(Expression<Func<T, Tout>> expression, Tout value)
        {
            (ParameterExpression parameter, MemberExpression property) = ReturnParameterAndProperty(expression);

            ConstantExpression constant = Expression.Constant(value);

            BinaryExpression elementEqualTo = Expression.Equal(property, constant);

            if (finalCondition is null)
            {
                finalCondition = Expression.Lambda<Func<T, bool>>(elementEqualTo, parameter);
            }
            else
            {
                Combine(elementEqualTo, parameter);
            }
            return this;
        }

        public GenericFilter<T> IsLessThan<Tout>(Expression<Func<T, Tout>> expression, Tout value)
        {
            (ParameterExpression parameter, MemberExpression property) = ReturnParameterAndProperty(expression);

            ConstantExpression constant = Expression.Constant(value);

            BinaryExpression elementLessThan = Expression.LessThan(property, constant);

            if (finalCondition is null)
            {
                finalCondition = Expression.Lambda<Func<T, bool>>(elementLessThan, parameter);
            }
            else
            {
                Combine(elementLessThan, parameter);
            }
            return this;
        }

        public GenericFilter<T> IsBetween<Tout>(Expression<Func<T, Tout>> expression, Tout minValue, Tout maxValue)
        {
            IsGreaterThan(expression, minValue).IsLessThan(expression, maxValue);
            return this;
        }

        public GenericFilter<T> PartStringSame<Tout>(Expression<Func<T, Tout>> expression, string value)
        {
            (ParameterExpression parameter, MemberExpression property) = ReturnParameterAndProperty(expression);

            ConstantExpression constant = Expression.Constant(value);

            MethodInfo containsMethod = typeof(String).GetMethod(nameof(String.Contains), new Type[] { typeof(string), typeof(StringComparison) });

            ConstantExpression ignoreCase = Expression.Constant(StringComparison.OrdinalIgnoreCase);

            MethodCallExpression partStringSame = Expression.Call(property, containsMethod, constant, ignoreCase);

            if (finalCondition is null)
            {
                finalCondition = Expression.Lambda<Func<T, bool>>(partStringSame, parameter);
            }
            else
            {
                Combine(partStringSame, parameter);
            }
            return this;
        }

        public IEnumerable<T> Apply(IEnumerable<T> collection)
        {
            IEnumerable<T> resultsSelection = collection.Where(finalCondition.Compile());
            return resultsSelection;
        }
    }
}
