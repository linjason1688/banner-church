using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence
{
    /// <summary>
    /// </summary>
    public partial class AppDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserBankAccount> UserBankAccounts { get; set; }

        public DbSet<UserContact> UserContacts { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<UserExpertise> UserExpertises { get; set; }

        public DbSet<UserFamily> UserFamilies { get; set; }

        public DbSet<UserSociety> UserSocieties { get; set; }

        public DbSet<Questionnaire> Questionnaires { get; set; }

        public DbSet<QuestionnaireDetail> QuestionnaireDetails { get; set; }

        public DbSet<UserQuestionnaire> UserQuestionnaires { get; set; }

        public DbSet<UserPastoralCare> UserPastoralCares { get; set; }

        public DbSet<Pastoral> Pastorals { get; set; }

        public DbSet<PastoralMeeting> PastoralMeetings { get; set; }

        public DbSet<PastoralMeetingUser> PastoralMeetingUsers { get; set; }

        public DbSet<MinistryMeeting> MinistryMeetings { get; set; }

        public DbSet<MinistryMeetingUser> MinistryMeetingUsers { get; set; }

        //課程相關表
        public DbSet<CourseManagementType> CourseManagementTypes { get; set; }
        public DbSet<CourseManagement> CourseManagements { get; set; }

        public DbSet<CourseManagementFilter> CourseManagementFilters { get; set; }
        public DbSet<CourseManagementFilterResp> CourseManagementFilterResps { get; set; }
        public DbSet<CourseManagementFilterPastoral> CourseManagementFilterPastorals { get; set; }
        public DbSet<CourseManagementFilterCourse> CourseManagementFilterCourses { get; set; }
        public DbSet<CourseManagementFilterUser> CourseManagementFilterUsers { get; set; }


        public DbSet<CourseManagementAppendix> CourseManagementAppendixs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursePrice> CoursePrices { get; set; }

        public DbSet<CourseOrganization> CourseOrganizations { get; set; }

        public DbSet<CourseAppendix> CourseAppendixs { get; set; }
        public DbSet<CourseTimeSchedule> CourseTimeSchedules { get; set; }
        public DbSet<CourseTimeScheduleTeacher> CourseTimeScheduleTeachers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseTimeScheduleUser> CourseTimeScheduleUsers { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingOrder> ShoppingOrders { get; set; }
        public DbSet<ShoppingOrderDetail> ShoppingOrderDetails { get; set; }

        public DbSet<ShoppingTrack> ShoppingTracks { get; set; }

        public DbSet<QrCode> QrCodes { get; set; }

        public DbSet<QuestionnaireSatisfyUser> QuestionnaireSatisfyUsers { get; set; }


        /// <inheritdoc />
        public DbSet<MinistryDef> MinistryDefs { get; set; }

        /// <inheritdoc />
        public DbSet<Ministry> Ministries { get; set; }

        /// <inheritdoc />
        public DbSet<MinistryResp> MinistryResps { get; set; }

        /// <inheritdoc />
        public DbSet<MinistryRespUser> MinistryRespUsers { get; set; }

        /// <inheritdoc />
        public DbSet<MinistrySchedule> MinistrySchedules { get; set; }

        public DbSet<MinistryScheduleDetail> MinistryScheduleDetails { get; set; }

        public DbSet<Dept> Depts { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<OrganizationUser> OrganizationUsers { get; set; }

        public DbSet<MeetingPoint> MeetingPoints { get; set; }

        public DbSet<MessageInformation> MessageInformations { get; set; }
        public DbSet<MessageInformationUser> MessageInformationUsers { get; set; }

        /// <inheritdoc />
        public DbSet<Role> Roles { get; set; }

        /// <inheritdoc />
        public DbSet<RoleUserMapping> RoleUserMappings { get; set; }

        /// <inheritdoc />
        public DbSet<Privilege> Privileges { get; set; }

        /// <inheritdoc />
        public DbSet<RolePrivilegeMapping> RolePrivilegeMappings { get; set; }

        /// <inheritdoc />
        public DbSet<UploadFile> UploadFiles { get; set; }

    }
}
