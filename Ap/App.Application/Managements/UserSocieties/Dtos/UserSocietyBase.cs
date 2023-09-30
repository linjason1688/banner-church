


using App.Domain.Entities.Features;

namespace App.Application.Managements.UserSocieties.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserSocietyBase
    {
        /// <summary>
        /// Key
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// User.Name
        /// </summary>
        public string Name { get; set; }



        public virtual User User { get; set; }

        // [DataMember]

    }
}

