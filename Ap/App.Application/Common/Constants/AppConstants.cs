namespace App.Application.Common.Constants
{
    public static class AppConstants
    {
        /// <summary>
        /// 供一些 fetch select options/ auto-complete 使用
        /// </summary>
        public static int MaxRecordsForFetch => 15;

        /// <summary>
        /// 分頁查詢頁面數量
        /// </summary>
        public static int NavigationPageSize => 5;

        /// <summary>
        /// 分頁查詢一般最大數量
        /// </summary>
        public static int MaxPaginationSize => 200;

        /// <summary>
        /// 供查詢所有的功能一次最多取出的資料限制
        /// 或
        /// 分頁查詢特殊(全部) 數量
        /// </summary>
        public static int FindAllLimit => 10000;
    }
}
