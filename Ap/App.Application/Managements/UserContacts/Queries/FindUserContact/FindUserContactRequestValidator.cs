#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserContacts.Queries.FindUserContact
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserContactRequestValidator 
        : AbstractValidator<FindUserContactRequest>
    {
        public FindUserContactRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
