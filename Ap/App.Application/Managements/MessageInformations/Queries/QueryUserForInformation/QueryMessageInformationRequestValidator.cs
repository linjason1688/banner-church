#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformations.Queries.QueryUserForInformation
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserForInformationRequestValidator 
        : AbstractValidator<QueryUserForInformationRequest>
    {
        public QueryUserForInformationRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
