using System;
using System.Collections.Generic;

namespace App.Domain.Entities.Features
{
    public partial class MeetingPoint : EntityBase
    {
        public long Id { get; set; }


        /// <summary>
        /// 聚會點上層Id
        /// </summary>
        public long OrganizationId { get; set; }
      
        /// <summary>
        /// 聚會點名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 聚會點地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 聚會點電話
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 聚會點備註說明
        /// </summary>
        public string Memo { get; set; }


        public long UserId { get; set; }
        public string StatusCd { get; set; }
        public string Comment { get; set; }

    }
}
