


using System;

namespace App.Application.Managements.Pastorals.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class PastoralBase
    {
        /// <summary>
        ///  組織部門Id
        /// </summary>
        public long DeptId { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 組織上層Id (分多階層)        堂點       牧區 督區 區 小組
        /// </summary>
        public long UpperPastoralId { get; set; }

        /// <summary>
        /// 分組區域名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分組區域職稱
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 小組編號//八碼數字 系統自動產生(為小組時才需填入)
        /// </summary>
        public string GroupNo { get; set; }

        /// <summary>
        /// 領導人 UserId
        /// </summary>
        public long? LeaderId { get; set; }
        /// <summary>
        /// 領導人身分證
        /// </summary>
        public string LeaderIdnumber { get; set; }

        /// <summary>
        /// 領導人2 UserId
        /// </summary>
        public long? Leader2Id { get; set; }

        /// <summary>
        /// 領導人2身分證
        /// </summary>
        public string Leader2Idnumber { get; set; }

        /// <summary>
        /// 領導人3 UserId
        /// </summary>
        public long? Leader3Id { get; set; }

        /// <summary>
        /// 領導人3身分證
        /// </summary>
        public string Leader3Idnumber { get; set; }

        /// <summary>
        /// 最大權限人UserId
        /// </summary>
        public long? SupervisorId { get; set; }


        /// <summary>
        ///  LineToken
        /// </summary>
        public string LineToken { get; set; }

        public int? UpperOrganizationId { get; set; }
        public long OrgId { get; set; }
        public string TypeId { get; set; }

        public string StatusCd { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }

        public int IsActivated { get; set; }
        // [DataMember]

    }
}

