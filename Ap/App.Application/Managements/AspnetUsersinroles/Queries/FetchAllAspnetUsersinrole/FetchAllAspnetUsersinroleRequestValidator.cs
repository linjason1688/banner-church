#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsersinroles.Queries.FetchAllAspnetUsersinrole
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetUsersinroleRequestValidator 
        : AbstractValidator<FetchAllAspnetUsersinroleRequest>
    {
        public FetchAllAspnetUsersinroleRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
