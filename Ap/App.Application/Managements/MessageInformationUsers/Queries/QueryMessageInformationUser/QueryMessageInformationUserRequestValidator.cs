#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformationUsers.Queries.QueryMessageInformationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMessageInformationUserRequestValidator 
        : AbstractValidator<QueryMessageInformationUserRequest>
    {
        public QueryMessageInformationUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
