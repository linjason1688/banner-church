#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderRecords.Commands.DeleteVwOrderRecord
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwOrderRecordCommandValidator 
        : AbstractValidator<DeleteVwOrderRecordCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwOrderRecordCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
