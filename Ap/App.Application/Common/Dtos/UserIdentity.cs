using System;
using System.Collections.Generic;

namespace App.Application.Common.Dtos
{
    /// <summary>
    /// 內部使用
    /// </summary>
    public class UserIdentity
    {
        public static int IVersion => 20220902;

        /// <summary>
        /// UserIdentity version,  版本不同之 token 強制 invalid
        /// </summary>
        public int Version { get; set; }



        /// <summary>
        /// sso guid
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Pastoral.Id
        /// </summary>
        public long PastoralId { get; set; }

        /// <summary>
        /// 帳戶 (也是員編)
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Guid> RoleIdList { get; set; }

        public string Name
        {
            get => this.Mocked ? this.MockName : this.ActualName;
        }

        public string NickName
        {
            get => this.Mocked ? this.MockNickName : this.ActualNickName;
        }

        /// <summary>
        /// 同帳號 (如果是模擬身分，則會取得 模擬者的 員編)
        /// </summary>
        public string EmployeeId
        {
            get => this.Mocked ? this.MockEmployeeId : this.ActualEmployeeId;
        }

        public string DeptName
        {
            get => this.Mocked ? this.MockDeptName : this.ActualDeptName;
        }

        public string DeptID
        {
            get => this.Mocked ? this.MockDeptId : this.ActualDeptId;
        }

        public string LastLoginIp { get; set; }

        // mock user usage
        public bool Mocked { get; set; }

        public string ActualName { get; set; }

        public string ActualNickName { get; set; }

        public string ActualEmployeeId { get; set; }

        public string ActualDeptName { get; set; }

        public string ActualDeptId { get; set; }


        public string MockName { get; set; }

        public string MockNickName { get; set; }

        public string MockEmployeeId { get; set; }

        public string MockDeptName { get; set; }

        public string MockDeptId { get; set; }
    }
}
