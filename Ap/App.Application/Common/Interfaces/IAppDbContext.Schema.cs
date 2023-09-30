using System.Linq;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using App.Domain.Entities.Queries;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Common.Interfaces
{
    /// <summary>
    /// </summary>
    public partial interface IAppDbContext
    {
        #region SystemBase

        DbSet<ApiAuditLog> ApiAuditLog { get; set; }

        DbSet<ExceptionLog> ExceptionLog { get; set; }

        #endregion

        #region Features

        DbSet<AspnetApplication> AspnetApplications { get; set; }

        DbSet<AspnetMembership> AspnetMemberships { get; set; }

        DbSet<AspnetPath> AspnetPaths { get; set; }

        DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }

        DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }

        DbSet<AspnetProfile> AspnetProfiles { get; set; }

        DbSet<AspnetRole> AspnetRoles { get; set; }

        DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

        DbSet<AspnetUser> AspnetUsers { get; set; }

        DbSet<AspnetUsersInRole> AspnetUsersInRoles { get; set; }

        DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; }

        DbSet<ErrCancel> ErrCancels { get; set; }

        DbSet<ModActivity> ModActivities { get; set; }

        DbSet<ModActivityWork> ModActivityWorks { get; set; }

        DbSet<ModActivityWorkShare> ModActivityWorkShares { get; set; }

        DbSet<ModActivityWorkSignup> ModActivityWorkSignups { get; set; }

        DbSet<ModArea> ModAreas { get; set; }

        DbSet<ModArealeader> ModArealeaders { get; set; }

        DbSet<ModAreasupervisor> ModAreasupervisors { get; set; }

        DbSet<ModCampaign> ModCampaigns { get; set; }

        DbSet<ModCampaignMember> ModCampaignMembers { get; set; }

        DbSet<ModCampaignSpday> ModCampaignSpdays { get; set; }

        DbSet<ModCareer> ModCareers { get; set; }

        DbSet<ModClass> ModClasses { get; set; }

        DbSet<ModClassDay> ModClassDays { get; set; }

        DbSet<ModClassPrice> ModClassPrices { get; set; }

        DbSet<ModClassTerm> ModClassTerms { get; set; }

        DbSet<ModClassTime> ModClassTimes { get; set; }

        DbSet<ModDepartment> ModDepartments { get; set; }

        DbSet<ModExpgroup> ModExpgroups { get; set; }

        DbSet<ModGroup> ModGroups { get; set; }

        DbSet<ModGroupleader> ModGroupleaders { get; set; }

        DbSet<ModLession> ModLessions { get; set; }

        DbSet<ModLessionCategory> ModLessionCategories { get; set; }

        DbSet<ModLessionPrice> ModLessionPrices { get; set; }

        DbSet<ModLessionTime> ModLessionTimes { get; set; }

        DbSet<ModLog> ModLogs { get; set; }

        DbSet<ModMeeting> ModMeetings { get; set; }

        DbSet<ModMeetingMember> ModMeetingMembers { get; set; }

        DbSet<ModMember> ModMembers { get; set; }

        DbSet<ModMemberClass> ModMemberClasses { get; set; }

        DbSet<ModMemberClassDay> ModMemberClassDays { get; set; }

        DbSet<ModMemberClassDayTerm> ModMemberClassDayTerms { get; set; }

        DbSet<ModMemberClassTime> ModMemberClassTimes { get; set; }

        DbSet<ModMemberInTag> ModMemberInTags { get; set; }

        DbSet<ModMemberLog> ModMemberLogs { get; set; }

        DbSet<ModMemberMinister> ModMemberMinisters { get; set; }

        DbSet<ModMemberMinisterLog> ModMemberMinisterLogs { get; set; }

        DbSet<ModMinister> ModMinisters { get; set; }

        DbSet<ModMinisterGroup> ModMinisterGroups { get; set; }

        DbSet<ModNewcommer> ModNewcommers { get; set; }

        DbSet<ModNews> ModNews { get; set; }

        DbSet<ModOrder> ModOrders { get; set; }

        DbSet<ModOrderInvoice> ModOrderInvoices { get; set; }

        DbSet<ModPreorder> ModPreorders { get; set; }

        DbSet<ModRollcall> ModRollcalls { get; set; }

        DbSet<ModRollcallWork> ModRollcallWorks { get; set; }

        DbSet<ModStatistic> ModStatistics { get; set; }

        DbSet<ModStatisticDetail> ModStatisticDetails { get; set; }

        DbSet<ModTag> ModTags { get; set; }

        DbSet<ModTeacher> ModTeachers { get; set; }

        DbSet<ModZone> ModZones { get; set; }

        DbSet<ModZoneleader> ModZoneleaders { get; set; }

        DbSet<ModZonesupervisor> ModZonesupervisors { get; set; }

        DbSet<SecRole> SecRoles { get; set; }

        DbSet<SecUser> SecUsers { get; set; }

        DbSet<SecUserRole> SecUserRoles { get; set; }

        DbSet<SysAdminPermission> SysAdminPermissions { get; set; }

        DbSet<SysOrgUser> SysOrgUsers { get; set; }

        DbSet<SysOrganization> SysOrganizations { get; set; }

        DbSet<SysPermission> SysPermissions { get; set; }

        DbSet<SysPortal> SysPortals { get; set; }

        DbSet<SysSeedIdentity> SysSeedIdentities { get; set; }

        DbSet<SysSetting> SysSettings { get; set; }

        DbSet<SysSmsResult> SysSmsResults { get; set; }

        DbSet<VwAreaSupervisor> VwAreaSupervisors { get; set; }

        DbSet<VwAspnetApplication> VwAspnetApplications { get; set; }

        DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; }

        DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; }

        DbSet<VwAspnetRole> VwAspnetRoles { get; set; }

        DbSet<VwAspnetUser> VwAspnetUsers { get; set; }

        DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; }

        DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; }

        DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; }

        DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; }

        DbSet<VwCampaignMember> VwCampaignMembers { get; set; }

        DbSet<VwCheckInMemberClass> VwCheckInMemberClasses { get; set; }

        DbSet<VwExpGroup> VwExpGroups { get; set; }

        DbSet<VwGroup> VwGroups { get; set; }

        DbSet<VwMeetingMember> VwMeetingMembers { get; set; }

        DbSet<VwMemberClass> VwMemberClasses { get; set; }

        DbSet<VwMemberClassDay> VwMemberClassDays { get; set; }

        DbSet<VwMemberMinister> VwMemberMinisters { get; set; }

        DbSet<VwMemberSummary> VwMemberSummaries { get; set; }

        DbSet<VwMemberTag> VwMemberTags { get; set; }

        DbSet<VwOrderInvoice> VwOrderInvoices { get; set; }

        DbSet<VwOrderRecord> VwOrderRecords { get; set; }

        DbSet<VwPreOrder> VwPreOrders { get; set; }

        DbSet<VwRollCall> VwRollCalls { get; set; }

        DbSet<VwWorkSignup> VwWorkSignups { get; set; }

        DbSet<VwZoneSupervisor> VwZoneSupervisors { get; set; }

        DbSet<SystemConfig> SystemConfigs { get; set; }

        DbSet<User> Users { get; set; }
        DbSet<QuestionnaireSatisfyUser> QuestionnaireSatisfyUsers { get; set; }

   

        DbSet<UserBankAccount> UserBankAccounts { get; set; }

        DbSet<UserContact> UserContacts { get; set; }

        DbSet<UserCourse> UserCourses { get; set; }

        DbSet<UserExpertise> UserExpertises { get; set; }

        DbSet<UserFamily> UserFamilies { get; set; }

        DbSet<UserSociety> UserSocieties { get; set; }

        DbSet<Questionnaire> Questionnaires { get; set; }

        DbSet<QuestionnaireDetail> QuestionnaireDetails { get; set; }

        DbSet<UserQuestionnaire> UserQuestionnaires { get; set; }

        DbSet<UserPastoralCare> UserPastoralCares { get; set; }

        DbSet<Pastoral> Pastorals { get; set; }

        DbSet<PastoralMeeting> PastoralMeetings { get; set; }

        DbSet<PastoralMeetingUser> PastoralMeetingUsers { get; set; }

        DbSet<MinistryMeeting> MinistryMeetings { get; set; }

        DbSet<MinistryMeetingUser> MinistryMeetingUsers { get; set; }

        DbSet<MinistryDef> MinistryDefs { get; set; }

        DbSet<Ministry> Ministries { get; set; }

        DbSet<MinistryResp> MinistryResps { get; set; }

        DbSet<MinistryRespUser> MinistryRespUsers { get; set; }

        DbSet<MinistrySchedule> MinistrySchedules { get; set; }

        DbSet<MinistryScheduleDetail> MinistryScheduleDetails { get; set; }

        DbSet<Dept> Depts { get; set; }

        DbSet<Organization> Organizations { get; set; }

        DbSet<OrganizationUser> OrganizationUsers { get; set; }

        DbSet<MeetingPoint> MeetingPoints { get; set; }

        DbSet<MessageInformation> MessageInformations { get; set; }

        DbSet<MessageInformationUser> MessageInformationUsers { get; set; }

        //課程相關表
        DbSet<CourseManagementType> CourseManagementTypes { get; set; }
        DbSet<CourseManagement> CourseManagements { get; set; }

        DbSet<CourseManagementFilter> CourseManagementFilters { get; set; }
        DbSet<CourseManagementFilterResp> CourseManagementFilterResps { get; set; }
        DbSet<CourseManagementFilterPastoral> CourseManagementFilterPastorals { get; set; }
        DbSet<CourseManagementFilterCourse> CourseManagementFilterCourses { get; set; }
        DbSet<CourseManagementFilterUser> CourseManagementFilterUsers { get; set; }



        DbSet<CourseManagementAppendix> CourseManagementAppendixs { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<CoursePrice> CoursePrices { get; set; }
        DbSet<CourseOrganization> CourseOrganizations { get; set; }

        DbSet<CourseAppendix> CourseAppendixs { get; set; }
        DbSet<CourseTimeSchedule> CourseTimeSchedules { get; set; }
        DbSet<CourseTimeScheduleTeacher> CourseTimeScheduleTeachers { get; set; }
        DbSet<Teacher> Teachers { get; set; }

        DbSet<CourseTimeScheduleUser> CourseTimeScheduleUsers { get; set; }

        DbSet<ShoppingCart> ShoppingCarts { get; set; }
        DbSet<ShoppingOrder> ShoppingOrders { get; set; }
        DbSet<ShoppingOrderDetail> ShoppingOrderDetails { get; set; }

        DbSet<ShoppingTrack> ShoppingTracks { get; set; }

        DbSet<QrCode> QrCodes { get; set; }



        /// <summary>
        /// 
        /// </summary>
        DbSet<Role> Roles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DbSet<RoleUserMapping> RoleUserMappings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DbSet<Privilege> Privileges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DbSet<RolePrivilegeMapping> RolePrivilegeMappings { get; set; }


        DbSet<UploadFile> UploadFiles { get; set; }

        //#CreateDB

        #endregion


        #region Others

        #endregion
    }
}
