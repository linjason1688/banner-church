#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups.Queries.FindModMinisterGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMinisterGroupRequestValidator 
        : AbstractValidator<FindModMinisterGroupRequest>
    {
        public FindModMinisterGroupRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
