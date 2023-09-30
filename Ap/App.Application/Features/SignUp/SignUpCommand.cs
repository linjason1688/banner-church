using System.Collections.Generic;
using App.Application.Managements.UserBankAccounts.Commands.CreateUserBankAccount;
using App.Application.Managements.UserBankAccounts.Commands.UpdateUserBankAccount;
using App.Application.Managements.UserContacts.Commands.CreateUserContact;
using App.Application.Managements.UserContacts.Commands.UpdateUserContact;
using App.Application.Managements.UserExpertises.Commands.CreateUserExpertise;
using App.Application.Managements.UserExpertises.Commands.UpdateUserExpertise;
using App.Application.Managements.UserFamilies.Commands.CreateUserFamily;
using App.Application.Managements.UserFamilies.Commands.UpdateUserFamily;
using App.Application.Managements.Users.Dtos;
using App.Application.Managements.UserSocieties.Commands.CreateUserSociety;
using MediatR;

namespace App.Application.Features.SignUp
{
    /// <summary>
    /// 註冊
    /// </summary>
    public class SignUpCommand : UserBase, IRequest<SignUpCommandResponse>
    {
        public int? Id { get; set; }

        /// <summary>
        /// 聯絡方式
        /// </summary>
        public List<CreateUserContactCommand> UserContacts { get; set; }

        /// <summary>
        /// 家庭成员
        /// </summary>
        public List<CreateUserFamilyCommand> UserFamilies { get; set; }

        /// <summary>
        /// 銀行帳號
        /// </summary>
        public List<CreateUserBankAccountCommand> UserBankAccounts { get; set; }

        /// <summary>
        /// 專長
        /// </summary>
        public List<CreateUserExpertiseCommand> UserExpertises { get; set; }

        /// <summary>
        /// 外部社團 / 工會
        /// </summary>
        public List<CreateUserSocietyCommand> UserSocieties { get; set; }
    }
}
