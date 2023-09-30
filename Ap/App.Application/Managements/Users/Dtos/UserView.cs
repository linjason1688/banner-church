using System;
using System.Reflection;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Runtime;
using App.Domain.Common;
using App.Domain.Entities;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Application.Managements.UserFamilies.Dtos;
using App.Application.Managements.UserContacts.Dtos;
using App.Application.Managements.UserBankAccounts.Dtos;
using App.Application.Managements.UserCourses.Dtos;
using App.Application.Managements.UserExpertises.Dtos;
using App.Application.Managements.UserSocieties.Dtos;
using App.Application.Managements.Organizations.Dtos;
using App.Application.Managements.Pastorals.Dtos;
using App.Application.Managements.RoleUserMappings.Dtos;

namespace App.Application.Managements.Users.Dtos
{
    /// <summary>
    /// User 
    /// </summary>
    public class UserView : UserBase, IEntityBase
    {
        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  Id
        /// </summary>
        public string LastLogin { get; set; }//最後登入時間

        /// <summary>
        /// 角色 id
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        ///  父母的配偶名字
        /// </summary>
        public string ParentSpouseName { get; set; }//父母的配偶名字


        /// <inheritdoc />
        public Guid? HandledId { get; set; }

        /// <inheritdoc />
        public DateTime DateCreate { get; set; }

        /// <inheritdoc />
        public string UserCreate { get; set; }

        /// <inheritdoc />
        public DateTime? DateUpdate { get; set; }

        /// <inheritdoc />
        public string UserUpdate { get; set; }



        


        /// <summary>
        /// 家庭成員
        /// </summary>
        public List<UserFamilyView> UserFamilies { get; set; }          //家庭成員

        /// <summary>
        /// 緊急聯絡人
        /// </summary>
        public List<UserContactView> UserContacts { get; set; }       //緊急聯絡人

        /// <summary>
        /// 銀行帳戶
        /// </summary>
        public List<UserBankAccountView> UserBankAccounts { get; set; } //會員銀行帳戶相關

        /// <summary>
        /// 專長
        /// </summary>
        public List<UserExpertiseView> UserExpertises { get; set; } //會員專長

        /// <summary>
        /// 社團/工會描述
        /// </summary>
        public List<UserSocietyView> UserSocieties { get; set; } //社團/工會描述

        /// <summary>
        /// 課程歷程
        /// </summary>
        public List<UserCourseView> UserCourses { get; set; }

        public List<OrganizationView> OrganizationTree { get; set; } = new();

        public List<PastoralView> PastoralTree { get; set; } = new();

        /// <summary>
        ///使用者角色權限
        /// </summary>
        public List<RoleUserMappingView> RoleUserMappingViews { get; set; }




    }
}
