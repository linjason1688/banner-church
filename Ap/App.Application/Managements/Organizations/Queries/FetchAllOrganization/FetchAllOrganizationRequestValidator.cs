#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Organizations.Queries.FetchAllOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllOrganizationRequestValidator 
        : AbstractValidator<FetchAllOrganizationRequest>
    {
        public FetchAllOrganizationRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
