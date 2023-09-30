


using System;

namespace App.Application.Managements.Ministries.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class MinistryBase
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Organization.Id
        /// </summary>
        public long OrganizationId { get; set; }

        /// <summary>
        /// 組織名稱
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 事工團分類id
        /// </summary>
        public long MinistryDefId { get; set; }

        /// <summary>
        /// 事工團編號
        /// </summary>
        public string MinistryNo { get; set; }


        /// <summary>
        /// 事工團名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否兒童事工團
        /// </summary>
        public string ChildMinistry { get; set; }

        /// <summary>
        /// 事工團狀態
        /// </summary>
        public string MinistryStatus { get; set; }

        /// <summary>
        /// 性質
        /// </summary>
        public string Nature { get; set; }

        

        /// <summary>
        /// id
        /// </summary>
        public string StatusCd { get; set; }


        public string Comment { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string UserUpdate { get; set; }

   

    }
}

