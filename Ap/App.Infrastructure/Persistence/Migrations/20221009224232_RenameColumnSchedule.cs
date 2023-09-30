using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class RenameColumnSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTimeSchedual");

            migrationBuilder.DropTable(
                name: "CourseTimeSchedualTeacher");

            migrationBuilder.DropTable(
                name: "CourseTimeSchedualUser");

            migrationBuilder.DropTable(
                name: "MinistrySchedualDetail");

            migrationBuilder.DropTable(
                name: "MinistrySchedual");

            migrationBuilder.CreateTable(
                name: "CourseTimeSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseId"),
                    ScheduleNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ScheduleNo"),
                    ClassDay = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassDay"),
                    ClassTimeS = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassTimeS"),
                    ClassTimeE = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassTimeE"),
                    Place = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "Place"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimeScheduleTeacher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTimeScheduleId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseTimeScheduleId"),
                    ScheduleNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ScheduleNo"),
                    TeacherId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "TeacherId"),
                    AttendanceType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AttendanceType"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeScheduleTeacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimeScheduleUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTimeScheduleId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseTimeScheduleId"),
                    ScheduleNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ScheduleNo"),
                    AttendanceType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AttendanceType"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeScheduleUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistrySchedule",
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
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
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
                    table.PrimaryKey("PK_MinistrySchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistryScheduleDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryScheduleId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "MinistryScheduleId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Description"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryScheduleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinistryScheduleDetail_MinistrySchedule_MinistryScheduleId",
                        column: x => x.MinistryScheduleId,
                        principalTable: "MinistrySchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSchedule_DateCreate_UserCreate_HandledId",
                table: "CourseTimeSchedule",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeScheduleTeacher_DateCreate_UserCreate_HandledId",
                table: "CourseTimeScheduleTeacher",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeScheduleUser_DateCreate_UserCreate_HandledId",
                table: "CourseTimeScheduleUser",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistrySchedule_DateCreate_UserCreate_HandledId",
                table: "MinistrySchedule",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistryScheduleDetail_DateCreate_UserCreate_HandledId",
                table: "MinistryScheduleDetail",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistryScheduleDetail_MinistryScheduleId",
                table: "MinistryScheduleDetail",
                column: "MinistryScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTimeSchedule");

            migrationBuilder.DropTable(
                name: "CourseTimeScheduleTeacher");

            migrationBuilder.DropTable(
                name: "CourseTimeScheduleUser");

            migrationBuilder.DropTable(
                name: "MinistryScheduleDetail");

            migrationBuilder.DropTable(
                name: "MinistrySchedule");

            migrationBuilder.CreateTable(
                name: "CourseTimeSchedual",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassDay = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassDay"),
                    ClassTimeE = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassTimeE"),
                    ClassTimeS = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ClassTimeS"),
                    CourseId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    Place = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "Place"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion"),
                    SchedualNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "SchedualNo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員")
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
                    AttendanceType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AttendanceType"),
                    CourseTimeSchedualId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseTimeSchedualId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion"),
                    SchedualNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "SchedualNo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    TeacherId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "TeacherId"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員")
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
                    AttendanceType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "AttendanceType"),
                    CourseTimeSchedualId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseTimeSchedualId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion"),
                    SchedualNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "SchedualNo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeSchedualUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistrySchedual",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    CycleType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "CycleType"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    EndDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "EndDate"),
                    EndDateType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "EndDateType"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    IsActivated = table.Column<int>(type: "int", nullable: false, comment: "IsActivated"),
                    MinistryId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "MinistryId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name"),
                    RepeaTimes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "RepeaTimes"),
                    RepeatTime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "RepeatTime"),
                    RepeatTimeUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "RepeatTimeUnit"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistrySchedual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistrySchedualDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Description"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    MinistrySchedualId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "MinistrySchedualId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員")
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
        }
    }
}
