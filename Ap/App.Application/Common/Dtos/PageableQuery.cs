using System.Collections.Generic;

namespace App.Application.Common.Dtos
{
    public interface IPageableQuery
    {
        /// <summary>
        /// 目前頁數
        /// </summary>
        int? Page { get; set; }

        /// <summary>
        /// 每頁筆數
        /// </summary>
        int? Size { get; set; }
    }

    public class PageableQuery : IDynamicSortable, IPageableQuery
    {
        /// <summary>
        /// 查詢欄位排序
        /// </summary>
        public List<SortProperty> SortProperties { get; set; }

        /// <summary>
        /// 目前頁數
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// 每頁筆數
        /// </summary>
        public int? Size { get; set; }
    }
}
