#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groups.ModGroups.Queries.FetchAllModGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModGroupRequestValidator 
        : AbstractValidator<FetchAllModGroupRequest>
    {
        public FetchAllModGroupRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
