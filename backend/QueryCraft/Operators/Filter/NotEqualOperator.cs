﻿using System;
using System.Linq.Expressions;
using QueryCraft.Interfaces;
using QueryCraft.Operators;

namespace QueryCraft.Operators.Filter
{
    public class NotEqualOperator : FilterOperator
    {
        public NotEqualOperator(ParameterExpression type, string fieldName, string value, ITypeConverter converter) : base(type, fieldName, value, converter)
        {
        }

        public override Expression<Func<T, bool>> GetPredicate<T>()
        {
            Expression body = Expression.NotEqual(Property, Value);
            return Expression.Lambda<Func<T, bool>>(body, TypeExpression);
        }
    }
}
