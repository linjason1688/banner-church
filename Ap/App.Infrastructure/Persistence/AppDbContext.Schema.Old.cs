using App.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence
{
    /// <summary>
    /// </summary>
    public partial class AppDbContext
    {
        public DbSet<AspnetApplication> AspnetApplications { get; set; }

        public DbSet<AspnetMembership> AspnetMemberships { get; set; }

        public DbSet<AspnetPath> AspnetPaths { get; set; }

        public DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }

        public DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }

        public DbSet<AspnetProfile> AspnetProfiles { get; set; }

        public DbSet<AspnetRole> AspnetRoles { get; set; }

        public DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

        public DbSet<AspnetUser> AspnetUsers { get; set; }

        public DbSet<AspnetUsersInRole> AspnetUsersInRoles { get; set; }

        public DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; }

        public DbSet<ErrCancel> ErrCancels { get; set; }

        public DbSet<ModActivity> ModActivities { get; set; }

        public DbSet<ModActivityWork> ModActivityWorks { get; set; }

        public DbSet<ModActivityWorkShare> ModActivityWorkShares { get; set; }

        public DbSet<ModActivityWorkSignup> ModActivityWorkSignups { get; set; }

        public DbSet<ModArea> ModAreas { get; set; }

        public DbSet<ModArealeader> ModArealeaders { get; set; }

        public DbSet<ModAreasupervisor> ModAreasupervisors { get; set; }

        public DbSet<ModCampaign> ModCampaigns { get; set; }

        public DbSet<ModCampaignMember> ModCampaignMembers { get; set; }

        public DbSet<ModCampaignSpday> ModCampaignSpdays { get; set; }

        public DbSet<ModCareer> ModCareers { get; set; }

        public DbSet<ModClass> ModClasses { get; set; }

        public DbSet<ModClassDay> ModClassDays { get; set; }

        public DbSet<ModClassPrice> ModClassPrices { get; set; }

        public DbSet<ModClassTerm> ModClassTerms { get; set; }

        public DbSet<ModClassTime> ModClassTimes { get; set; }

        public DbSet<ModDepartment> ModDepartments { get; set; }

        public DbSet<ModExpgroup> ModExpgroups { get; set; }

        public DbSet<ModGroup> ModGroups { get; set; }

        public DbSet<ModGroupleader> ModGroupleaders { get; set; }

        public DbSet<ModLession> ModLessions { get; set; }

        public DbSet<ModLessionCategory> ModLessionCategories { get; set; }

        public DbSet<ModLessionPrice> ModLessionPrices { get; set; }

        public DbSet<ModLessionTime> ModLessionTimes { get; set; }

        public DbSet<ModLog> ModLogs { get; set; }

        public DbSet<ModMeeting> ModMeetings { get; set; }

        public DbSet<ModMeetingMember> ModMeetingMembers { get; set; }

        public DbSet<ModMember> ModMembers { get; set; }

        public DbSet<ModMemberClass> ModMemberClasses { get; set; }

        public DbSet<ModMemberClassDay> ModMemberClassDays { get; set; }

        public DbSet<ModMemberClassDayTerm> ModMemberClassDayTerms { get; set; }

        public DbSet<ModMemberClassTime> ModMemberClassTimes { get; set; }

        public DbSet<ModMemberInTag> ModMemberInTags { get; set; }

        public DbSet<ModMemberLog> ModMemberLogs { get; set; }

        public DbSet<ModMemberMinister> ModMemberMinisters { get; set; }

        public DbSet<ModMemberMinisterLog> ModMemberMinisterLogs { get; set; }

        public DbSet<ModMinister> ModMinisters { get; set; }

        public DbSet<ModMinisterGroup> ModMinisterGroups { get; set; }

        public DbSet<ModNewcommer> ModNewcommers { get; set; }

        public DbSet<ModNews> ModNews { get; set; }

        public DbSet<ModOrder> ModOrders { get; set; }

        public DbSet<ModOrderInvoice> ModOrderInvoices { get; set; }

        public DbSet<ModPreorder> ModPreorders { get; set; }

        public DbSet<ModRollcall> ModRollcalls { get; set; }

        public DbSet<ModRollcallWork> ModRollcallWorks { get; set; }

        public DbSet<ModStatistic> ModStatistics { get; set; }

        public DbSet<ModStatisticDetail> ModStatisticDetails { get; set; }

        public DbSet<ModTag> ModTags { get; set; }

        public DbSet<ModTeacher> ModTeachers { get; set; }

        public DbSet<ModZone> ModZones { get; set; }

        public DbSet<ModZoneleader> ModZoneleaders { get; set; }

        public DbSet<ModZonesupervisor> ModZonesupervisors { get; set; }

        public DbSet<SecRole> SecRoles { get; set; }

        public DbSet<SecUser> SecUsers { get; set; }

        public DbSet<SecUserRole> SecUserRoles { get; set; }

        public DbSet<SysAdminPermission> SysAdminPermissions { get; set; }

        public DbSet<SysOrgUser> SysOrgUsers { get; set; }

        public DbSet<SysOrganization> SysOrganizations { get; set; }

        public DbSet<SysPermission> SysPermissions { get; set; }

        public DbSet<SysPortal> SysPortals { get; set; }

        public DbSet<SysSeedIdentity> SysSeedIdentities { get; set; }

        public DbSet<SysSetting> SysSettings { get; set; }

        public DbSet<SysSmsResult> SysSmsResults { get; set; }

        public DbSet<VwAreaSupervisor> VwAreaSupervisors { get; set; }

        public DbSet<VwAspnetApplication> VwAspnetApplications { get; set; }

        public DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; }

        public DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; }

        public DbSet<VwAspnetRole> VwAspnetRoles { get; set; }

        public DbSet<VwAspnetUser> VwAspnetUsers { get; set; }

        public DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; }

        public DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; }

        public DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; }

        public DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; }

        public DbSet<VwCampaignMember> VwCampaignMembers { get; set; }

        public DbSet<VwCheckInMemberClass> VwCheckInMemberClasses { get; set; }

        public DbSet<VwExpGroup> VwExpGroups { get; set; }

        public DbSet<VwGroup> VwGroups { get; set; }

        public DbSet<VwMeetingMember> VwMeetingMembers { get; set; }

        public DbSet<VwMemberClass> VwMemberClasses { get; set; }

        public DbSet<VwMemberClassDay> VwMemberClassDays { get; set; }

        public DbSet<VwMemberMinister> VwMemberMinisters { get; set; }

        public DbSet<VwMemberSummary> VwMemberSummaries { get; set; }

        public DbSet<VwMemberTag> VwMemberTags { get; set; }

        public DbSet<VwOrderInvoice> VwOrderInvoices { get; set; }

        public DbSet<VwOrderRecord> VwOrderRecords { get; set; }

        public DbSet<VwPreOrder> VwPreOrders { get; set; }

        public DbSet<VwRollCall> VwRollCalls { get; set; }

        public DbSet<VwWorkSignup> VwWorkSignups { get; set; }

        public DbSet<VwZoneSupervisor> VwZoneSupervisors { get; set; }

        public DbSet<SystemConfig> SystemConfigs { get; set; }
        
        
        protected void OnModelCreatingOld(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspnetApplication>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("aspnet_Applications");

                    entity.Property(e => e.ApplicationName)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.Description).HasMaxLength(256);

                    entity.Property(e => e.LoweredApplicationName)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<AspnetMembership>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("aspnet_Membership");

                    entity.Property(e => e.Comment).HasColumnType("ntext");

                    entity.Property(e => e.CreateDate).HasColumnType("datetime");

                    entity.Property(e => e.Email).HasMaxLength(256);

                    entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                    entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                    entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                    entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                    entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                    entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                    entity.Property(e => e.MobilePin)
                       .HasMaxLength(16)
                       .HasColumnName("MobilePIN");

                    entity.Property(e => e.Password)
                       .IsRequired()
                       .HasMaxLength(128);

                    entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                    entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                    entity.Property(e => e.PasswordSalt)
                       .IsRequired()
                       .HasMaxLength(128);
                }
            );

            modelBuilder.Entity<AspnetPath>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("aspnet_Paths");

                    entity.Property(e => e.LoweredPath)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.Path)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<AspnetPersonalizationAllUser>(
                entity =>
                {
                    entity.HasKey(e => e.PathId)
                       .HasName("PK__aspnet_P__CD67DC596EC0713C");

                    entity.ToTable("aspnet_PersonalizationAllUsers");

                    entity.Property(e => e.PathId).ValueGeneratedNever();

                    entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                    entity.Property(e => e.PageSettings)
                       .IsRequired()
                       .HasColumnType("image");
                }
            );

            modelBuilder.Entity<AspnetPersonalizationPerUser>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("aspnet_PersonalizationPerUser");

                    entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                    entity.Property(e => e.PageSettings)
                       .IsRequired()
                       .HasColumnType("image");
                }
            );

            modelBuilder.Entity<AspnetProfile>(
                entity =>
                {
                    entity.HasKey(e => e.UserId)
                       .HasName("PK__aspnet_P__1788CC4C44CA3770");

                    entity.ToTable("aspnet_Profile");

                    entity.Property(e => e.UserId).ValueGeneratedNever();

                    entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                    entity.Property(e => e.PropertyNames)
                       .IsRequired()
                       .HasColumnType("ntext");

                    entity.Property(e => e.PropertyValuesBinary)
                       .IsRequired()
                       .HasColumnType("image");

                    entity.Property(e => e.PropertyValuesString)
                       .IsRequired()
                       .HasColumnType("ntext");
                }
            );

            modelBuilder.Entity<AspnetRole>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("aspnet_Roles");

                    entity.Property(e => e.Description).HasMaxLength(256);

                    entity.Property(e => e.LoweredRoleName)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.RoleName)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<AspnetSchemaVersion>(
                entity =>
                {
                    entity.HasKey(
                            e => new
                            {
                                e.Feature,
                                e.CompatibleSchemaVersion
                            }
                        )
                       .HasName("PK__aspnet_S__5A1E6BC12180FB33");

                    entity.ToTable("aspnet_SchemaVersions");

                    entity.Property(e => e.Feature).HasMaxLength(128);

                    entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
                }
            );

            modelBuilder.Entity<AspnetUser>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("aspnet_Users");

                    entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                    entity.Property(e => e.LoweredUserName)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.MobileAlias).HasMaxLength(16);

                    entity.Property(e => e.UserName)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<AspnetUsersInRole>(
                entity =>
                {
                    entity.HasKey(
                            e => new
                            {
                                e.UserId,
                                e.RoleId
                            }
                        )
                       .HasName("PK__aspnet_U__AF2760AD55F4C372");

                    entity.ToTable("aspnet_UsersInRoles");
                }
            );

            modelBuilder.Entity<AspnetWebEventEvent>(
                entity =>
                {
                    entity.HasKey(e => e.EventId)
                       .HasName("PK__aspnet_W__7944C810078C1F06");

                    entity.ToTable("aspnet_WebEvent_Events");

                    entity.Property(e => e.EventId)
                       .HasMaxLength(32)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.ApplicationPath).HasMaxLength(256);

                    entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);

                    entity.Property(e => e.Details).HasColumnType("ntext");

                    entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");

                    entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");

                    entity.Property(e => e.EventTime).HasColumnType("datetime");

                    entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");

                    entity.Property(e => e.EventType)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.ExceptionType).HasMaxLength(256);

                    entity.Property(e => e.MachineName)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.Message).HasMaxLength(1024);

                    entity.Property(e => e.RequestUrl).HasMaxLength(1024);
                }
            );

            modelBuilder.Entity<ErrCancel>(
                entity =>
                {
                    entity.HasKey(e => e.Idn);

                    entity.ToTable("ErrCancel");

                    entity.Property(e => e.Idn)
                       .HasMaxLength(20)
                       .IsUnicode(false);
                }
            );

            modelBuilder.Entity<ModActivity>(
                entity =>
                {
                    entity.ToTable("MOD_ACTIVITY");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateEnd).HasColumnType("datetime");

                    entity.Property(e => e.DateSignUpDue).HasColumnType("datetime");

                    entity.Property(e => e.DateStart).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.FilePath).HasMaxLength(500);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.TargetRole).HasMaxLength(50);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModActivityWork>(
                entity =>
                {
                    entity.ToTable("MOD_ACTIVITY_WORK");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.Date).HasColumnType("datetime");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.MinisterRequired).HasMaxLength(500);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.TargetRole).HasMaxLength(50);

                    entity.Property(e => e.TimeEnd).HasMaxLength(50);

                    entity.Property(e => e.TimeStart).HasMaxLength(50);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModActivityWorkShare>(
                entity =>
                {
                    entity.HasKey(
                            e => new
                            {
                                e.WorkId,
                                e.AreaId
                            }
                        )
                       .HasName("PK_MOD_ACTIVITY_WORK_SHARE_1");

                    entity.ToTable("MOD_ACTIVITY_WORK_SHARE");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModActivityWorkSignup>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.WorkId,
                            e.AreaId,
                            e.GroupId,
                            e.MemberId
                        }
                    );

                    entity.ToTable("MOD_ACTIVITY_WORK_SIGNUP");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.GroupName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.MemberName)
                       .IsRequired()
                       .HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModArea>(
                entity =>
                {
                    entity.ToTable("MOD_AREA");

                    entity.Property(e => e.Code)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Leader2Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader2IDNumber");

                    entity.Property(e => e.Leader3Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader3IDNumber");

                    entity.Property(e => e.LeaderIdnumber)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("LeaderIDNumber");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Oid).HasColumnName("OId");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModArealeader>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.AreaId,
                            e.MemberId
                        }
                    );

                    entity.ToTable("MOD_AREALEADER");
                }
            );

            modelBuilder.Entity<ModAreasupervisor>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.AreaId,
                            e.MemberId
                        }
                    );

                    entity.ToTable("MOD_AREASUPERVISOR");
                }
            );

            modelBuilder.Entity<ModCampaign>(
                entity =>
                {
                    entity.ToTable("MOD_CAMPAIGN");

                    entity.Property(e => e.Id).ValueGeneratedNever();

                    entity.Property(e => e.CategoryCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateEnd).HasColumnType("datetime");

                    entity.Property(e => e.DateStart).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.StatusCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModCampaignMember>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.MemberId,
                            e.CampaignId
                        }
                    );

                    entity.ToTable("MOD_CAMPAIGN_MEMBER");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);
                }
            );

            modelBuilder.Entity<ModCampaignSpday>(
                entity =>
                {
                    entity.ToTable("MOD_CAMPAIGN_SPDAY");

                    entity.Property(e => e.Date).HasColumnType("datetime");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModCareer>(
                entity =>
                {
                    entity.ToTable("MOD_CAREER");

                    entity.Property(e => e.Career).HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModClass>(
                entity =>
                {
                    entity.ToTable("MOD_CLASS");

                    entity.Property(e => e.CategoryCode)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.CategoryName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.ClassStartDate).HasColumnType("datetime");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.ContactFax)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactName).HasMaxLength(50);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Credit).HasColumnType("decimal(4, 1)");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.DiscountDueDate).HasColumnType("datetime");

                    entity.Property(e => e.LessionCode)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.LessionName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Properties).HasColumnType("ntext");

                    entity.Property(e => e.Settings1).HasColumnType("ntext");

                    entity.Property(e => e.Settings2).HasColumnType("ntext");

                    entity.Property(e => e.SignUpDueDate).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModClassDay>(
                entity =>
                {
                    entity.ToTable("MOD_CLASS_DAY");

                    entity.Property(e => e.ClassDate).HasColumnType("datetime");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.EndTime).HasColumnType("datetime");

                    entity.Property(e => e.StartTime).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModClassPrice>(
                entity =>
                {
                    entity.ToTable("MOD_CLASS_PRICE");

                    entity.Property(e => e.DueDate).HasColumnType("datetime");

                    entity.Property(e => e.Price).HasColumnType("money");

                    entity.Property(e => e.PriceName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModClassTerm>(
                entity =>
                {
                    entity.ToTable("MOD_CLASS_TERM");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModClassTime>(
                entity =>
                {
                    entity.ToTable("MOD_CLASS_TIME");

                    entity.Property(e => e.ClassCode)
                       .IsRequired()
                       .HasMaxLength(10);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.DiscountDueDate).HasColumnType("datetime");

                    entity.Property(e => e.EndTime).HasColumnType("datetime");

                    entity.Property(e => e.Place).HasMaxLength(255);

                    entity.Property(e => e.SignUpDueDate).HasColumnType("datetime");

                    entity.Property(e => e.StartTime).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.TeacherName).HasMaxLength(50);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModDepartment>(
                entity =>
                {
                    entity.ToTable("MOD_DEPARTMENT");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Leader2Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader2IDNumber");

                    entity.Property(e => e.LeaderIdnumber)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("LeaderIDNumber");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Oid).HasColumnName("OId");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModExpgroup>(
                entity =>
                {
                    entity.ToTable("MOD_EXPGROUP");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateEnd).HasColumnType("datetime");

                    entity.Property(e => e.DateStart).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Leader2Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader2IDNumber");

                    entity.Property(e => e.Leader3Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader3IDNumber");

                    entity.Property(e => e.LeaderIdnumber)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("LeaderIDNumber");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.NewMemE1count).HasColumnName("NewMemE1Count");

                    entity.Property(e => e.StatusCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModGroup>(
                entity =>
                {
                    entity.ToTable("MOD_GROUP");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Leader2Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader2IDNumber");

                    entity.Property(e => e.Leader3Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader3IDNumber");

                    entity.Property(e => e.LeaderIdnumber)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("LeaderIDNumber");

                    entity.Property(e => e.MeetingAddress).HasMaxLength(255);

                    entity.Property(e => e.MeetingTime).HasMaxLength(50);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Oid).HasColumnName("OId");

                    entity.Property(e => e.StatusCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModGroupleader>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.GroupId,
                            e.MemberId
                        }
                    );

                    entity.ToTable("MOD_GROUPLEADER");
                }
            );

            modelBuilder.Entity<ModLession>(
                entity =>
                {
                    entity.ToTable("MOD_LESSION");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.ContactFax)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactName).HasMaxLength(50);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Credit).HasColumnType("decimal(4, 1)");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.LessionCode)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.LessionName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Properties).HasColumnType("ntext");

                    entity.Property(e => e.Settings1).HasColumnType("ntext");

                    entity.Property(e => e.Settings2).HasColumnType("ntext");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModLessionCategory>(
                entity =>
                {
                    entity.ToTable("MOD_LESSION_CATEGORY");

                    entity.Property(e => e.CategoryCode)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.CategoryName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);
                }
            );

            modelBuilder.Entity<ModLessionPrice>(
                entity =>
                {
                    entity.ToTable("MOD_LESSION_PRICE");

                    entity.Property(e => e.Price).HasColumnType("money");

                    entity.Property(e => e.PriceName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModLessionTime>(
                entity =>
                {
                    entity.ToTable("MOD_LESSION_TIME");

                    entity.Property(e => e.ClassCode)
                       .IsRequired()
                       .HasMaxLength(10);

                    entity.Property(e => e.EndTime).HasColumnType("datetime");

                    entity.Property(e => e.Place).HasMaxLength(255);

                    entity.Property(e => e.StartTime).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.TeacherName).HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModLog>(
                entity =>
                {
                    entity.ToTable("MOD_LOG");

                    entity.Property(e => e.Date).HasColumnType("datetime");

                    entity.Property(e => e.Key)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModMeeting>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.GroupId,
                            e.Date
                        }
                    );

                    entity.ToTable("MOD_MEETING");

                    entity.Property(e => e.Date).HasColumnType("datetime");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.GroupName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.MeetingTime).HasMaxLength(50);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModMeetingMember>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.GroupId,
                            e.Date,
                            e.MemberId
                        }
                    );

                    entity.ToTable("MOD_MEETING_MEMBER");

                    entity.Property(e => e.Date).HasColumnType("datetime");

                    entity.Property(e => e.MemberName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.MemberRoles).HasMaxLength(500);

                    entity.Property(e => e.MemberStatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);
                }
            );

            modelBuilder.Entity<ModMember>(
                entity =>
                {
                    entity.ToTable("MOD_MEMBER");

                    entity.Property(e => e.Area).HasMaxLength(255);

                    entity.Property(e => e.BaptizeGroup).HasMaxLength(50);

                    entity.Property(e => e.BaptizeOrgName).HasMaxLength(255);

                    entity.Property(e => e.Baptizeday).HasColumnType("datetime");

                    entity.Property(e => e.Baptizer).HasMaxLength(50);

                    entity.Property(e => e.Birthday).HasColumnType("datetime");

                    entity.Property(e => e.BizPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Career).HasMaxLength(50);

                    entity.Property(e => e.Child1).HasMaxLength(50);

                    entity.Property(e => e.Child2).HasMaxLength(50);

                    entity.Property(e => e.Child3).HasMaxLength(50);

                    entity.Property(e => e.Child4).HasMaxLength(50);

                    entity.Property(e => e.Comment).HasColumnType("ntext");

                    entity.Property(e => e.ContactAddress).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactCellPhone2)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactCity).HasMaxLength(20);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactTimes).HasMaxLength(50);

                    entity.Property(e => e.ContactZipCode)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Department).HasMaxLength(255);

                    entity.Property(e => e.EducationSchool).HasMaxLength(500);

                    entity.Property(e => e.Email).HasMaxLength(255);

                    entity.Property(e => e.EngName).HasMaxLength(255);

                    entity.Property(e => e.Father).HasMaxLength(50);

                    entity.Property(e => e.Fax)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.FirstGroupMeeting).HasColumnType("datetime");

                    entity.Property(e => e.FirstSermon).HasColumnType("datetime");

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.GrantedDate).HasColumnType("datetime");

                    entity.Property(e => e.Group).HasMaxLength(255);

                    entity.Property(e => e.GroupLeaderDate).HasColumnType("datetime");

                    entity.Property(e => e.HomeAddress).HasMaxLength(255);

                    entity.Property(e => e.Identifier).HasMaxLength(10);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.Interests).HasMaxLength(50);

                    entity.Property(e => e.Introducer).HasMaxLength(255);

                    entity.Property(e => e.IntroducerGroup).HasMaxLength(255);

                    entity.Property(e => e.LastMovedDate).HasColumnType("datetime");

                    entity.Property(e => e.LevelofEducation).HasMaxLength(50);

                    entity.Property(e => e.Minister).HasMaxLength(50);

                    entity.Property(e => e.Mother).HasMaxLength(50);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.OrgName).HasMaxLength(255);

                    entity.Property(e => e.OrgPriest).HasMaxLength(255);

                    entity.Property(e => e.OrgTitle).HasMaxLength(255);

                    entity.Property(e => e.RelativeCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.RelativeName).HasMaxLength(255);

                    entity.Property(e => e.RelativeRelation).HasMaxLength(50);

                    entity.Property(e => e.SchoolTimeCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.SettleDate).HasColumnType("datetime");

                    entity.Property(e => e.SourceCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Spouse).HasMaxLength(50);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);

                    entity.Property(e => e.Zone).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModMemberClass>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("MOD_MEMBER_CLASS");

                    entity.Property(e => e.CategoryCode)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.CategoryName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.Credit).HasColumnType("decimal(4, 1)");

                    entity.Property(e => e.CreditEarn).HasColumnType("decimal(4, 1)");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateRecorded).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Id).ValueGeneratedOnAdd();

                    entity.Property(e => e.LessionCode)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.LessionName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.OrderIdentifer)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.Price).HasColumnType("money");

                    entity.Property(e => e.PriceName).HasMaxLength(50);

                    entity.Property(e => e.RecordStatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Team).HasMaxLength(50);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModMemberClassDay>(
                entity =>
                {
                    entity.ToTable("MOD_MEMBER_CLASS_DAY");

                    entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                    entity.Property(e => e.ClassDate).HasColumnType("datetime");

                    entity.Property(e => e.Comment).HasMaxLength(500);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.EndTime).HasColumnType("datetime");

                    entity.Property(e => e.StartTime).HasColumnType("datetime");

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModMemberClassDayTerm>(
                entity =>
                {
                    entity.ToTable("MOD_MEMBER_CLASS_DAY_TERM");

                    entity.Property(e => e.Comment).HasMaxLength(500);
                }
            );

            modelBuilder.Entity<ModMemberClassTime>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("MOD_MEMBER_CLASS_TIME");

                    entity.Property(e => e.ClassCode)
                       .IsRequired()
                       .HasMaxLength(10);

                    entity.Property(e => e.Id).ValueGeneratedOnAdd();
                }
            );

            modelBuilder.Entity<ModMemberInTag>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.MemberId,
                            e.TagId
                        }
                    );

                    entity.ToTable("MOD_MEMBER_IN_TAG");
                }
            );

            modelBuilder.Entity<ModMemberLog>(
                entity =>
                {
                    entity.ToTable("MOD_MEMBER_LOG");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.MemberName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.NewState).IsRequired();

                    entity.Property(e => e.OldState).IsRequired();

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModMemberMinister>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.MemberId,
                            e.MinisterId
                        }
                    );

                    entity.ToTable("MOD_MEMBER_MINISTER");
                }
            );

            modelBuilder.Entity<ModMemberMinisterLog>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.MemberId,
                            e.MinisterId,
                            e.DateStart
                        }
                    );

                    entity.ToTable("MOD_MEMBER_MINISTER_LOG");

                    entity.Property(e => e.DateStart).HasColumnType("datetime");

                    entity.Property(e => e.DateEnd).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.MinisterName).HasMaxLength(50);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModMinister>(
                entity =>
                {
                    entity.ToTable("MOD_MINISTER");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModMinisterGroup>(
                entity =>
                {
                    entity.ToTable("MOD_MINISTER_GROUP");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModNewcommer>(
                entity =>
                {
                    entity.ToTable("MOD_NEWCOMMER");

                    entity.Property(e => e.AssignAreaName).HasMaxLength(50);

                    entity.Property(e => e.AssignGroupName).HasMaxLength(50);

                    entity.Property(e => e.AssignUser).HasMaxLength(255);

                    entity.Property(e => e.AssignZoneName).HasMaxLength(50);

                    entity.Property(e => e.Birthday).HasColumnType("datetime");

                    entity.Property(e => e.Career).HasMaxLength(50);

                    entity.Property(e => e.Comment).HasColumnType("ntext");

                    entity.Property(e => e.ContactAddress).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactCity).HasMaxLength(20);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactZipCode)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.DateAssign).HasColumnType("datetime");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateEntry).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.EducationSchool).HasMaxLength(255);

                    entity.Property(e => e.Email).HasMaxLength(255);

                    entity.Property(e => e.EngName).HasMaxLength(255);

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.LevelofEducation).HasMaxLength(50);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.NcActivityGroup)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_ActivityGroup");

                    entity.Property(e => e.NcActivityName)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_ActivityName");

                    entity.Property(e => e.NcActivityNo)
                       .HasMaxLength(20)
                       .HasColumnName("Nc_ActivityNo");

                    entity.Property(e => e.NcChristianComeReason)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_ChristianComeReason");

                    entity.Property(e => e.NcDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Nc_Date");

                    entity.Property(e => e.NcFollowGroup)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_FollowGroup");

                    entity.Property(e => e.NcGroupIntentionId).HasColumnName("Nc_GroupIntentionId");

                    entity.Property(e => e.NcInterviewComment).HasColumnName("Nc_InterviewComment");

                    entity.Property(e => e.NcInterviewContent).HasColumnName("Nc_InterviewContent");

                    entity.Property(e => e.NcInterviewDate)
                       .HasColumnType("datetime")
                       .HasColumnName("Nc_InterviewDate");

                    entity.Property(e => e.NcInterviewer)
                       .HasMaxLength(50)
                       .HasColumnName("Nc_Interviewer");

                    entity.Property(e => e.NcIntroducer)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_Introducer");

                    entity.Property(e => e.NcIntroducerGroup)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_IntroducerGroup");

                    entity.Property(e => e.NcIntroducerIsRelated).HasColumnName("Nc_IntroducerIsRelated");

                    entity.Property(e => e.NcIntroducerPhone)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_IntroducerPhone");

                    entity.Property(e => e.NcIntroducerRelationship)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_IntroducerRelationship");

                    entity.Property(e => e.NcIsChristian).HasColumnName("Nc_IsChristian");

                    entity.Property(e => e.NcIsFirstTimeCome).HasColumnName("Nc_IsFirstTimeCome");

                    entity.Property(e => e.NcIsReadyForE1).HasColumnName("Nc_IsReadyForE1");

                    entity.Property(e => e.NcOrginalChurch)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_OrginalChurch");

                    entity.Property(e => e.NcOrginalChurchLocation)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_OrginalChurchLocation");

                    entity.Property(e => e.NcOrginalChurchPriest)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_OrginalChurchPriest");

                    entity.Property(e => e.NcPrayContent).HasColumnName("Nc_PrayContent");

                    entity.Property(e => e.NcPreferContactTimes)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_PreferContactTimes");

                    entity.Property(e => e.NcPreferGroup)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_PreferGroup");

                    entity.Property(e => e.NcPreferGroupDayTime)
                       .HasColumnType("datetime")
                       .HasColumnName("Nc_PreferGroupDayTime");

                    entity.Property(e => e.NcPreferGroupTimes)
                       .HasMaxLength(255)
                       .HasColumnName("Nc_PreferGroupTimes");

                    entity.Property(e => e.NcPreferGroupTypes)
                       .HasMaxLength(500)
                       .HasColumnName("Nc_PreferGroupTypes");

                    entity.Property(e => e.NcPreferGroupWeekDay).HasColumnName("Nc_PreferGroupWeekDay");

                    entity.Property(e => e.NcSuggestions).HasColumnName("Nc_Suggestions");

                    entity.Property(e => e.NcTrace1).HasColumnName("Nc_Trace1");

                    entity.Property(e => e.NcTrace2).HasColumnName("Nc_Trace2");

                    entity.Property(e => e.NcTrace3).HasColumnName("Nc_Trace3");

                    entity.Property(e => e.NcTrace4).HasColumnName("Nc_Trace4");

                    entity.Property(e => e.NcTraceComment).HasColumnName("Nc_TraceComment");

                    entity.Property(e => e.SchoolTimeCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModNews>(
                entity =>
                {
                    entity.ToTable("MOD_NEWS");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.Content).HasColumnType("ntext");

                    entity.Property(e => e.Date).HasColumnType("datetime");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Subject).HasMaxLength(250);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModOrder>(
                entity =>
                {
                    entity.ToTable("MOD_ORDER");

                    entity.Property(e => e.Area).HasMaxLength(255);

                    entity.Property(e => e.Comment).HasMaxLength(500);

                    entity.Property(e => e.ContactAddress).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactEmail).HasMaxLength(255);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactZipCode)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateRecorded).HasColumnType("datetime");

                    entity.Property(e => e.DateTextbook).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Department).HasMaxLength(255);

                    entity.Property(e => e.DepositAmount).HasColumnType("money");

                    entity.Property(e => e.DepositPayedDate).HasColumnType("datetime");

                    entity.Property(e => e.DepositPayee).HasMaxLength(255);

                    entity.Property(e => e.EmgPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Group).HasMaxLength(255);

                    entity.Property(e => e.Identifer)
                       .IsRequired()
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                    entity.Property(e => e.Mates).HasMaxLength(500);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.OrgName).HasMaxLength(255);

                    entity.Property(e => e.PaymentComment).HasMaxLength(500);

                    entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                    entity.Property(e => e.ReceptionDate).HasColumnType("datetime");

                    entity.Property(e => e.RecordStatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.RelativeCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.RelativeName).HasMaxLength(255);

                    entity.Property(e => e.RemainingAmount).HasColumnType("money");

                    entity.Property(e => e.RemainingPayedDate).HasColumnType("datetime");

                    entity.Property(e => e.RemainingPayee).HasMaxLength(255);

                    entity.Property(e => e.Specials).HasColumnType("ntext");

                    entity.Property(e => e.Spouse).HasMaxLength(50);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.StudentCd).HasMaxLength(50);

                    entity.Property(e => e.TextbookName).HasMaxLength(50);

                    entity.Property(e => e.TotalAmount).HasColumnType("money");

                    entity.Property(e => e.UserCancel).HasMaxLength(255);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);

                    entity.Property(e => e.Zone).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModOrderInvoice>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("MOD_ORDER_INVOICE");

                    entity.Property(e => e.Amount).HasColumnType("money");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.CustomNo).HasMaxLength(20);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateRecorded).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Id).ValueGeneratedOnAdd();

                    entity.Property(e => e.Identifier)
                       .IsRequired()
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.Payee).HasMaxLength(255);

                    entity.Property(e => e.PaymentMethod)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.PriceName).HasMaxLength(50);

                    entity.Property(e => e.RecordStatusCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserRecorded).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModPreorder>(
                entity =>
                {
                    entity.ToTable("MOD_PREORDER");

                    entity.Property(e => e.Birthday).HasColumnType("datetime");

                    entity.Property(e => e.Comment).HasMaxLength(500);

                    entity.Property(e => e.ContactAddress).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactEmail).HasMaxLength(255);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactZipCode)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateTextbook).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.EducationSchool).HasMaxLength(500);

                    entity.Property(e => e.EmgPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.Identifer)
                       .IsRequired()
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.Introducer).HasMaxLength(255);

                    entity.Property(e => e.IntroducerGroup).HasMaxLength(255);

                    entity.Property(e => e.Mates).HasMaxLength(500);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.ReceptionDate).HasColumnType("datetime");

                    entity.Property(e => e.RelativeCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.RelativeName).HasMaxLength(255);

                    entity.Property(e => e.RelativeRelation).HasMaxLength(50);

                    entity.Property(e => e.Specials).HasColumnType("ntext");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.StudentCd).HasMaxLength(50);

                    entity.Property(e => e.TextbookName).HasMaxLength(50);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModRollcall>(
                entity =>
                {
                    entity.ToTable("MOD_ROLLCALL");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Comment).HasMaxLength(500);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.GroupName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.MemberIdentifier).HasMaxLength(10);

                    entity.Property(e => e.MemberIdnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("MemberIDNumber");

                    entity.Property(e => e.MemberName).HasMaxLength(255);

                    entity.Property(e => e.No).HasMaxLength(10);

                    entity.Property(e => e.RollCallDate).HasColumnType("datetime");

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModRollcallWork>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.RollCallId,
                            e.ActivityWorkId
                        }
                    );

                    entity.ToTable("MOD_ROLLCALL_WORK");
                }
            );

            modelBuilder.Entity<ModStatistic>(
                entity =>
                {
                    entity.ToTable("MOD_STATISTICS");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModStatisticDetail>(
                entity =>
                {
                    entity.HasKey(
                            e => new
                            {
                                e.StatisticId,
                                e.Date
                            }
                        )
                       .HasName("PK_MOD_STATISTIC_DETAIL_1");

                    entity.ToTable("MOD_STATISTIC_DETAIL");

                    entity.Property(e => e.Date).HasColumnType("datetime");
                }
            );

            modelBuilder.Entity<ModTag>(
                entity =>
                {
                    entity.ToTable("MOD_TAG");

                    entity.Property(e => e.Id).ValueGeneratedNever();

                    entity.Property(e => e.Name).HasMaxLength(250);

                    entity.Property(e => e.TagModule).HasMaxLength(50);
                }
            );

            modelBuilder.Entity<ModTeacher>(
                entity =>
                {
                    entity.ToTable("MOD_TEACHER");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactEmail).HasMaxLength(255);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.TeacherName).HasMaxLength(50);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModZone>(
                entity =>
                {
                    entity.ToTable("MOD_ZONE");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Leader2Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader2IDNumber");

                    entity.Property(e => e.Leader3Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("Leader3IDNumber");

                    entity.Property(e => e.LeaderIdnumber)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("LeaderIDNumber");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Oid).HasColumnName("OId");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<ModZoneleader>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.ZoneId,
                            e.MemberId
                        }
                    );

                    entity.ToTable("MOD_ZONELEADER");
                }
            );

            modelBuilder.Entity<ModZonesupervisor>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.ZoneId,
                            e.MemberId
                        }
                    );

                    entity.ToTable("MOD_ZONESUPERVISOR");
                }
            );

            modelBuilder.Entity<SecRole>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("SEC_ROLE");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Description).HasMaxLength(255);

                    entity.Property(e => e.RoleId).ValueGeneratedOnAdd();

                    entity.Property(e => e.RoleName).HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<SecUser>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("SEC_USER");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.ContactAddress).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactEmail).HasMaxLength(255);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Department).HasMaxLength(255);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.JobTitle).HasMaxLength(255);

                    entity.Property(e => e.Language)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserIdentifier)
                       .HasMaxLength(10)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<SecUserRole>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.UserId,
                            e.RoleId
                        }
                    );

                    entity.ToTable("SEC_USER_ROLE");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<SysAdminPermission>(
                entity =>
                {
                    entity.HasKey(e => e.AdminPermissoinId)
                       .HasName("PK_ADMIN_PERMISSION");

                    entity.ToTable("SYS_ADMIN_PERMISSION");

                    entity.Property(e => e.Definition)
                       .HasMaxLength(50)
                       .IsUnicode(false);

                    entity.Property(e => e.PermissionCd)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode(false);

                    entity.Property(e => e.RoleName).HasMaxLength(256);
                }
            );

            modelBuilder.Entity<SysOrgUser>(
                entity =>
                {
                    entity.HasKey(
                        e => new
                        {
                            e.UserId,
                            e.OrgId
                        }
                    );

                    entity.ToTable("SYS_ORG_USER");
                }
            );

            modelBuilder.Entity<SysOrganization>(
                entity =>
                {
                    entity.HasKey(e => e.OrganizationId);

                    entity.ToTable("SYS_ORGANIZATION");

                    entity.Property(e => e.Address).HasMaxLength(255);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Email).HasMaxLength(255);

                    entity.Property(e => e.Fax)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.InvoiceIdentifier)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.InvoiceTitle).HasMaxLength(255);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Oid).HasColumnName("OId");

                    entity.Property(e => e.Pastor)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.PastorName).HasMaxLength(50);

                    entity.Property(e => e.Pastorphone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Phone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Site).HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);

                    entity.Property(e => e.Zip)
                       .HasMaxLength(20)
                       .IsUnicode(false);
                }
            );

            modelBuilder.Entity<SysPermission>(
                entity =>
                {
                    entity.HasKey(e => e.PermissionId)
                       .HasName("PK_SEC_PERMISSION");

                    entity.ToTable("SYS_PERMISSION");

                    entity.Property(e => e.Definition)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode(false);

                    entity.Property(e => e.Description).HasMaxLength(255);

                    entity.Property(e => e.PermissionCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);
                }
            );

            modelBuilder.Entity<SysPortal>(
                entity =>
                {
                    entity.HasKey(e => e.PortalId);

                    entity.ToTable("SYS_PORTAL");

                    entity.Property(e => e.PortalId).ValueGeneratedNever();

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.DefaultLanguage)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Description).HasMaxLength(255);

                    entity.Property(e => e.Email)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.PortalName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Theme)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<SysSeedIdentity>(
                entity =>
                {
                    entity.HasKey(e => e.SeedTable);

                    entity.ToTable("SYS_SEED_IDENTITY");

                    entity.Property(e => e.SeedTable)
                       .HasMaxLength(50)
                       .IsUnicode(false);

                    entity.Property(e => e.ResetDate).HasColumnType("datetime");

                    entity.Property(e => e.ResetTypeCd)
                       .HasMaxLength(10)
                       .IsUnicode(false);
                }
            );

            modelBuilder.Entity<SysSetting>(
                entity =>
                {
                    entity.HasKey(e => e.SettingName)
                       .HasName("PK_SYS_PORTAL_SETTINGS");

                    entity.ToTable("SYS_SETTINGS");

                    entity.Property(e => e.SettingName).HasMaxLength(255);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);

                    entity.Property(e => e.Value).HasColumnType("ntext");
                }
            );

            modelBuilder.Entity<SysSmsResult>(
                entity =>
                {
                    entity.HasKey(e => e.BatchId);

                    entity.ToTable("SYS_SMS_RESULT");

                    entity.Property(e => e.BatchId).HasMaxLength(100);

                    entity.Property(e => e.Cost).HasColumnType("money");

                    entity.Property(e => e.Credit).HasColumnType("money");

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");
                }
            );

            modelBuilder.Entity<VwAreaSupervisor>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_AreaSupervisor");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);
                }
            );

            modelBuilder.Entity<VwAspnetApplication>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_Applications");

                    entity.Property(e => e.ApplicationName)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.Description).HasMaxLength(256);

                    entity.Property(e => e.LoweredApplicationName)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<VwAspnetMembershipUser>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_MembershipUsers");

                    entity.Property(e => e.Comment).HasColumnType("ntext");

                    entity.Property(e => e.CreateDate).HasColumnType("datetime");

                    entity.Property(e => e.Email).HasMaxLength(256);

                    entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                    entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                    entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                    entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                    entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                    entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                    entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                    entity.Property(e => e.MobileAlias).HasMaxLength(16);

                    entity.Property(e => e.MobilePin)
                       .HasMaxLength(16)
                       .HasColumnName("MobilePIN");

                    entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                    entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                    entity.Property(e => e.UserName)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<VwAspnetProfile>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_Profiles");

                    entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                }
            );

            modelBuilder.Entity<VwAspnetRole>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_Roles");

                    entity.Property(e => e.Description).HasMaxLength(256);

                    entity.Property(e => e.LoweredRoleName)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.RoleName)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<VwAspnetUser>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_Users");

                    entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                    entity.Property(e => e.LoweredUserName)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.MobileAlias).HasMaxLength(16);

                    entity.Property(e => e.UserName)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<VwAspnetUsersInRole>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_UsersInRoles");
                }
            );

            modelBuilder.Entity<VwAspnetWebPartStatePath>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_WebPartState_Paths");

                    entity.Property(e => e.LoweredPath)
                       .IsRequired()
                       .HasMaxLength(256);

                    entity.Property(e => e.Path)
                       .IsRequired()
                       .HasMaxLength(256);
                }
            );

            modelBuilder.Entity<VwAspnetWebPartStateShared>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_WebPartState_Shared");

                    entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                }
            );

            modelBuilder.Entity<VwAspnetWebPartStateUser>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_aspnet_WebPartState_User");

                    entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                }
            );

            modelBuilder.Entity<VwCampaignMember>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_CampaignMember");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.CampaignCategoryCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.CampaignDateEnd).HasColumnType("datetime");

                    entity.Property(e => e.CampaignDateStart).HasColumnType("datetime");

                    entity.Property(e => e.CampaignStatusCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.GroupName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Identifier).HasMaxLength(10);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.Introducer).HasMaxLength(255);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwCheckInMemberClass>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_CheckInMemberClass");

                    entity.Property(e => e.Area).HasMaxLength(50);

                    entity.Property(e => e.Birthday).HasColumnType("datetime");

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Credit).HasColumnType("decimal(4, 1)");

                    entity.Property(e => e.CreditEarn).HasColumnType("decimal(4, 1)");

                    entity.Property(e => e.Department).HasMaxLength(50);

                    entity.Property(e => e.Gender)
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.Group).HasMaxLength(50);

                    entity.Property(e => e.Identifier).HasMaxLength(10);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.MemberClassTime1).HasMaxLength(10);

                    entity.Property(e => e.MemberClassTime2).HasMaxLength(10);

                    entity.Property(e => e.MemberClassTime3).HasMaxLength(10);

                    entity.Property(e => e.MemberName).HasMaxLength(255);

                    entity.Property(e => e.OrgName).HasMaxLength(255);

                    entity.Property(e => e.Price).HasColumnType("money");

                    entity.Property(e => e.SelectedClassStartDate).HasColumnType("datetime");

                    entity.Property(e => e.SelectedClassTime).HasMaxLength(10);

                    entity.Property(e => e.Specials).HasColumnType("ntext");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Team).HasMaxLength(50);

                    entity.Property(e => e.TotalAmount).HasColumnType("money");

                    entity.Property(e => e.Zone).HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwExpGroup>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_ExpGroup");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Type2MemScount).HasColumnName("Type2MemSCount");

                    entity.Property(e => e.Type2Scount).HasColumnName("Type2SCount");

                    entity.Property(e => e.Type3MemScount).HasColumnName("Type3MemSCount");

                    entity.Property(e => e.Type3Scount).HasColumnName("Type3SCount");
                }
            );

            modelBuilder.Entity<VwGroup>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_Group");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.DepName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.GroupLeaderName).HasMaxLength(255);

                    entity.Property(e => e.MeetingAddress).HasMaxLength(255);

                    entity.Property(e => e.MeetingTime).HasMaxLength(50);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.OrgName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwMeetingMember>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_MeetingMember");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Date).HasColumnType("datetime");

                    entity.Property(e => e.GroupName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.MemberName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.MemberRoles).HasMaxLength(500);

                    entity.Property(e => e.MemberStatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwMemberClass>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_MemberClass");

                    entity.Property(e => e.Area).HasMaxLength(50);

                    entity.Property(e => e.BaptizeOrgName).HasMaxLength(255);

                    entity.Property(e => e.Baptizeday).HasColumnType("datetime");

                    entity.Property(e => e.Birthday).HasColumnType("datetime");

                    entity.Property(e => e.CategoryCode)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.CategoryName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.ContactAddress).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactZipCode)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateRecorded).HasColumnType("datetime");

                    entity.Property(e => e.DateTextbook).HasColumnType("datetime");

                    entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                    entity.Property(e => e.Department).HasMaxLength(50);

                    entity.Property(e => e.EducationSchool).HasMaxLength(500);

                    entity.Property(e => e.Email).HasMaxLength(255);

                    entity.Property(e => e.EmgPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.Group).HasMaxLength(50);

                    entity.Property(e => e.Identifier).HasMaxLength(10);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.Introducer).HasMaxLength(255);

                    entity.Property(e => e.IntroducerGroup).HasMaxLength(255);

                    entity.Property(e => e.LessionCode)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.LessionName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Mates).HasMaxLength(500);

                    entity.Property(e => e.MemberClassTime1).HasMaxLength(10);

                    entity.Property(e => e.MemberClassTime2).HasMaxLength(10);

                    entity.Property(e => e.MemberClassTime3).HasMaxLength(10);

                    entity.Property(e => e.MemberName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.MemberStatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.MemberUserName).HasMaxLength(256);

                    entity.Property(e => e.OrderComment).HasMaxLength(500);

                    entity.Property(e => e.OrderIdentifer)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.OrgName).HasMaxLength(255);

                    entity.Property(e => e.OrgPriest).HasMaxLength(255);

                    entity.Property(e => e.OrgTitle).HasMaxLength(255);

                    entity.Property(e => e.Price).HasColumnType("money");

                    entity.Property(e => e.PriceName).HasMaxLength(50);

                    entity.Property(e => e.ReceptionDate).HasColumnType("datetime");

                    entity.Property(e => e.RecordStatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.RelativeCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.RelativeName).HasMaxLength(255);

                    entity.Property(e => e.RelativeRelation).HasMaxLength(50);

                    entity.Property(e => e.RemainingAmount).HasColumnType("money");

                    entity.Property(e => e.RemainingPayedDate).HasColumnType("datetime");

                    entity.Property(e => e.RemainingPayee).HasMaxLength(255);

                    entity.Property(e => e.SelectedClassStartDate).HasColumnType("datetime");

                    entity.Property(e => e.SelectedClassTime).HasMaxLength(10);

                    entity.Property(e => e.Specials).HasColumnType("ntext");

                    entity.Property(e => e.Spouse).HasMaxLength(50);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.StudentCd).HasMaxLength(50);

                    entity.Property(e => e.Team).HasMaxLength(50);

                    entity.Property(e => e.TextbookName).HasMaxLength(50);

                    entity.Property(e => e.UserCreate).HasMaxLength(255);

                    entity.Property(e => e.UserUpdate).HasMaxLength(255);

                    entity.Property(e => e.Zone).HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwMemberClassDay>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_MemberClassDay");

                    entity.Property(e => e.Area).HasMaxLength(50);

                    entity.Property(e => e.Birthday).HasColumnType("datetime");

                    entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                    entity.Property(e => e.ClassDate).HasColumnType("datetime");

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.EndTime).HasColumnType("datetime");

                    entity.Property(e => e.Group).HasMaxLength(50);

                    entity.Property(e => e.Identifier).HasMaxLength(10);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Specials).HasColumnType("ntext");

                    entity.Property(e => e.StartTime).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Zone).HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwMemberMinister>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_MemberMinister");

                    entity.Property(e => e.MemberName).HasMaxLength(255);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwMemberSummary>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_MemberSummary");

                    entity.Property(e => e.AreaName).HasMaxLength(50);

                    entity.Property(e => e.BaptizeName)
                       .HasMaxLength(16)
                       .IsUnicode(false);

                    entity.Property(e => e.Birthday).HasColumnType("datetime");

                    entity.Property(e => e.ContactAddress).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactCity).HasMaxLength(20);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactZipCode)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.DepName).HasMaxLength(50);

                    entity.Property(e => e.Email).HasMaxLength(255);

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(2)
                       .IsUnicode(false);

                    entity.Property(e => e.GroupName).HasMaxLength(50);

                    entity.Property(e => e.Identifier).HasMaxLength(10);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.OrgName).HasMaxLength(255);

                    entity.Property(e => e.SourceName)
                       .HasMaxLength(12)
                       .IsUnicode(false);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.StatusName)
                       .HasMaxLength(12)
                       .IsUnicode(false);

                    entity.Property(e => e.ZoneName).HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwMemberTag>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_MemberTag");

                    entity.Property(e => e.Name).HasMaxLength(250);

                    entity.Property(e => e.TagModule).HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwOrderInvoice>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_OrderInvoice");

                    entity.Property(e => e.Amount).HasColumnType("money");

                    entity.Property(e => e.CategoryName).HasMaxLength(255);

                    entity.Property(e => e.Comment).HasMaxLength(255);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.CustomNo).HasMaxLength(20);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.DateRecorded).HasColumnType("datetime");

                    entity.Property(e => e.Identifier)
                       .IsRequired()
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.LessionName).HasMaxLength(255);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.OrderIdentifer)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.Payee).HasMaxLength(255);

                    entity.Property(e => e.PaymentMethod)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.PriceName).HasMaxLength(50);

                    entity.Property(e => e.RecordStatusCd)
                       .IsRequired()
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.TotalAmount).HasColumnType("money");

                    entity.Property(e => e.UserRecorded).HasMaxLength(255);
                }
            );

            modelBuilder.Entity<VwOrderRecord>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_OrderRecord");

                    entity.Property(e => e.CategoryName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.DateRecorded).HasColumnType("datetime");

                    entity.Property(e => e.DepositAmount).HasColumnType("money");

                    entity.Property(e => e.DepositPayedDate).HasColumnType("datetime");

                    entity.Property(e => e.DepositPayee).HasMaxLength(255);

                    entity.Property(e => e.LessionName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Name).HasMaxLength(255);

                    entity.Property(e => e.OrderIdentifer)
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                    entity.Property(e => e.Price).HasColumnType("money");

                    entity.Property(e => e.PriceName).HasMaxLength(50);

                    entity.Property(e => e.RecordStatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.RemainingAmount).HasColumnType("money");

                    entity.Property(e => e.RemainingPayedDate).HasColumnType("datetime");

                    entity.Property(e => e.RemainingPayee).HasMaxLength(255);

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.TotalAmount).HasColumnType("money");
                }
            );

            modelBuilder.Entity<VwPreOrder>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_PreOrder");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.CategoryName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.ClassStartDate).HasColumnType("datetime");

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.DateCreate).HasColumnType("datetime");

                    entity.Property(e => e.GroupName).HasMaxLength(50);

                    entity.Property(e => e.Identifer)
                       .IsRequired()
                       .HasMaxLength(10)
                       .IsUnicode(false);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.Introducer).HasMaxLength(255);

                    entity.Property(e => e.IntroducerGroup).HasMaxLength(255);

                    entity.Property(e => e.LessionName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.SignUpDueDate).HasColumnType("datetime");

                    entity.Property(e => e.StatusCd)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwRollCall>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_RollCall");

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.GrantedDate).HasColumnType("datetime");

                    entity.Property(e => e.GroupName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.MemberIdentifier).HasMaxLength(10);

                    entity.Property(e => e.MemberIdnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("MemberIDNumber");

                    entity.Property(e => e.MemberName).HasMaxLength(255);

                    entity.Property(e => e.No).HasMaxLength(10);

                    entity.Property(e => e.RollCallDate).HasColumnType("datetime");

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwWorkSignup>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_WorkSignup");

                    entity.Property(e => e.ActivityName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.AreaName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Birthday).HasColumnType("datetime");

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Gender)
                       .IsRequired()
                       .HasMaxLength(1)
                       .IsUnicode(false)
                       .IsFixedLength();

                    entity.Property(e => e.GroupName)
                       .IsRequired()
                       .HasMaxLength(50);

                    entity.Property(e => e.Idnumber)
                       .HasMaxLength(20)
                       .IsUnicode(false)
                       .HasColumnName("IDNumber");

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.TimeEnd).HasMaxLength(50);

                    entity.Property(e => e.TimeStart).HasMaxLength(50);

                    entity.Property(e => e.WorkName)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );

            modelBuilder.Entity<VwZoneSupervisor>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToView("vw_ZoneSupervisor");

                    entity.Property(e => e.ContactCellPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.ContactPhone)
                       .HasMaxLength(20)
                       .IsUnicode(false);

                    entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(255);

                    entity.Property(e => e.ZoneName)
                       .IsRequired()
                       .HasMaxLength(50);
                }
            );
        }
    }
}
