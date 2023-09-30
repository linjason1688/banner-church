#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups.Queries.FetchAllModMinisterGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMinisterGroupRequestValidator 
        : AbstractValidator<FetchAllModMinisterGroupRequest>
    {
        public FetchAllModMinisterGroupRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
