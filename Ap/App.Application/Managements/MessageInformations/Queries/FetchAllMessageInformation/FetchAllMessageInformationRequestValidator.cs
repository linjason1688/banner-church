#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformations.Queries.FetchAllMessageInformation
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMessageInformationRequestValidator 
        : AbstractValidator<FetchAllMessageInformationRequest>
    {
        public FetchAllMessageInformationRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
