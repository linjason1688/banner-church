#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformationUsers.Queries.FindMessageInformationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMessageInformationUserRequestValidator 
        : AbstractValidator<FindMessageInformationUserRequest>
    {
        public FindMessageInformationUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
