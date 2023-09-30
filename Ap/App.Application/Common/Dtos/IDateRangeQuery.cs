using System;

namespace App.Application.Common.Dtos
{
    public interface ICreateAtRangeQuery
    {
        /// <summary>
        /// 建立時間起時
        /// </summary>
        DateTime? CreateAtStart { get; set; }

        /// <summary>
        /// 建立時間迄時
        /// </summary>
        DateTime? CreateAtEnd { get; set; }
    }
}
