using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using FluentValidation;
using FluentValidation.Internal;

namespace App.Application.Common.Extensions
{
    /// <summary>
    /// </summary>
    public static class ValidationExtension
    {
        public static void AddFailureWhen<T>(this ValidationContext<T> @this, bool matched, string message)
        {
            if (!matched)
            {
                return;
            }

            @this.AddFailure(message);
        }

        public static void AddFailureWhen<T>(
            this ValidationContext<T> @this,
            bool matched,
            string property,
            string message
        )
        {
            if (!matched)
            {
                return;
            }

            @this.AddFailure(property, message);
        }

        public static IRuleBuilderInitial<T, TProperty> MyRuleFor<T, TProperty>(
            this AbstractValidator<T> @this,
            Expression<Func<T, TProperty>> expression
        )
        {
            var desc = expression.GetMember()
              ?.GetCustomAttribute<DescriptionAttribute>();

            return @this.RuleFor(expression)
               .Configure(
                    c =>
                    {
                        // c.MessageBuilder = ValidatorMessageBuilder;

                        c.SetDisplayName(desc?.Description ?? string.Empty);
                    }
                );
        }
    }
}
