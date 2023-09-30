namespace App.Domain.Entities.Features
{
    public partial class Pastoral : EntityBase
    {
        /// <summary>
        ///  組織部門Id
        /// </summary>
        public long DeptId { get; set; }

        public long Id { get; set; }

        public long UpperPastoralId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string GroupNo { get; set; }

        public long? LeaderId { get; set; }

        public string LeaderIdNumber { get; set; }

        public long? Leader2Id { get; set; }

        public string Leader2IdNumber { get; set; }

        public long? Leader3Id { get; set; }

        public string Leader3IdNumber { get; set; }

        public long? SupervisorId { get; set; }


        public long? Oid { get; set; }

        public long OrgId { get; set; }

        public string? TypeId { get; set; }

        /// <summary>
        ///  LineToken
        /// </summary>
        public string LineToken { get; set; }

        public string StatusCd { get; set; }


        public string Comment { get; set; }

        //public string IsActivated { get; set; }
    }
}
