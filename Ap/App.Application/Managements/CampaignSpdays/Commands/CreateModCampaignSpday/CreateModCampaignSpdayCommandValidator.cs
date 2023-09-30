#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Commands.CreateModCampaignSpday
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModCampaignSpdayCommandValidator 
        : AbstractValidator<CreateModCampaignSpdayCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModCampaignSpdayCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModCampaignSpday, e => e.Name)
            //     );
        }
    }
}
