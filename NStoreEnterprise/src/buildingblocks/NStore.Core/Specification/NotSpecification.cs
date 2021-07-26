﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace NStore.Core.Specification
{
    internal class NotSpecification<T> : Specification<T>
    {
        private Specification<T> _specification;

        public NotSpecification(Specification<T> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var expression = _specification.ToExpression();
            var notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }
}