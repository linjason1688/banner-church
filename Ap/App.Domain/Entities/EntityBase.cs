using System;
using System.ComponentModel;

namespace App.Domain.Entities
{
    public interface IEntityBase
    {
        /// <summary>
        /// ApiLog HandledId
        /// </summary>
        Guid? HandledId { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        DateTime DateCreate { get; set; }

        /// <summary>
        /// 建立人員
        /// </summary>
        string UserCreate { get; set; }

        /// <summary>
        /// 最後修改日期
        /// </summary>
        DateTime? DateUpdate { get; set; }

        /// <summary>
        /// 最後修改人員
        /// </summary>
        string UserUpdate { get; set; }
    }

    public class EntityBase
        : IEntityBase
    {
        /// <summary>
        /// ApiLog HandledId
        /// </summary>
        [Description("ApiHandledId")]
        public Guid? HandledId { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        [Description("建立日期")]
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// 建立人員
        /// </summary>
        [Description("建立人員")]
        public string UserCreate { get; set; }

        /// <summary>
        /// 最後修改日期
        /// </summary>
        [Description("最後修改日期")]
        public DateTime? DateUpdate { get; set; }

        /// <summary>
        /// 最後修改人員
        /// </summary>
        [Description("最後修改人員")]
        public string UserUpdate { get; set; }

        [Description("RowVersion")]
        public byte[] RowVersion { get; set; }
    }
}
