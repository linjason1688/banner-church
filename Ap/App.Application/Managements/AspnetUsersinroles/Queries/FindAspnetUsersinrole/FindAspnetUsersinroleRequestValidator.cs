#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsersinroles.Queries.FindAspnetUsersinrole
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetUsersinroleRequestValidator 
        : AbstractValidator<FindAspnetUsersinroleRequest>
    {
        public FindAspnetUsersinroleRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
