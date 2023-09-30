#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QrCodes.Queries.FindQrCode
{
    /// <summary>
    /// 
    /// </summary>
    public class FindQrCodeRequestValidator 
        : AbstractValidator<FindQrCodeRequest>
    {
        public FindQrCodeRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
