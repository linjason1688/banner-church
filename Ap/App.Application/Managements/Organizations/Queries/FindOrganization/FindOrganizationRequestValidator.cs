#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Organizations.Queries.FindOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class FindOrganizationRequestValidator 
        : AbstractValidator<FindOrganizationRequest>
    {
        public FindOrganizationRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
