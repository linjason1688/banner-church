#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserContacts.Queries.FetchAllUserContact
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserContactRequestValidator 
        : AbstractValidator<FetchAllUserContactRequest>
    {
        public FetchAllUserContactRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
