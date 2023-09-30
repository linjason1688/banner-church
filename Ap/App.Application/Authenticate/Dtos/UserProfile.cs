namespace App.Application.Authenticate.Dtos
{
    /// <summary>
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 帳戶
        /// </summary>
        public string Account { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 同帳號 (如果是模擬身分，則會取得 模擬者的 員編)
        /// </summary>
        public string EmployeeNo { get; set; }

        public string DeptName { get; set; }

        public string DeptId { get; set; }

        public string LastLoginIp { get; set; }

        /// <summary>
        /// 是否為模擬身分
        /// </summary>
        public bool Mocked { get; set; }

        /// <summary>
        /// 實際使用者員編
        /// </summary>
        public string ActualEmpNo { get; set; }


        public bool IsAdmin { get; set; }
    }
}
