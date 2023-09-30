#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserContacts.Queries.QueryUserContact
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserContactRequestValidator 
        : AbstractValidator<QueryUserContactRequest>
    {
        public QueryUserContactRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
