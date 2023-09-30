#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformationUsers.Queries.FetchAllMessageInformationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMessageInformationUserRequestValidator 
        : AbstractValidator<FetchAllMessageInformationUserRequest>
    {
        public FetchAllMessageInformationUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
