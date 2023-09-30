


using System;
using App.Domain.Entities.Features;

namespace App.Application.Managements.Organizations.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationBase
    {
        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  組織部門Id
        /// </summary>
        public long DeptId { get; set; }

        /// <summary>
        ///  以前欄位Id
        /// </summary>
        //public long OrganizationId { get; set; }
        /// <summary>
        ///  上層的Id
        /// </summary>
        public long UpperOrganizationId { get; set; }
        /// <summary>
        ///  舊欄位對應部門id Portal.Id        
        /// </summary>
        public long PortalId { get; set; }

        /// <summary>
        ///  組織名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  主任牧師名稱
        /// </summary>
        public string PastorName { get; set; }

        /// <summary>
        ///  主任牧師User.Id
        /// </summary>
        public long PastorId { get; set; }

        /// <summary>
        ///  主任牧師身分證
        /// </summary>
        public string Pastor { get; set; }
        /// <summary>
        ///  主任牧師電話
        /// </summary>
        public string Pastorphone { get; set; }
       

        /// <summary>
        ///  
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        ///  教會電話
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        ///  教會傳真
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        ///  教會Email
        /// </summary>
        public string Site { get; set; }
        /// <summary>
        ///  教會網址
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        ///  教會郵遞區號
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///  教會地址
        /// </summary>
        public string InvoiceIdentifier { get; set; }
        /// <summary>
        ///  教會統一編號抬頭
        /// </summary>
        public string InvoiceTitle { get; set; }

        /// <summary>
        /// 是否需要發票抬頭        對應SystemConfig        type = IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string IsInvoiceTitle { get; set; }

        /// <summary>
        /// 組織狀態        對應SystemConfig        type =OrgStatus顯示 namevalue存此欄位0：停用 1：正常
        /// </summary>
        public string OrgStatus { get; set; }

        /// <summary>
        ///  LineToken
        /// </summary>
        public string LineToken { get; set; }

        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }


    }
}

