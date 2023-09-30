using AutoMapper;
using App.Application.Managements.UserBankAccounts.Commands.CreateUserBankAccount;
using App.Application.Managements.UserBankAccounts.Commands.UpdateUserBankAccount;
using App.Application.Managements.UserBankAccounts.Dtos;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;

namespace App.Application.Managements.UserBankAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            CreateMap<UserBankAccount, UserBankAccountView>();
            
            CreateMap<CreateUserBankAccountCommand, UserBankAccount>();
            
            CreateMap<UpdateUserBankAccountCommand, UserBankAccount>();
            
        }
    }
}
