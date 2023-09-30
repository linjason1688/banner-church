using System;
using App.Application.Common.Dtos;
using App.Domain.Entities;

namespace App.Application.Common.Extensions
{
    /// <summary>
    /// </summary>
    public static class IDateRangeQueryExtension
    {
        /// <summary>
        /// 處理日期時之查詢 (***需精準至時間查詢者不適用!)
        /// s -> date
        /// e -> e + 1 date
        /// </summary>
        public static void MakeDateIncludeBoundaries(this IDateRangeLimitedRequest @this)
        {
            if (@this.StartDate.HasValue)
            {
                @this.StartDate = @this.StartDate.Value.Date;
            }

            if (@this.StopDate.HasValue)
            {
                @this.StopDate = @this.StopDate.Value.Date.AddDays(1);
            }
        }

        /// <summary>
        /// 處理日期時之查詢 (***需精準至時間查詢者不適用!)
        /// s -> date
        /// e -> e + 1 date
        /// </summary>
        public static void MakeDateIncludeBoundaries(this IDateRangeLimited @this)
        {
            if (@this.StartDate.HasValue)
            {
                @this.StartDate = @this.StartDate.Value.Date;
            }

            if (@this.StopDate.HasValue)
            {
                @this.StopDate = @this.StopDate.Value.Date.AddDays(1);
            }
        }


        /// <summary>
        /// 如果未給值者，新增時給預設起迄時間
        /// </summary>
        public static void CorrectCreateDateRange(this IDateRangeLimitedRequest @this)
        {
            @this.StartDate ??= DateTime.Today;

            @this.StopDate ??= DateTime.MaxValue;
        }
    }
}
