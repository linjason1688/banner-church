namespace App.Application.Common.Dtos.Commands
{
    /// <summary>
    /// </summary>
    public class BatchOperationResult
    {
        /// <summary>
        /// 新增異動筆數
        /// </summary>
        public int CreatedCount { get; set; }

        /// <summary>
        /// 更新異動筆數
        /// </summary>
        public int UpdatedCount { get; set; }

        /// <summary>
        /// 刪除異動筆數
        /// </summary>
        public int DeletedCount { get; set; }
    }
}
