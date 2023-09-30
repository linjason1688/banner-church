#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QrCodes.Queries.QueryQrCode
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryQrCodeRequestValidator 
        : AbstractValidator<QueryQrCodeRequest>
    {
        public QueryQrCodeRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
