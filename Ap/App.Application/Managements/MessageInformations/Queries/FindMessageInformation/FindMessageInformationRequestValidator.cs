#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformations.Queries.FindMessageInformation
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMessageInformationRequestValidator 
        : AbstractValidator<FindMessageInformationRequest>
    {
        public FindMessageInformationRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
