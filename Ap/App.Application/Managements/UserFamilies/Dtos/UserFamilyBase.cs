


namespace App.Application.Managements.UserFamilies.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserFamilyBase
    {
        /// <summary>
        ///  Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 建立時間 User.Id
        /// </summary>
        public string UserId { get; set; }//建立時間 User.Id
        /// <summary>
        /// 關係類別 對應SystemConfig        type=RelativeType       顯示 name       value存此欄位0：配偶1：父母2：子女
        /// </summary>
        public string RelativeType { get; set; }//關係類別 對應SystemConfig        type=RelativeType       顯示 name       value存此欄位0：配偶1：父母2：子女
        /// <summary>
        /// 請輸入連絡電話
        /// </summary>
        public string Name { get; set; }//請輸入連絡電話
        /// <summary>
        /// 帳號或註記 
        /// </summary>
        public string Memo { get; set; }
    }
}

