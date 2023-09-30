using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class InitOldTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aspnet_Applications",
                columns: table => new
                {
                    ApplicationName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "ApplicationName"),
                    LoweredApplicationName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "LoweredApplicationName"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ApplicationId"),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Description")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_Membership",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ApplicationId"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "UserId"),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "Password"),
                    PasswordFormat = table.Column<int>(type: "int", nullable: false, comment: "PasswordFormat"),
                    PasswordSalt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "PasswordSalt"),
                    MobilePIN = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true, comment: "MobilePin"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Email"),
                    LoweredEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "LoweredEmail"),
                    PasswordQuestion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "PasswordQuestion"),
                    PasswordAnswer = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "PasswordAnswer"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, comment: "IsApproved"),
                    IsLockedOut = table.Column<bool>(type: "bit", nullable: false, comment: "IsLockedOut"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "CreateDate"),
                    LastLoginDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "LastLoginDate"),
                    LastPasswordChangedDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "LastPasswordChangedDate"),
                    LastLockoutDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "LastLockoutDate"),
                    FailedPasswordAttemptCount = table.Column<int>(type: "int", nullable: false, comment: "FailedPasswordAttemptCount"),
                    FailedPasswordAttemptWindowStart = table.Column<DateTime>(type: "datetime", nullable: false, comment: "FailedPasswordAttemptWindowStart"),
                    FailedPasswordAnswerAttemptCount = table.Column<int>(type: "int", nullable: false, comment: "FailedPasswordAnswerAttemptCount"),
                    FailedPasswordAnswerAttemptWindowStart = table.Column<DateTime>(type: "datetime", nullable: false, comment: "FailedPasswordAnswerAttemptWindowStart"),
                    Comment = table.Column<string>(type: "ntext", nullable: true, comment: "Comment")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_Paths",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ApplicationId"),
                    PathId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PathId"),
                    Path = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Path"),
                    LoweredPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "LoweredPath")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_PersonalizationAllUsers",
                columns: table => new
                {
                    PathId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PathId"),
                    PageSettings = table.Column<byte[]>(type: "image", nullable: false, comment: "PageSettings"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "LastUpdatedDate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_P__CD67DC596EC0713C", x => x.PathId);
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_PersonalizationPerUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()", comment: "Id"),
                    PathId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "PathId"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "UserId"),
                    PageSettings = table.Column<byte[]>(type: "image", nullable: false, comment: "PageSettings"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "LastUpdatedDate")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_Profile",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "UserId"),
                    PropertyNames = table.Column<string>(type: "ntext", nullable: false, comment: "PropertyNames"),
                    PropertyValuesString = table.Column<string>(type: "ntext", nullable: false, comment: "PropertyValuesString"),
                    PropertyValuesBinary = table.Column<byte[]>(type: "image", nullable: false, comment: "PropertyValuesBinary"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "LastUpdatedDate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_P__1788CC4C44CA3770", x => x.UserId);
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_Roles",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ApplicationId"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "RoleId"),
                    RoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "RoleName"),
                    LoweredRoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "LoweredRoleName"),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Description")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_SchemaVersions",
                columns: table => new
                {
                    Feature = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "Feature"),
                    CompatibleSchemaVersion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "CompatibleSchemaVersion"),
                    IsCurrentVersion = table.Column<bool>(type: "bit", nullable: false, comment: "IsCurrentVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_S__5A1E6BC12180FB33", x => new { x.Feature, x.CompatibleSchemaVersion });
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_Users",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ApplicationId"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "UserId"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "UserName"),
                    LoweredUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "LoweredUserName"),
                    MobileAlias = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true, comment: "MobileAlias"),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false, comment: "IsAnonymous"),
                    LastActivityDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "LastActivityDate")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_UsersInRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "UserId"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "RoleId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_U__AF2760AD55F4C372", x => new { x.UserId, x.RoleId });
                });
        
            migrationBuilder.CreateTable(
                name: "aspnet_WebEvent_Events",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "char(32)", unicode: false, fixedLength: true, maxLength: 32, nullable: false, comment: "EventId"),
                    EventTimeUtc = table.Column<DateTime>(type: "datetime", nullable: false, comment: "EventTimeUtc"),
                    EventTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "EventTime"),
                    EventType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "EventType"),
                    EventSequence = table.Column<decimal>(type: "decimal(19,0)", nullable: false, comment: "EventSequence"),
                    EventOccurrence = table.Column<decimal>(type: "decimal(19,0)", nullable: false, comment: "EventOccurrence"),
                    EventCode = table.Column<int>(type: "int", nullable: false, comment: "EventCode"),
                    EventDetailCode = table.Column<int>(type: "int", nullable: false, comment: "EventDetailCode"),
                    Message = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "Message"),
                    ApplicationPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "ApplicationPath"),
                    ApplicationVirtualPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "ApplicationVirtualPath"),
                    MachineName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "MachineName"),
                    RequestUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "RequestUrl"),
                    ExceptionType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "ExceptionType"),
                    Details = table.Column<string>(type: "ntext", nullable: true, comment: "Details")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aspnet_W__7944C810078C1F06", x => x.EventId);
                });
        
            migrationBuilder.CreateTable(
                name: "ErrCancel",
                columns: table => new
                {
                    Idn = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "Idn")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrCancel", x => x.Idn);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ACTIVITY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: false, comment: "DateStart"),
                    DateEnd = table.Column<DateTime>(type: "datetime", nullable: false, comment: "DateEnd"),
                    DateSignUpDue = table.Column<DateTime>(type: "datetime", nullable: false, comment: "DateSignUpDue"),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "FilePath"),
                    TargetRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TargetRole"),
                    IsNeedRecruit = table.Column<bool>(type: "bit", nullable: false, comment: "IsNeedRecruit"),
                    IsLunch = table.Column<bool>(type: "bit", nullable: false, comment: "IsLunch"),
                    IsDinner = table.Column<bool>(type: "bit", nullable: false, comment: "IsDinner"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Description"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ACTIVITY", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ACTIVITY_WORK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false, comment: "ActivityId"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date"),
                    TimeStart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TimeStart"),
                    TimeEnd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TimeEnd"),
                    MinisterRequired = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "MinisterRequired"),
                    MaleWanted = table.Column<int>(type: "int", nullable: false, comment: "MaleWanted"),
                    FemaleWanted = table.Column<int>(type: "int", nullable: false, comment: "FemaleWanted"),
                    IsTeam = table.Column<bool>(type: "bit", nullable: false, comment: "IsTeam"),
                    IsNeedRecruit = table.Column<bool>(type: "bit", nullable: false, comment: "IsNeedRecruit"),
                    TargetMinisterId = table.Column<int>(type: "int", nullable: true, comment: "TargetMinisterId"),
                    TargetRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TargetRole"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ACTIVITY_WORK", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ACTIVITY_WORK_SHARE",
                columns: table => new
                {
                    WorkId = table.Column<int>(type: "int", nullable: false, comment: "WorkId"),
                    AreaId = table.Column<int>(type: "int", nullable: false, comment: "AreaId"),
                    AreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "AreaName"),
                    MaleWanted = table.Column<int>(type: "int", nullable: false, comment: "MaleWanted"),
                    FemaleWanted = table.Column<int>(type: "int", nullable: false, comment: "FemaleWanted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ACTIVITY_WORK_SHARE_1", x => new { x.WorkId, x.AreaId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ACTIVITY_WORK_SIGNUP",
                columns: table => new
                {
                    WorkId = table.Column<int>(type: "int", nullable: false, comment: "WorkId"),
                    AreaId = table.Column<int>(type: "int", nullable: false, comment: "AreaId"),
                    GroupId = table.Column<int>(type: "int", nullable: false, comment: "GroupId"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "GroupName"),
                    MemberName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "MemberName"),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Gender"),
                    TeamNo = table.Column<int>(type: "int", nullable: true, comment: "TeamNo"),
                    RealTeamNo = table.Column<int>(type: "int", nullable: true, comment: "RealTeamNo"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ACTIVITY_WORK_SIGNUP", x => new { x.WorkId, x.AreaId, x.GroupId, x.MemberId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_AREA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OId = table.Column<int>(type: "int", nullable: true, comment: "Oid"),
                    OrgId = table.Column<int>(type: "int", nullable: true, comment: "OrgId"),
                    DepId = table.Column<int>(type: "int", nullable: true, comment: "DepId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    Code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Code"),
                    LeaderId = table.Column<int>(type: "int", nullable: true, comment: "LeaderId"),
                    LeaderIDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "LeaderIdnumber"),
                    Leader2Id = table.Column<int>(type: "int", nullable: true, comment: "Leader2Id"),
                    Leader2IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader2Idnumber"),
                    Leader3Id = table.Column<int>(type: "int", nullable: true, comment: "Leader3Id"),
                    Leader3IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader3Idnumber"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_AREA", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_AREALEADER",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false, comment: "AreaId"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_AREALEADER", x => new { x.AreaId, x.MemberId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_AREASUPERVISOR",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false, comment: "AreaId"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_AREASUPERVISOR", x => new { x.AreaId, x.MemberId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CAMPAIGN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()", comment: "Id"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    CategoryCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "CategoryCd"),
                    No = table.Column<int>(type: "int", nullable: false, comment: "No"),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: false, comment: "DateStart"),
                    DateEnd = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateEnd"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CAMPAIGN", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CAMPAIGN_MEMBER",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "CampaignId"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    IsRollCall = table.Column<bool>(type: "bit", nullable: false, comment: "IsRollCall"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CAMPAIGN_MEMBER", x => new { x.MemberId, x.CampaignId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CAMPAIGN_SPDAY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "CampaignId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CAMPAIGN_SPDAY", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CAREER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Career = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Career"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CAREER", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CLASS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "CategoryId"),
                    CategoryCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "CategoryCode"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "CategoryName"),
                    LessionId = table.Column<int>(type: "int", nullable: false, comment: "LessionId"),
                    LessionCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "LessionCode"),
                    LessionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "LessionName"),
                    LessionNo = table.Column<int>(type: "int", nullable: false, comment: "LessionNo"),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, comment: "IsPublic"),
                    Frequency = table.Column<int>(type: "int", nullable: false, comment: "Frequency"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "Capacity"),
                    Credit = table.Column<decimal>(type: "decimal(4,1)", nullable: false, comment: "Credit"),
                    LineCapacity = table.Column<int>(type: "int", nullable: false, comment: "LineCapacity"),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "ContactName"),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactPhone"),
                    ContactFax = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactFax"),
                    Properties = table.Column<string>(type: "ntext", nullable: true, comment: "Properties"),
                    SignUpDueDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "SignUpDueDate"),
                    DiscountDueDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DiscountDueDate"),
                    ClassStartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "ClassStartDate"),
                    MinTimeSelect = table.Column<int>(type: "int", nullable: false, comment: "MinTimeSelect"),
                    Requeryments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Requeryments"),
                    IsRequireAllowLession = table.Column<bool>(type: "bit", nullable: false, comment: "IsRequireAllowLession"),
                    IsAllowNewCommer = table.Column<bool>(type: "bit", nullable: false, comment: "IsAllowNewCommer"),
                    Settings1 = table.Column<string>(type: "ntext", nullable: true, comment: "Settings1"),
                    Settings2 = table.Column<string>(type: "ntext", nullable: true, comment: "Settings2"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CLASS", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CLASS_DAY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassTimeId = table.Column<int>(type: "int", nullable: false, comment: "ClassTimeId"),
                    ClassDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "ClassDate"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "StartTime"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "EndTime"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CLASS_DAY", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CLASS_PRICE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false, comment: "ClassId"),
                    PriceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "PriceName"),
                    Price = table.Column<decimal>(type: "money", nullable: false, comment: "Price"),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, comment: "IsPublic"),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DueDate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CLASS_PRICE", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CLASS_TERM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false, comment: "ClassId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    SortOrder = table.Column<int>(type: "int", nullable: true, comment: "SortOrder")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CLASS_TERM", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_CLASS_TIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false, comment: "ClassId"),
                    LessionTimeId = table.Column<int>(type: "int", nullable: false, comment: "LessionTimeId"),
                    ClassCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "ClassCode"),
                    DayofWeek = table.Column<int>(type: "int", nullable: false, comment: "DayofWeek"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "StartTime"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "EndTime"),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TeacherName"),
                    Place = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Place"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "Capacity"),
                    SignUpDueDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "SignUpDueDate"),
                    DiscountDueDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DiscountDueDate"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_CLASS_TIME", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_DEPARTMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OId = table.Column<int>(type: "int", nullable: true, comment: "Oid"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    TypeId = table.Column<int>(type: "int", nullable: true, comment: "TypeId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    LeaderId = table.Column<int>(type: "int", nullable: true, comment: "LeaderId"),
                    LeaderIDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "LeaderIdnumber"),
                    Leader2Id = table.Column<int>(type: "int", nullable: true, comment: "Leader2Id"),
                    Leader2IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader2Idnumber"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_DEPARTMENT", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_EXPGROUP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: true, comment: "OrgId"),
                    GroupId = table.Column<int>(type: "int", nullable: true, comment: "GroupId"),
                    No = table.Column<int>(type: "int", nullable: false, comment: "No"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    AreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "AreaName"),
                    LeaderId = table.Column<int>(type: "int", nullable: true, comment: "LeaderId"),
                    LeaderIDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "LeaderIdnumber"),
                    Leader2Id = table.Column<int>(type: "int", nullable: true, comment: "Leader2Id"),
                    Leader2IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader2Idnumber"),
                    Leader3Id = table.Column<int>(type: "int", nullable: true, comment: "Leader3Id"),
                    Leader3IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader3Idnumber"),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateStart"),
                    DateEnd = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateEnd"),
                    NewMemCount = table.Column<int>(type: "int", nullable: false, comment: "NewMemCount"),
                    NewMemStayCount = table.Column<int>(type: "int", nullable: false, comment: "NewMemStayCount"),
                    NewMemE1Count = table.Column<int>(type: "int", nullable: false, comment: "NewMemE1count"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "TypeId"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_EXPGROUP", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_GROUP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OId = table.Column<int>(type: "int", nullable: true, comment: "Oid"),
                    OrgId = table.Column<int>(type: "int", nullable: true, comment: "OrgId"),
                    DepId = table.Column<int>(type: "int", nullable: true, comment: "DepId"),
                    AreaId = table.Column<int>(type: "int", nullable: true, comment: "AreaId"),
                    ZoneId = table.Column<int>(type: "int", nullable: false, comment: "ZoneId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    LeaderId = table.Column<int>(type: "int", nullable: true, comment: "LeaderId"),
                    LeaderIDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "LeaderIdnumber"),
                    Leader2Id = table.Column<int>(type: "int", nullable: true, comment: "Leader2Id"),
                    Leader2IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader2Idnumber"),
                    Leader3Id = table.Column<int>(type: "int", nullable: true, comment: "Leader3Id"),
                    Leader3IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader3Idnumber"),
                    MeetingDayOfWeek = table.Column<int>(type: "int", nullable: false, comment: "MeetingDayOfWeek"),
                    MeetingTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "MeetingTime"),
                    MeetingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "MeetingAddress"),
                    IsExp = table.Column<bool>(type: "bit", nullable: false, comment: "IsExp"),
                    IsSearchable = table.Column<bool>(type: "bit", nullable: false, comment: "IsSearchable"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "TypeId"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_GROUP", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_GROUPLEADER",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false, comment: "GroupId"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_GROUPLEADER", x => new { x.GroupId, x.MemberId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_LESSION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "CategoryId"),
                    LessionCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "LessionCode"),
                    LessionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "LessionName"),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, comment: "IsPublic"),
                    BaseNo = table.Column<int>(type: "int", nullable: false, comment: "BaseNo"),
                    BaseNoGranted = table.Column<int>(type: "int", nullable: false, comment: "BaseNoGranted"),
                    Frequency = table.Column<int>(type: "int", nullable: false, comment: "Frequency"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "Capacity"),
                    Credit = table.Column<decimal>(type: "decimal(4,1)", nullable: false, comment: "Credit"),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "ContactName"),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactPhone"),
                    ContactFax = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactFax"),
                    MinTimeSelect = table.Column<int>(type: "int", nullable: false, comment: "MinTimeSelect"),
                    Requeryments = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Requeryments"),
                    IsRequireAllowLession = table.Column<bool>(type: "bit", nullable: false, comment: "IsRequireAllowLession"),
                    IsAllowNewCommer = table.Column<bool>(type: "bit", nullable: false, comment: "IsAllowNewCommer"),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "SortOrder"),
                    Properties = table.Column<string>(type: "ntext", nullable: true, comment: "Properties"),
                    Settings1 = table.Column<string>(type: "ntext", nullable: true, comment: "Settings1"),
                    Settings2 = table.Column<string>(type: "ntext", nullable: true, comment: "Settings2"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_LESSION", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_LESSION_CATEGORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    CategoryCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "CategoryCode"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "CategoryName"),
                    IsBase = table.Column<bool>(type: "bit", nullable: false, comment: "IsBase"),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, comment: "IsFeatured"),
                    IsSeminary = table.Column<bool>(type: "bit", nullable: false, comment: "IsSeminary"),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "SortOrder"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_LESSION_CATEGORY", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_LESSION_PRICE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessionId = table.Column<int>(type: "int", nullable: false, comment: "LessionId"),
                    PriceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "PriceName"),
                    Price = table.Column<decimal>(type: "money", nullable: false, comment: "Price"),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, comment: "IsPublic"),
                    DaysBeforeDue = table.Column<int>(type: "int", nullable: false, comment: "DaysBeforeDue")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_LESSION_PRICE", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_LESSION_TIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessionId = table.Column<int>(type: "int", nullable: false, comment: "LessionId"),
                    ClassCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "ClassCode"),
                    DayofWeek = table.Column<int>(type: "int", nullable: false, comment: "DayofWeek"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "StartTime"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "EndTime"),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TeacherName"),
                    Place = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Place"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_LESSION_TIME", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_LOG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Key"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Content"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "TypeId"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_LOG", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEETING",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false, comment: "GroupId"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "GroupName"),
                    GroupTypeId = table.Column<int>(type: "int", nullable: false, comment: "GroupTypeId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    DepId = table.Column<int>(type: "int", nullable: false, comment: "DepId"),
                    AreaId = table.Column<int>(type: "int", nullable: false, comment: "AreaId"),
                    AreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "AreaName"),
                    ZoneId = table.Column<int>(type: "int", nullable: false, comment: "ZoneId"),
                    ZoneName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "ZoneName"),
                    MeetingTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "MeetingTime"),
                    NoneGroupAttend = table.Column<int>(type: "int", nullable: false, comment: "NoneGroupAttend"),
                    NewCommerAttend = table.Column<int>(type: "int", nullable: false, comment: "NewCommerAttend"),
                    ChildAttend = table.Column<int>(type: "int", nullable: false, comment: "ChildAttend"),
                    WorshipNoneGroupAttend = table.Column<int>(type: "int", nullable: false, comment: "WorshipNoneGroupAttend"),
                    AttendComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "AttendComment"),
                    AreaComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "AreaComment"),
                    ZoneComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "ZoneComment"),
                    GroupComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "GroupComment"),
                    WorshipComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "WorshipComment"),
                    ExpNo = table.Column<int>(type: "int", nullable: false, comment: "ExpNo"),
                    WeekOfExp = table.Column<int>(type: "int", nullable: true, comment: "WeekOfExp"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEETING", x => new { x.GroupId, x.Date });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEETING_MEMBER",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false, comment: "GroupId"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    MemberName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "MemberName"),
                    MemberStatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "MemberStatusCd"),
                    MemberRoles = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "MemberRoles"),
                    IsAttended = table.Column<bool>(type: "bit", nullable: false, comment: "IsAttended"),
                    IsWorshipAttended = table.Column<bool>(type: "bit", nullable: false, comment: "IsWorshipAttended"),
                    IsGroupAttendExpected = table.Column<bool>(type: "bit", nullable: false, comment: "IsGroupAttendExpected"),
                    IsWorshipAttendExpected = table.Column<bool>(type: "bit", nullable: false, comment: "IsWorshipAttendExpected"),
                    IsVisit = table.Column<bool>(type: "bit", nullable: false, comment: "IsVisit"),
                    IntField1 = table.Column<int>(type: "int", nullable: false, comment: "IntField1"),
                    IntField2 = table.Column<int>(type: "int", nullable: false, comment: "IntField2"),
                    IntField3 = table.Column<int>(type: "int", nullable: false, comment: "IntField3"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEETING_MEMBER", x => new { x.GroupId, x.Date, x.MemberId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    EngName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "EngName"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "UserId"),
                    CategoryId = table.Column<int>(type: "int", nullable: true, comment: "CategoryId"),
                    Identifier = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Identifier"),
                    IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Idnumber"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Email"),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactPhone"),
                    ContactCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactCellPhone"),
                    ContactCellPhone2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactCellPhone2"),
                    ContactCity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "ContactCity"),
                    ContactZipCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "ContactZipCode"),
                    ContactAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactAddress"),
                    HomeAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "HomeAddress"),
                    BizPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "BizPhone"),
                    Fax = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Fax"),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Gender"),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Birthday"),
                    Introducer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Introducer"),
                    IntroducerGroup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "IntroducerGroup"),
                    RelativeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "RelativeName"),
                    RelativeRelation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "RelativeRelation"),
                    RelativeCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "RelativeCellPhone"),
                    IsHasCommitment = table.Column<bool>(type: "bit", nullable: false, comment: "IsHasCommitment"),
                    IsBaptize = table.Column<bool>(type: "bit", nullable: true, comment: "IsBaptize"),
                    BaptizeTypeId = table.Column<int>(type: "int", nullable: true, comment: "BaptizeTypeId"),
                    Baptizeday = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Baptizeday"),
                    BaptizeOrgName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "BaptizeOrgName"),
                    BaptizeGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "BaptizeGroup"),
                    Baptizer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Baptizer"),
                    FirstSermon = table.Column<DateTime>(type: "datetime", nullable: true, comment: "FirstSermon"),
                    FirstGroupMeeting = table.Column<DateTime>(type: "datetime", nullable: true, comment: "FirstGroupMeeting"),
                    SettleDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "SettleDate"),
                    LastMovedDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "LastMovedDate"),
                    IsContract = table.Column<bool>(type: "bit", nullable: false, comment: "IsContract"),
                    IsGranted = table.Column<bool>(type: "bit", nullable: false, comment: "IsGranted"),
                    GrantedDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "GrantedDate"),
                    IsFromExp = table.Column<bool>(type: "bit", nullable: false, comment: "IsFromExp"),
                    SourceCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "SourceCd"),
                    GroupLeaderDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "GroupLeaderDate"),
                    IsAllowLession = table.Column<bool>(type: "bit", nullable: false, comment: "IsAllowLession"),
                    Career = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Career"),
                    CareerComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "CareerComment"),
                    Interests = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Interests"),
                    Minister = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Minister"),
                    IsEducation = table.Column<bool>(type: "bit", nullable: false, comment: "IsEducation"),
                    LevelofEducation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "LevelofEducation"),
                    EducationGrade = table.Column<int>(type: "int", nullable: true, comment: "EducationGrade"),
                    EducationSchool = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "EducationSchool"),
                    SchoolTimeCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "SchoolTimeCd"),
                    MarriageId = table.Column<int>(type: "int", nullable: true, comment: "MarriageId"),
                    Spouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Spouse"),
                    Child1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Child1"),
                    Child2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Child2"),
                    Child3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Child3"),
                    Child4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Child4"),
                    Father = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Father"),
                    Mother = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Mother"),
                    ContactTimes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "ContactTimes"),
                    OrgName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "OrgName"),
                    Department = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Department"),
                    Area = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Area"),
                    Zone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Zone"),
                    Group = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Group"),
                    OrgPriest = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "OrgPriest"),
                    OrgTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "OrgTitle"),
                    GroupId = table.Column<int>(type: "int", nullable: true, comment: "GroupId"),
                    ZoneId = table.Column<int>(type: "int", nullable: true, comment: "ZoneId"),
                    AreaId = table.Column<int>(type: "int", nullable: true, comment: "AreaId"),
                    IsE1 = table.Column<bool>(type: "bit", nullable: false, comment: "IsE1"),
                    IsE2 = table.Column<bool>(type: "bit", nullable: false, comment: "IsE2"),
                    IsE3 = table.Column<bool>(type: "bit", nullable: false, comment: "IsE3"),
                    IsE4 = table.Column<bool>(type: "bit", nullable: false, comment: "IsE4"),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false, comment: "IsReserved"),
                    IsTerm = table.Column<bool>(type: "bit", nullable: false, comment: "IsTerm"),
                    IsGroupAttendExpected = table.Column<bool>(type: "bit", nullable: false, comment: "IsGroupAttendExpected"),
                    IsWorshipAttendExpected = table.Column<bool>(type: "bit", nullable: false, comment: "IsWorshipAttendExpected"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "ntext", nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEMBER", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER_CLASS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    OrderId = table.Column<int>(type: "int", nullable: true, comment: "OrderId"),
                    OrderIdentifer = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "OrderIdentifer"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "CategoryId"),
                    CategoryCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "CategoryCode"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "CategoryName"),
                    LessionId = table.Column<int>(type: "int", nullable: false, comment: "LessionId"),
                    LessionCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "LessionCode"),
                    LessionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "LessionName"),
                    ClassId = table.Column<int>(type: "int", nullable: false, comment: "ClassId"),
                    LessionNo = table.Column<int>(type: "int", nullable: false, comment: "LessionNo"),
                    PriceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "PriceName"),
                    Price = table.Column<decimal>(type: "money", nullable: true, comment: "Price"),
                    SelectedTimeId = table.Column<int>(type: "int", nullable: true, comment: "SelectedTimeId"),
                    Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Team"),
                    Line = table.Column<int>(type: "int", nullable: true, comment: "Line"),
                    Position = table.Column<int>(type: "int", nullable: true, comment: "Position"),
                    ClassWorkDone = table.Column<bool>(type: "bit", nullable: false, comment: "ClassWorkDone"),
                    Credit = table.Column<decimal>(type: "decimal(4,1)", nullable: false, comment: "Credit"),
                    CreditEarn = table.Column<decimal>(type: "decimal(4,1)", nullable: false, comment: "CreditEarn"),
                    Grade = table.Column<int>(type: "int", nullable: false, comment: "Grade"),
                    RecordStatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "RecordStatusCd"),
                    DateRecorded = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateRecorded"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER_CLASS_DAY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberClassId = table.Column<int>(type: "int", nullable: false, comment: "MemberClassId"),
                    ClassTimeId = table.Column<int>(type: "int", nullable: false, comment: "ClassTimeId"),
                    ClassDayId = table.Column<int>(type: "int", nullable: false, comment: "ClassDayId"),
                    ClassDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "ClassDate"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "StartTime"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "EndTime"),
                    CheckIn = table.Column<bool>(type: "bit", nullable: false, comment: "CheckIn"),
                    CheckInDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "CheckInDate"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEMBER_CLASS_DAY", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER_CLASS_DAY_TERM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberClassDayId = table.Column<int>(type: "int", nullable: false, comment: "MemberClassDayId"),
                    ClassTermId = table.Column<int>(type: "int", nullable: false, comment: "ClassTermId"),
                    IsDone = table.Column<bool>(type: "bit", nullable: false, comment: "IsDone"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Comment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEMBER_CLASS_DAY_TERM", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER_CLASS_TIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberClassId = table.Column<int>(type: "int", nullable: false, comment: "MemberClassId"),
                    OrderId = table.Column<int>(type: "int", nullable: true, comment: "OrderId"),
                    ClassId = table.Column<int>(type: "int", nullable: false, comment: "ClassId"),
                    ClassTimeId = table.Column<int>(type: "int", nullable: false, comment: "ClassTimeId"),
                    ClassCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "ClassCode"),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "SortOrder")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER_IN_TAG",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "TagId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEMBER_IN_TAG", x => new { x.MemberId, x.TagId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER_LOG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    MemberName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "MemberName"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "TypeId"),
                    NewState = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "NewState"),
                    OldState = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "OldState"),
                    OldGroupId = table.Column<int>(type: "int", nullable: true, comment: "OldGroupId"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserIdUpdate = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "UserIdUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEMBER_LOG", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER_MINISTER",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    MinisterId = table.Column<int>(type: "int", nullable: false, comment: "MinisterId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEMBER_MINISTER", x => new { x.MemberId, x.MinisterId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MEMBER_MINISTER_LOG",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    MinisterId = table.Column<int>(type: "int", nullable: false, comment: "MinisterId"),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: false, comment: "DateStart"),
                    DateEnd = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateEnd"),
                    MinisterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "MinisterName"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MEMBER_MINISTER_LOG", x => new { x.MemberId, x.MinisterId, x.DateStart });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MINISTER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinisterGroupId = table.Column<int>(type: "int", nullable: true, comment: "MinisterGroupId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Description"),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Roles"),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "SortOrder"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MINISTER", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_MINISTER_GROUP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "UserId"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Description"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "TypeId"),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "SortOrder"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_MINISTER_GROUP", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_NEWCOMMER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "CampaignId"),
                    MemberId = table.Column<int>(type: "int", nullable: true, comment: "MemberId"),
                    AssignAreaId = table.Column<int>(type: "int", nullable: true, comment: "AssignAreaId"),
                    AssignAreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "AssignAreaName"),
                    AssignZoneId = table.Column<int>(type: "int", nullable: true, comment: "AssignZoneId"),
                    AssignZoneName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "AssignZoneName"),
                    AssignGroupId = table.Column<int>(type: "int", nullable: true, comment: "AssignGroupId"),
                    AssignGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "AssignGroupName"),
                    AssignUser = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "AssignUser"),
                    DateAssign = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateAssign"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "TypeId"),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "TagId"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    DateEntry = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateEntry"),
                    EngName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "EngName"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Email"),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactPhone"),
                    ContactCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactCellPhone"),
                    ContactCity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "ContactCity"),
                    ContactZipCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "ContactZipCode"),
                    ContactAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactAddress"),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Gender"),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Birthday"),
                    MarriageId = table.Column<int>(type: "int", nullable: true, comment: "MarriageId"),
                    Career = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Career"),
                    CareerComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "CareerComment"),
                    IsEducation = table.Column<bool>(type: "bit", nullable: false, comment: "IsEducation"),
                    LevelofEducation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "LevelofEducation"),
                    EducationGrade = table.Column<int>(type: "int", nullable: true, comment: "EducationGrade"),
                    EducationSchool = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "EducationSchool"),
                    SchoolTimeCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "SchoolTimeCd"),
                    IsHasCommitment = table.Column<bool>(type: "bit", nullable: false, comment: "IsHasCommitment"),
                    BaptizeTypeId = table.Column<int>(type: "int", nullable: true, comment: "BaptizeTypeId"),
                    IsAllowLession = table.Column<bool>(type: "bit", nullable: false, comment: "IsAllowLession"),
                    Nc_Date = table.Column<DateTime>(type: "datetime", nullable: true, comment: "NcDate"),
                    Nc_ActivityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcActivityName"),
                    Nc_ActivityNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "NcActivityNo"),
                    Nc_ActivityGroup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcActivityGroup"),
                    Nc_Introducer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcIntroducer"),
                    Nc_IntroducerIsRelated = table.Column<bool>(type: "bit", nullable: false, comment: "NcIntroducerIsRelated"),
                    Nc_IntroducerGroup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcIntroducerGroup"),
                    Nc_IntroducerPhone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcIntroducerPhone"),
                    Nc_IntroducerRelationship = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcIntroducerRelationship"),
                    Nc_FollowGroup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcFollowGroup"),
                    Nc_IsChristian = table.Column<bool>(type: "bit", nullable: false, comment: "NcIsChristian"),
                    Nc_ChristianComeReason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcChristianComeReason"),
                    Nc_OrginalChurch = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcOrginalChurch"),
                    Nc_OrginalChurchLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcOrginalChurchLocation"),
                    Nc_OrginalChurchPriest = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcOrginalChurchPriest"),
                    Nc_GroupIntentionId = table.Column<int>(type: "int", nullable: false, comment: "NcGroupIntentionId"),
                    Nc_PreferGroup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcPreferGroup"),
                    Nc_PreferContactTimes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcPreferContactTimes"),
                    Nc_PreferGroupTimes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "NcPreferGroupTimes"),
                    Nc_PreferGroupWeekDay = table.Column<int>(type: "int", nullable: true, comment: "NcPreferGroupWeekDay"),
                    Nc_PreferGroupDayTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "NcPreferGroupDayTime"),
                    Nc_PreferGroupTypes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "NcPreferGroupTypes"),
                    Nc_IsReadyForE1 = table.Column<bool>(type: "bit", nullable: false, comment: "NcIsReadyForE1"),
                    Nc_Suggestions = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcSuggestions"),
                    Nc_Interviewer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "NcInterviewer"),
                    Nc_IsFirstTimeCome = table.Column<bool>(type: "bit", nullable: false, comment: "NcIsFirstTimeCome"),
                    Nc_PrayContent = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcPrayContent"),
                    Nc_InterviewContent = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcInterviewContent"),
                    Nc_InterviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcInterviewComment"),
                    Nc_InterviewDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "NcInterviewDate"),
                    Nc_Trace1 = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcTrace1"),
                    Nc_Trace2 = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcTrace2"),
                    Nc_Trace3 = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcTrace3"),
                    Nc_Trace4 = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcTrace4"),
                    Nc_TraceComment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "NcTraceComment"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "ntext", nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_NEWCOMMER", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_NEWS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "Subject"),
                    Content = table.Column<string>(type: "ntext", nullable: true, comment: "Content"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Date"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_NEWS", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ORDER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    Identifer = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, comment: "Identifer"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "TypeId"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    OrgName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "OrgName"),
                    Department = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Department"),
                    Area = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Area"),
                    Zone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Zone"),
                    Group = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Group"),
                    GroupId = table.Column<int>(type: "int", nullable: true, comment: "GroupId"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Idnumber"),
                    ContactCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactCellPhone"),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactPhone"),
                    ContactZipCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "ContactZipCode"),
                    ContactAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactAddress"),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactEmail"),
                    TotalAmount = table.Column<decimal>(type: "money", nullable: false, comment: "TotalAmount"),
                    DepositAmount = table.Column<decimal>(type: "money", nullable: false, comment: "DepositAmount"),
                    DepositPayee = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "DepositPayee"),
                    DepositPayedDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DepositPayedDate"),
                    RemainingAmount = table.Column<decimal>(type: "money", nullable: false, comment: "RemainingAmount"),
                    RemainingPayee = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "RemainingPayee"),
                    RemainingPayedDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "RemainingPayedDate"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "PaymentMethod"),
                    PaymentComment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "PaymentComment"),
                    StudentCd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "StudentCd"),
                    StudentGrade = table.Column<int>(type: "int", nullable: true, comment: "StudentGrade"),
                    EmgPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "EmgPhone"),
                    DateTextbook = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateTextbook"),
                    TextbookName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TextbookName"),
                    Specials = table.Column<string>(type: "ntext", nullable: true, comment: "Specials"),
                    RecordStatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "RecordStatusCd"),
                    DateRecorded = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateRecorded"),
                    IsNeedTraffic = table.Column<bool>(type: "bit", nullable: false, comment: "IsNeedTraffic"),
                    IsCouple = table.Column<bool>(type: "bit", nullable: false, comment: "IsCouple"),
                    Spouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Spouse"),
                    Mates = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Mates"),
                    RelativeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "RelativeName"),
                    RelativeCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "RelativeCellPhone"),
                    TranslateId = table.Column<int>(type: "int", nullable: true, comment: "TranslateId"),
                    ReceptionDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "ReceptionDate"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "InvoiceNo"),
                    UserCancel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCancel"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ORDER", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ORDER_INVOICE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, comment: "Identifier"),
                    CustomNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "CustomNo"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "OrderId"),
                    PriceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "PriceName"),
                    Amount = table.Column<decimal>(type: "money", nullable: false, comment: "Amount"),
                    Payee = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Payee"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "PaymentMethod"),
                    RecordStatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "RecordStatusCd"),
                    DateRecorded = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateRecorded"),
                    UserRecorded = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserRecorded"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "TypeId"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_PREORDER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    Identifer = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, comment: "Identifer"),
                    OrderId = table.Column<int>(type: "int", nullable: true, comment: "OrderId"),
                    ClassId = table.Column<int>(type: "int", nullable: false, comment: "ClassId"),
                    ClassTime1 = table.Column<int>(type: "int", nullable: false, comment: "ClassTime1"),
                    ClassTime2 = table.Column<int>(type: "int", nullable: true, comment: "ClassTime2"),
                    ClassTime3 = table.Column<int>(type: "int", nullable: true, comment: "ClassTime3"),
                    GroupId = table.Column<int>(type: "int", nullable: true, comment: "GroupId"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Idnumber"),
                    ContactCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactCellPhone"),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactPhone"),
                    ContactZipCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "ContactZipCode"),
                    ContactAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactAddress"),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactEmail"),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Gender"),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Birthday"),
                    StudentCd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "StudentCd"),
                    StudentGrade = table.Column<int>(type: "int", nullable: true, comment: "StudentGrade"),
                    EducationSchool = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "EducationSchool"),
                    EmgPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "EmgPhone"),
                    DateTextbook = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateTextbook"),
                    TextbookName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TextbookName"),
                    Specials = table.Column<string>(type: "ntext", nullable: true, comment: "Specials"),
                    IsNeedTraffic = table.Column<bool>(type: "bit", nullable: false, comment: "IsNeedTraffic"),
                    Mates = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Mates"),
                    RelativeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "RelativeName"),
                    RelativeRelation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "RelativeRelation"),
                    RelativeCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "RelativeCellPhone"),
                    TranslateId = table.Column<int>(type: "int", nullable: true, comment: "TranslateId"),
                    ReceptionDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "ReceptionDate"),
                    BaptizeTypeId = table.Column<int>(type: "int", nullable: true, comment: "BaptizeTypeId"),
                    Introducer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Introducer"),
                    IntroducerGroup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "IntroducerGroup"),
                    IsAllowLession = table.Column<bool>(type: "bit", nullable: true, comment: "IsAllowLession"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_PREORDER", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ROLLCALL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "No"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId"),
                    MemberName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "MemberName"),
                    MemberIdentifier = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "MemberIdentifier"),
                    MemberIDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "MemberIdnumber"),
                    MemberIsUser = table.Column<bool>(type: "bit", nullable: false, comment: "MemberIsUser"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    DepId = table.Column<int>(type: "int", nullable: false, comment: "DepId"),
                    AreaId = table.Column<int>(type: "int", nullable: false, comment: "AreaId"),
                    AreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "AreaName"),
                    ZoneId = table.Column<int>(type: "int", nullable: false, comment: "ZoneId"),
                    ZoneName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "ZoneName"),
                    GroupId = table.Column<int>(type: "int", nullable: false, comment: "GroupId"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "GroupName"),
                    IsAttend = table.Column<bool>(type: "bit", nullable: false, comment: "IsAttend"),
                    RollCallDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "RollCallDate"),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "CampaignId"),
                    CampaignSpdayId = table.Column<int>(type: "int", nullable: true, comment: "CampaignSpdayId"),
                    ActivityId = table.Column<int>(type: "int", nullable: true, comment: "ActivityId"),
                    ActivityWorkId = table.Column<int>(type: "int", nullable: true, comment: "ActivityWorkId"),
                    RollCallTypeId = table.Column<int>(type: "int", nullable: false, comment: "RollCallTypeId"),
                    IntField1 = table.Column<int>(type: "int", nullable: false, comment: "IntField1"),
                    IntField2 = table.Column<int>(type: "int", nullable: false, comment: "IntField2"),
                    IntField3 = table.Column<int>(type: "int", nullable: false, comment: "IntField3"),
                    IntField4 = table.Column<int>(type: "int", nullable: false, comment: "IntField4"),
                    IntField5 = table.Column<int>(type: "int", nullable: false, comment: "IntField5"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ROLLCALL", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ROLLCALL_WORK",
                columns: table => new
                {
                    RollCallId = table.Column<int>(type: "int", nullable: false, comment: "RollCallId"),
                    ActivityWorkId = table.Column<int>(type: "int", nullable: false, comment: "ActivityWorkId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ROLLCALL_WORK", x => new { x.RollCallId, x.ActivityWorkId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_STATISTIC_DETAIL",
                columns: table => new
                {
                    StatisticId = table.Column<int>(type: "int", nullable: false, comment: "StatisticId"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date"),
                    Value = table.Column<int>(type: "int", nullable: false, comment: "Value")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_STATISTIC_DETAIL_1", x => new { x.StatisticId, x.Date });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_STATISTICS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    ParentId = table.Column<int>(type: "int", nullable: true, comment: "ParentId"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_STATISTICS", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_TAG",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()", comment: "Id"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "Name"),
                    TagModule = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TagModule"),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "SortOrder")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_TAG", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_TEACHER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId"),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TeacherName"),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactPhone"),
                    ContactCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactCellPhone"),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactEmail"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_TEACHER", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ZONE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OId = table.Column<int>(type: "int", nullable: true, comment: "Oid"),
                    OrgId = table.Column<int>(type: "int", nullable: true, comment: "OrgId"),
                    DepId = table.Column<int>(type: "int", nullable: true, comment: "DepId"),
                    AreaId = table.Column<int>(type: "int", nullable: true, comment: "AreaId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    LeaderId = table.Column<int>(type: "int", nullable: true, comment: "LeaderId"),
                    LeaderIDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "LeaderIdnumber"),
                    Leader2Id = table.Column<int>(type: "int", nullable: true, comment: "Leader2Id"),
                    Leader2IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader2Idnumber"),
                    Leader3Id = table.Column<int>(type: "int", nullable: true, comment: "Leader3Id"),
                    Leader3IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Leader3Idnumber"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ZONE", x => x.Id);
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ZONELEADER",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false, comment: "ZoneId"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ZONELEADER", x => new { x.ZoneId, x.MemberId });
                });
        
            migrationBuilder.CreateTable(
                name: "MOD_ZONESUPERVISOR",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false, comment: "ZoneId"),
                    MemberId = table.Column<int>(type: "int", nullable: false, comment: "MemberId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOD_ZONESUPERVISOR", x => new { x.ZoneId, x.MemberId });
                });
        
            migrationBuilder.CreateTable(
                name: "SEC_ROLE",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false, comment: "RoleId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    RoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "RoleName"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Description"),
                    IsAutoAssignment = table.Column<bool>(type: "bit", nullable: false, comment: "IsAutoAssignment"),
                    IsPublic = table.Column<bool>(type: "bit", nullable: true, comment: "IsPublic"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "SEC_USER",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "UserId"),
                    UserIdentifier = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true, comment: "UserIdentifier"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    IDNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Idnumber"),
                    IsSuperAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "IsSuperAdmin"),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactPhone"),
                    ContactCellPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "ContactCellPhone"),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactEmail"),
                    ContactAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "ContactAddress"),
                    Department = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Department"),
                    JobTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "JobTitle"),
                    Language = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Language"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                });
        
            migrationBuilder.CreateTable(
                name: "SEC_USER_ROLE",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "UserId"),
                    RoleId = table.Column<int>(type: "int", nullable: false, comment: "RoleId"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEC_USER_ROLE", x => new { x.UserId, x.RoleId });
                });
        
            migrationBuilder.CreateTable(
                name: "SYS_ADMIN_PERMISSION",
                columns: table => new
                {
                    AdminPermissoinId = table.Column<int>(type: "int", nullable: false, comment: "AdminPermissoinId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    Definition = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "Definition"),
                    PermissionCd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "PermissionCd"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "UserId"),
                    RoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "RoleName"),
                    IsAllow = table.Column<bool>(type: "bit", nullable: false, comment: "IsAllow"),
                    IsDeny = table.Column<bool>(type: "bit", nullable: false, comment: "IsDeny")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PERMISSION", x => x.AdminPermissoinId);
                });
        
            migrationBuilder.CreateTable(
                name: "SYS_ORG_USER",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "UserId"),
                    OrgId = table.Column<int>(type: "int", nullable: false, comment: "OrgId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_ORG_USER", x => new { x.UserId, x.OrgId });
                });
        
            migrationBuilder.CreateTable(
                name: "SYS_ORGANIZATION",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false, comment: "OrganizationId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OId = table.Column<int>(type: "int", nullable: true, comment: "Oid"),
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Name"),
                    PastorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "PastorName"),
                    PastorId = table.Column<int>(type: "int", nullable: true, comment: "PastorId"),
                    Pastor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Pastor"),
                    Pastorphone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Pastorphone"),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Phone"),
                    Fax = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Fax"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Email"),
                    Site = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Site"),
                    Zip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Zip"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Address"),
                    InvoiceIdentifier = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "InvoiceIdentifier"),
                    InvoiceTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "InvoiceTitle"),
                    IsInvoiceTitle = table.Column<bool>(type: "bit", nullable: true, comment: "IsInvoiceTitle"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_ORGANIZATION", x => x.OrganizationId);
                });
        
            migrationBuilder.CreateTable(
                name: "SYS_PERMISSION",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false, comment: "PermissionId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Definition"),
                    PermissionCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "PermissionCd"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEC_PERMISSION", x => x.PermissionId);
                });
        
            migrationBuilder.CreateTable(
                name: "SYS_PORTAL",
                columns: table => new
                {
                    PortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PortalId"),
                    PortalName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "PortalName"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Description"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Email"),
                    DefaultLanguage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "DefaultLanguage"),
                    Theme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Theme"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_PORTAL", x => x.PortalId);
                });
        
            migrationBuilder.CreateTable(
                name: "SYS_SEED_IDENTITY",
                columns: table => new
                {
                    SeedTable = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "SeedTable"),
                    SeedCur = table.Column<int>(type: "int", nullable: true, comment: "SeedCur"),
                    SeedMax = table.Column<int>(type: "int", nullable: true, comment: "SeedMax"),
                    SeedMin = table.Column<int>(type: "int", nullable: true, comment: "SeedMin"),
                    ResetTypeCd = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "ResetTypeCd"),
                    ResetDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "ResetDate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_SEED_IDENTITY", x => x.SeedTable);
                });
        
            migrationBuilder.CreateTable(
                name: "SYS_SETTINGS",
                columns: table => new
                {
                    SettingName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "SettingName"),
                    Value = table.Column<string>(type: "ntext", nullable: true, comment: "Value"),
                    IsSensitive = table.Column<bool>(type: "bit", nullable: false, comment: "IsSensitive"),
                    StatusCd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Comment"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate"),
                    UserCreate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserCreate"),
                    DateUpdate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateUpdate"),
                    UserUpdate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "UserUpdate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_PORTAL_SETTINGS", x => x.SettingName);
                });
        
            migrationBuilder.CreateTable(
                name: "SYS_SMS_RESULT",
                columns: table => new
                {
                    BatchId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "BatchId"),
                    Credit = table.Column<decimal>(type: "money", nullable: true, comment: "Credit"),
                    SendedCount = table.Column<int>(type: "int", nullable: true, comment: "SendedCount"),
                    Cost = table.Column<decimal>(type: "money", nullable: true, comment: "Cost"),
                    UnSend = table.Column<int>(type: "int", nullable: true, comment: "UnSend"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "DateCreate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_SMS_RESULT", x => x.BatchId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aspnet_Applications");
        
            migrationBuilder.DropTable(
                name: "aspnet_Membership");
        
            migrationBuilder.DropTable(
                name: "aspnet_Paths");
        
            migrationBuilder.DropTable(
                name: "aspnet_PersonalizationAllUsers");
        
            migrationBuilder.DropTable(
                name: "aspnet_PersonalizationPerUser");
        
            migrationBuilder.DropTable(
                name: "aspnet_Profile");
        
            migrationBuilder.DropTable(
                name: "aspnet_Roles");
        
            migrationBuilder.DropTable(
                name: "aspnet_SchemaVersions");
        
            migrationBuilder.DropTable(
                name: "aspnet_Users");
        
            migrationBuilder.DropTable(
                name: "aspnet_UsersInRoles");
        
            migrationBuilder.DropTable(
                name: "aspnet_WebEvent_Events");
        
            migrationBuilder.DropTable(
                name: "ErrCancel");
        
            migrationBuilder.DropTable(
                name: "MOD_ACTIVITY");
        
            migrationBuilder.DropTable(
                name: "MOD_ACTIVITY_WORK");
        
            migrationBuilder.DropTable(
                name: "MOD_ACTIVITY_WORK_SHARE");
        
            migrationBuilder.DropTable(
                name: "MOD_ACTIVITY_WORK_SIGNUP");
        
            migrationBuilder.DropTable(
                name: "MOD_AREA");
        
            migrationBuilder.DropTable(
                name: "MOD_AREALEADER");
        
            migrationBuilder.DropTable(
                name: "MOD_AREASUPERVISOR");
        
            migrationBuilder.DropTable(
                name: "MOD_CAMPAIGN");
        
            migrationBuilder.DropTable(
                name: "MOD_CAMPAIGN_MEMBER");
        
            migrationBuilder.DropTable(
                name: "MOD_CAMPAIGN_SPDAY");
        
            migrationBuilder.DropTable(
                name: "MOD_CAREER");
        
            migrationBuilder.DropTable(
                name: "MOD_CLASS");
        
            migrationBuilder.DropTable(
                name: "MOD_CLASS_DAY");
        
            migrationBuilder.DropTable(
                name: "MOD_CLASS_PRICE");
        
            migrationBuilder.DropTable(
                name: "MOD_CLASS_TERM");
        
            migrationBuilder.DropTable(
                name: "MOD_CLASS_TIME");
        
            migrationBuilder.DropTable(
                name: "MOD_DEPARTMENT");
        
            migrationBuilder.DropTable(
                name: "MOD_EXPGROUP");
        
            migrationBuilder.DropTable(
                name: "MOD_GROUP");
        
            migrationBuilder.DropTable(
                name: "MOD_GROUPLEADER");
        
            migrationBuilder.DropTable(
                name: "MOD_LESSION");
        
            migrationBuilder.DropTable(
                name: "MOD_LESSION_CATEGORY");
        
            migrationBuilder.DropTable(
                name: "MOD_LESSION_PRICE");
        
            migrationBuilder.DropTable(
                name: "MOD_LESSION_TIME");
        
            migrationBuilder.DropTable(
                name: "MOD_LOG");
        
            migrationBuilder.DropTable(
                name: "MOD_MEETING");
        
            migrationBuilder.DropTable(
                name: "MOD_MEETING_MEMBER");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER_CLASS");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER_CLASS_DAY");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER_CLASS_DAY_TERM");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER_CLASS_TIME");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER_IN_TAG");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER_LOG");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER_MINISTER");
        
            migrationBuilder.DropTable(
                name: "MOD_MEMBER_MINISTER_LOG");
        
            migrationBuilder.DropTable(
                name: "MOD_MINISTER");
        
            migrationBuilder.DropTable(
                name: "MOD_MINISTER_GROUP");
        
            migrationBuilder.DropTable(
                name: "MOD_NEWCOMMER");
        
            migrationBuilder.DropTable(
                name: "MOD_NEWS");
        
            migrationBuilder.DropTable(
                name: "MOD_ORDER");
        
            migrationBuilder.DropTable(
                name: "MOD_ORDER_INVOICE");
        
            migrationBuilder.DropTable(
                name: "MOD_PREORDER");
        
            migrationBuilder.DropTable(
                name: "MOD_ROLLCALL");
        
            migrationBuilder.DropTable(
                name: "MOD_ROLLCALL_WORK");
        
            migrationBuilder.DropTable(
                name: "MOD_STATISTIC_DETAIL");
        
            migrationBuilder.DropTable(
                name: "MOD_STATISTICS");
        
            migrationBuilder.DropTable(
                name: "MOD_TAG");
        
            migrationBuilder.DropTable(
                name: "MOD_TEACHER");
        
            migrationBuilder.DropTable(
                name: "MOD_ZONE");
        
            migrationBuilder.DropTable(
                name: "MOD_ZONELEADER");
        
            migrationBuilder.DropTable(
                name: "MOD_ZONESUPERVISOR");
        
            migrationBuilder.DropTable(
                name: "SEC_ROLE");
        
            migrationBuilder.DropTable(
                name: "SEC_USER");
        
            migrationBuilder.DropTable(
                name: "SEC_USER_ROLE");
        
            migrationBuilder.DropTable(
                name: "SYS_ADMIN_PERMISSION");
        
            migrationBuilder.DropTable(
                name: "SYS_ORG_USER");
        
            migrationBuilder.DropTable(
                name: "SYS_ORGANIZATION");
        
            migrationBuilder.DropTable(
                name: "SYS_PERMISSION");
        
            migrationBuilder.DropTable(
                name: "SYS_PORTAL");
        
            migrationBuilder.DropTable(
                name: "SYS_SEED_IDENTITY");
        
            migrationBuilder.DropTable(
                name: "SYS_SETTINGS");
        
            migrationBuilder.DropTable(
                name: "SYS_SMS_RESULT");
        }
        
    }
}
