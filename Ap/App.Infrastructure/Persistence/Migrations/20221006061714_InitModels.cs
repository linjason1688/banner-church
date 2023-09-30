using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class InitModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiAuditLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "操作人員帳號"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "操作人員姓名"),
                    SourceIp = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true, comment: "來源 IP"),
                    HttpMethod = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true, comment: "請求 Method"),
                    RequestPath = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true, comment: "請求網址路徑"),
                    RequestQueryString = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "請求網址參數"),
                    RequestHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "請求網址 headers"),
                    ResponseStatusCode = table.Column<int>(type: "int", nullable: false, comment: "回傳 http 狀態碼"),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "請求資料"),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "回應資料"),
                    TimeElapsed = table.Column<long>(type: "bigint", nullable: false, comment: "執行時間(ms)"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiAuditLog", x => x.Id);
                },
                comment: "API 系統操作紀錄");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "CourseManagementId"),
                    PastoralId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "PastoralId"),
                    QuestionnaireId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "QuestionnaireId"),
                    Year = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "Year"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Name"),
                    ClassNum = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassNum"),
                    Season = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "Season"),
                    OpenDate = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false, comment: "OpenDate"),
                    SignUpDateS = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false, comment: "SignUpDateS"),
                    SignUpDateE = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false, comment: "SignUpDateE"),
                    DiscountSignUpDate = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false, comment: "DiscountSignUpDate"),
                    CourseSignUpType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "CourseSignUpType"),
                    WishCount = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "WishCount"),
                    NeedRecommend = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "NeedRecommend"),
                    AcceptNewMember = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AcceptNewMember"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Description"),
                    ClassCount = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "ClassCount"),
                    Quota = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "Quota"),
                    GraduationType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "GraduationType"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseAppendix",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseId"),
                    AppendixType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AppendixType"),
                    Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Path"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAppendix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseManagement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementTypeId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseManagementTypeId"),
                    OrganizationId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "OrganizationId"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Title"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Description"),
                    CourseManagementStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "CourseManagementStatus"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseManagement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseManagementAppendix",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseManagementId"),
                    AppendixType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AppendixType"),
                    Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Path"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseManagementAppendix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseManagementType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementTypeNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "CourseManagementTypeNo"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Name"),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Remark"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseManagementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseId"),
                    PriceName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "PriceName"),
                    Price = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "Price"),
                    IsPublic = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "IsPublic"),
                    IsDueDate = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "IsDueDate"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimeSchedual",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseId"),
                    SchedualNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "SchedualNo"),
                    ClassDay = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassDay"),
                    ClassTimeS = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassTimeS"),
                    ClassTimeE = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassTimeE"),
                    Place = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "Place"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeSchedual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimeSchedualTeacher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTimeSchedualId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseTimeSchedualId"),
                    SchedualNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "SchedualNo"),
                    TeacherId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "TeacherId"),
                    AttendanceType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AttendanceType"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeSchedualTeacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimeSchedualUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTimeSchedualId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseTimeSchedualId"),
                    SchedualNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "SchedualNo"),
                    AttendanceType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AttendanceType"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeSchedualUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true, comment: "MachineName"),
                    Message = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "Message"),
                    Source = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "Source"),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StackTrace"),
                    ExtraData = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "ExtraData"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.Id);
                },
                comment: "AP 錯誤紀錄");

            migrationBuilder.CreateTable(
                name: "Ministry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryDefId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "MinistryDefId"),
                    MinistryNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "MinistryNo"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name"),
                    ChildMinistry = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "ChildMinistry"),
                    MinistryStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "MinistryStatus"),
                    Nature = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Nature"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistryDef",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryDefNo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "MinistryDefNo"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Name"),
                    ChildMinistry = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "ChildMinistry"),
                    MinistryDefStatus = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "MinistryDefStatus"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryDef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistryResp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "MinistryId"),
                    Seq = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "Seq"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name"),
                    ManageType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ManageType"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryResp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistryRespUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryRespId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "MinistryRespId"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "UserId"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryRespUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistrySchedual",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "MinistryId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name"),
                    CycleType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "CycleType"),
                    RepeatTime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "RepeatTime"),
                    RepeatTimeUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "RepeatTimeUnit"),
                    EndDateType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "EndDateType"),
                    EndDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "EndDate"),
                    RepeaTimes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "RepeaTimes"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    IsActivated = table.Column<int>(type: "int", nullable: false, comment: "IsActivated"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistrySchedual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oid = table.Column<long>(type: "bigint", maxLength: 255, nullable: false, comment: "Oid"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name"),
                    PastorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "PastorName"),
                    PastorId = table.Column<long>(type: "bigint", maxLength: 255, nullable: false, comment: "PastorId"),
                    Pastor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Pastor"),
                    Pastorphone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Pastorphone"),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Phone"),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Fax"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Email"),
                    Site = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Site"),
                    Zip = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Zip"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Address"),
                    InvoiceIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "InvoiceIdentifier"),
                    InvoiceTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "InvoiceTitle"),
                    IsInvoiceTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "IsInvoiceTitle"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUser",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id"),
                    OrganizationId = table.Column<long>(type: "bigint", maxLength: 255, nullable: false, comment: "OrganizationId"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Pastoral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpperPastoralId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "UpperPastoralId"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Name"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Title"),
                    GroupNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true, comment: "GroupNo"),
                    LeaderId = table.Column<long>(type: "bigint", maxLength: 20, nullable: true, comment: "LeaderId"),
                    LeaderIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "LeaderIdNumber"),
                    Leader2Id = table.Column<long>(type: "bigint", maxLength: 20, nullable: true, comment: "Leader2Id"),
                    Leader2IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Leader2IdNumber"),
                    Leader3Id = table.Column<long>(type: "bigint", maxLength: 20, nullable: true, comment: "Leader3Id"),
                    Leader3IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Leader3IdNumber"),
                    SupervisorId = table.Column<long>(type: "bigint", maxLength: 20, nullable: true, comment: "SupervisorId"),
                    Oid = table.Column<long>(type: "bigint", nullable: true, comment: "Oid"),
                    OrgId = table.Column<long>(type: "bigint", nullable: false, comment: "OrgId"),
                    TypeId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "TypeId"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastoral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PastoralMeeting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastoralId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "PastoralId"),
                    MeetingDayOfWeek = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetingDayOfWeek"),
                    MeetingTime = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetingTime"),
                    MeetingAddress = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetingAddress"),
                    MeetingDay = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetingDay"),
                    IsExp = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "IsExp"),
                    IsSearchable = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "IsSearchable"),
                    MeetType = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetType"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastoralMeeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PastoralMeetingUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastoralMeetingId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "PastoralMeetingId"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "UserId"),
                    MeetAttendanceType = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetAttendanceType"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastoralMeetingUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privilege",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()", comment: "Id"),
                    FunctionId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true, comment: "功能 ID"),
                    ParentFunctionId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true, comment: "父層功能 Id"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "功能名稱"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    LinkType = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false, comment: "功能類型"),
                    QueryParams = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "QueryParams"),
                    Icon = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "圖示"),
                    Comment = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true, comment: "Comment"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.Id);
                },
                comment: "權限功能");

            migrationBuilder.CreateTable(
                name: "Questionnaire",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireJoinLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "QuestionnaireJoinLocation"),
                    QuestionnaireType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "QuestionnaireType"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Name"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "QuestionnaireId"),
                    UpperQuestionnaireDetailId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "UpperQuestionnaireDetailId"),
                    QuestionnaireDetailType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "QuestionnaireDetailType"),
                    ComponentType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ComponentType"),
                    Sequence = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "Sequence"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Name"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()", comment: "Id"),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true, comment: "角色"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "RolePrivilegeMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()", comment: "Id"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "角色 Id"),
                    PrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "功能 Id"),
                    Enable = table.Column<bool>(type: "bit", nullable: false, comment: "啟用"),
                    ViewGranted = table.Column<bool>(type: "bit", nullable: false, comment: "檢視"),
                    ModifyGranted = table.Column<bool>(type: "bit", nullable: false, comment: "新增/編輯"),
                    DeleteGranted = table.Column<bool>(type: "bit", nullable: false, comment: "刪除"),
                    UploadGranted = table.Column<bool>(type: "bit", nullable: false, comment: "上傳"),
                    DownloadGranted = table.Column<bool>(type: "bit", nullable: false, comment: "下載"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivilegeMapping", x => x.Id);
                },
                comment: "角色-功能權限對應");

            migrationBuilder.CreateTable(
                name: "RoleUserMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()", comment: "Id"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "使用者 Id"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "角色 Id"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUserMapping", x => x.Id);
                },
                comment: "帳號-角色 對應");

            migrationBuilder.CreateTable(
                name: "SystemConfig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Type"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Value"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Name"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "OrganizationId"),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "TeacherName"),
                    ContactPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "ContactPhone"),
                    ContactCellPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "ContactCellPhone"),
                    ContactEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "ContactEmail"),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Comment"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "UserId"),
                    PastoralId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "PastoralId"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Name"),
                    UserNo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "UserNo"),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "Password"),
                    PasswordSalt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "PasswordSalt"),
                    PhoneType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "PhoneType"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "FirstName"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "LastName"),
                    GenderType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "GenderType"),
                    LiveCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "LiveCountry"),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Birthday"),
                    IdNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "IdNumber"),
                    CellPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "CellPhone"),
                    LiveCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "LiveCity"),
                    LiveZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "LiveZipCode"),
                    LiveZipArea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "LiveZipArea"),
                    LiveAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "LiveAddress"),
                    LiveAddress2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "LiveAddress2"),
                    BaptizedType = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "BaptizedType"),
                    BaptizedTime = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "BaptizedTime"),
                    BaptizedPerson = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "BaptizedPerson"),
                    ChurchType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "ChurchType"),
                    ChurchName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "ChurchName"),
                    AnotherChurchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "AnotherChurchName"),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "Phone"),
                    CellPhone1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "CellPhone1"),
                    CellPhone2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "CellPhone2"),
                    Email1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Email1"),
                    Email2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Email2"),
                    InstagramId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "InstagramId"),
                    LineId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "LineId"),
                    WeChatId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "WeChatId"),
                    OtherSocialId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "OtherSocialId"),
                    IsChurchGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "IsChurchGroup"),
                    ChurchGroupNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "ChurchGroupNo"),
                    IsJoinChurchGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "IsJoinChurchGroup"),
                    JoinInPersonDate1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonDate1"),
                    JoinInPersonTime1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonTime1"),
                    JoinInPersonLocation1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonLocation1"),
                    JoinInPersonDate2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonDate2"),
                    JoinInPersonTime2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonTime2"),
                    JoinInPersonLocation2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonLocation2"),
                    JoinInPersonDate3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonDate3"),
                    JoinInPersonTime3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonTime3"),
                    JoinInPersonLocation3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinInPersonLocation3"),
                    JoinOnlineDate1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinOnlineDate1"),
                    JoinOnlineTime1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinOnlineTime1"),
                    JoinOnlineDate2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinOnlineDate2"),
                    JoinOnlineTime2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinOnlineTime2"),
                    JoinOnlineDate3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinOnlineDate3"),
                    JoinOnlineTime3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "JoinOnlineTime3"),
                    MemberType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "MemberType"),
                    EduType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "EduType"),
                    ProfessionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "ProfessionType"),
                    IsMarried = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "IsMarried"),
                    LastLogin = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "LastLogin"),
                    ParentUserId = table.Column<long>(type: "bigint", nullable: false, comment: "ParentUserId"),
                    IsOldMember = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "IsOldMember"),
                    CountryCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "CountryCode"),
                    CellAreaCode1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "CellAreaCode1"),
                    CellAreaCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "CellAreaCode2"),
                    Account = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Account"),
                    Roles = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Roles"),
                    IsAdmin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "IsAdmin"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistrySchedualDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistrySchedualId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "MinistrySchedualId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Description"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistrySchedualDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinistrySchedualDetail_MinistrySchedual_MinistrySchedualId",
                        column: x => x.MinistrySchedualId,
                        principalTable: "MinistrySchedual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBankAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "BankName"),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "BankCode"),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "BranchCode"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Account"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBankAccount_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Name"),
                    Relative = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Relative"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Phone"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContract_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId"),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "CourseId"),
                    AttendanceType = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "AttendanceType"),
                    AttendanceDate = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "AttendanceDate"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourse_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExpertise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Name"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExpertise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExpertise_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFamily",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId"),
                    RelativeType = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "RelativeType"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Name"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFamily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFamily_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPastoralCare",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "UserId"),
                    CareType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "CareType"),
                    CareIdentityType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "CareIdentityType"),
                    NewArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "NewArea"),
                    OldArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "OldArea"),
                    CareDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "CareDate"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPastoralCare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPastoralCare_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestionnaire",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireId = table.Column<long>(type: "bigint", nullable: false, comment: "QuestionnaireId"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId"),
                    QuestionnaireWriteType = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "QuestionnaireWriteType"),
                    QuestionnaireGoArea = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "QuestionnaireGoArea"),
                    Satisfaction = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Satisfaction"),
                    Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Evaluation"),
                    WriteQuestionnaireDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "WriteQuestionnaireDate"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuestionnaire_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSociety",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "UserId"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Name"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSociety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSociety_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiAuditLog_DateCreate_UserCreate_HandledId",
                table: "ApiAuditLog",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApiAuditLog_HandledId_Account_Name_HttpMethod_SourceIp_RequestPath_ResponseStatusCode",
                table: "ApiAuditLog",
                columns: new[] { "HandledId", "Account", "Name", "HttpMethod", "SourceIp", "RequestPath", "ResponseStatusCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DateCreate_UserCreate_HandledId",
                table: "Course",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAppendix_DateCreate_UserCreate_HandledId",
                table: "CourseAppendix",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagement_DateCreate_UserCreate_HandledId",
                table: "CourseManagement",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagementAppendix_DateCreate_UserCreate_HandledId",
                table: "CourseManagementAppendix",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagementType_DateCreate_UserCreate_HandledId",
                table: "CourseManagementType",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrice_DateCreate_UserCreate_HandledId",
                table: "CoursePrice",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSchedual_DateCreate_UserCreate_HandledId",
                table: "CourseTimeSchedual",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSchedualTeacher_DateCreate_UserCreate_HandledId",
                table: "CourseTimeSchedualTeacher",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSchedualUser_DateCreate_UserCreate_HandledId",
                table: "CourseTimeSchedualUser",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLog_DateCreate_UserCreate_HandledId",
                table: "ExceptionLog",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLog_MachineName",
                table: "ExceptionLog",
                column: "MachineName");

            migrationBuilder.CreateIndex(
                name: "IX_Ministry_DateCreate_UserCreate_HandledId",
                table: "Ministry",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistryDef_DateCreate_UserCreate_HandledId",
                table: "MinistryDef",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistryResp_DateCreate_UserCreate_HandledId",
                table: "MinistryResp",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistryRespUser_DateCreate_UserCreate_HandledId",
                table: "MinistryRespUser",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistrySchedual_DateCreate_UserCreate_HandledId",
                table: "MinistrySchedual",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistrySchedualDetail_DateCreate_UserCreate_HandledId",
                table: "MinistrySchedualDetail",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistrySchedualDetail_MinistrySchedualId",
                table: "MinistrySchedualDetail",
                column: "MinistrySchedualId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_DateCreate_UserCreate_HandledId",
                table: "Organization",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUser_DateCreate_UserCreate_HandledId",
                table: "OrganizationUser",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_Pastoral_DateCreate_UserCreate_HandledId",
                table: "Pastoral",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_PastoralMeeting_DateCreate_UserCreate_HandledId",
                table: "PastoralMeeting",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_PastoralMeetingUser_DateCreate_UserCreate_HandledId",
                table: "PastoralMeetingUser",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_DateCreate_UserCreate_HandledId",
                table: "Privilege",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_FunctionId",
                table: "Privilege",
                column: "FunctionId",
                unique: true,
                filter: "[FunctionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_ParentFunctionId_LinkType",
                table: "Privilege",
                columns: new[] { "ParentFunctionId", "LinkType" });

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaire_DateCreate_UserCreate_HandledId",
                table: "Questionnaire",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireDetail_DateCreate_UserCreate_HandledId",
                table: "QuestionnaireDetail",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_Role_DateCreate_UserCreate_HandledId",
                table: "Role",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivilegeMapping_DateCreate_UserCreate_HandledId",
                table: "RolePrivilegeMapping",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivilegeMapping_RoleId_PrivilegeId",
                table: "RolePrivilegeMapping",
                columns: new[] { "RoleId", "PrivilegeId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserMapping_DateCreate_UserCreate_HandledId",
                table: "RoleUserMapping",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserMapping_UserId_RoleId",
                table: "RoleUserMapping",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_SystemConfig_DateCreate_UserCreate_HandledId",
                table: "SystemConfig",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DateCreate_UserCreate_HandledId",
                table: "Teacher",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_User_DateCreate_UserCreate_HandledId",
                table: "User",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBankAccount_DateCreate_UserCreate_HandledId",
                table: "UserBankAccount",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBankAccount_UserId",
                table: "UserBankAccount",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContract_DateCreate_UserCreate_HandledId",
                table: "UserContract",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserContract_UserId",
                table: "UserContract",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_DateCreate_UserCreate_HandledId",
                table: "UserCourse",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_UserId",
                table: "UserCourse",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExpertise_DateCreate_UserCreate_HandledId",
                table: "UserExpertise",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserExpertise_UserId",
                table: "UserExpertise",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFamily_DateCreate_UserCreate_HandledId",
                table: "UserFamily",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFamily_UserId",
                table: "UserFamily",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPastoralCare_DateCreate_UserCreate_HandledId",
                table: "UserPastoralCare",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPastoralCare_UserId",
                table: "UserPastoralCare",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionnaire_DateCreate_UserCreate_HandledId",
                table: "UserQuestionnaire",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionnaire_UserId",
                table: "UserQuestionnaire",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSociety_DateCreate_UserCreate_HandledId",
                table: "UserSociety",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserSociety_UserId",
                table: "UserSociety",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiAuditLog");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "CourseAppendix");

            migrationBuilder.DropTable(
                name: "CourseManagement");

            migrationBuilder.DropTable(
                name: "CourseManagementAppendix");

            migrationBuilder.DropTable(
                name: "CourseManagementType");

            migrationBuilder.DropTable(
                name: "CoursePrice");

            migrationBuilder.DropTable(
                name: "CourseTimeSchedual");

            migrationBuilder.DropTable(
                name: "CourseTimeSchedualTeacher");

            migrationBuilder.DropTable(
                name: "CourseTimeSchedualUser");

            migrationBuilder.DropTable(
                name: "ExceptionLog");

            migrationBuilder.DropTable(
                name: "Ministry");

            migrationBuilder.DropTable(
                name: "MinistryDef");

            migrationBuilder.DropTable(
                name: "MinistryResp");

            migrationBuilder.DropTable(
                name: "MinistryRespUser");

            migrationBuilder.DropTable(
                name: "MinistrySchedualDetail");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "OrganizationUser");

            migrationBuilder.DropTable(
                name: "Pastoral");

            migrationBuilder.DropTable(
                name: "PastoralMeeting");

            migrationBuilder.DropTable(
                name: "PastoralMeetingUser");

            migrationBuilder.DropTable(
                name: "Privilege");

            migrationBuilder.DropTable(
                name: "Questionnaire");

            migrationBuilder.DropTable(
                name: "QuestionnaireDetail");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RolePrivilegeMapping");

            migrationBuilder.DropTable(
                name: "RoleUserMapping");

            migrationBuilder.DropTable(
                name: "SystemConfig");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "UserBankAccount");

            migrationBuilder.DropTable(
                name: "UserContract");

            migrationBuilder.DropTable(
                name: "UserCourse");

            migrationBuilder.DropTable(
                name: "UserExpertise");

            migrationBuilder.DropTable(
                name: "UserFamily");

            migrationBuilder.DropTable(
                name: "UserPastoralCare");

            migrationBuilder.DropTable(
                name: "UserQuestionnaire");

            migrationBuilder.DropTable(
                name: "UserSociety");

            migrationBuilder.DropTable(
                name: "MinistrySchedual");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
