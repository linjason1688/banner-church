using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddMinistryMeetingAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "User");

            migrationBuilder.CreateTable(
                name: "MinistryMeeting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "MinistryId"),
                    MeetingDayOfWeek = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetingDayOfWeek"),
                    MeetingTime = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetingTime"),
                    MeetingAddress = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetingAddress"),
                    MeetingDay = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetingDay"),
                    IsExp = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "IsExp"),
                    IsSearchable = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "IsSearchable"),
                    MeetType = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetType"),
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
                    table.PrimaryKey("PK_MinistryMeeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistryMeetingUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinistryMeetingId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "MinistryMeetingId"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 36, nullable: false, comment: "UserId"),
                    MeetAttendanceType = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "MeetAttendanceType"),
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
                    table.PrimaryKey("PK_MinistryMeetingUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MinistryMeeting_DateCreate_UserCreate_HandledId",
                table: "MinistryMeeting",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_MinistryMeetingUser_DateCreate_UserCreate_HandledId",
                table: "MinistryMeetingUser",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MinistryMeeting");

            migrationBuilder.DropTable(
                name: "MinistryMeetingUser");

            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "Account");

            migrationBuilder.AddColumn<string>(
                name: "IsAdmin",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "IsAdmin");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "Roles");
        }
    }
}
