#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformations.Queries.QueryMessageInformation
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMessageInformationRequestValidator 
        : AbstractValidator<QueryMessageInformationRequest>
    {
        public QueryMessageInformationRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
