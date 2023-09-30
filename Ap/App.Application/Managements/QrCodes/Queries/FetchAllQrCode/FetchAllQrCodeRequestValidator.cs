#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.QrCodes.Queries.FetchAllQrCode
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllQrCodeRequestValidator 
        : AbstractValidator<FetchAllQrCodeRequest>
    {
        public FetchAllQrCodeRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
