using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddQrCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "UserCourse",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "CourseId",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "CourseId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceDate",
                table: "UserCourse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "AttendanceDate",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "AttendanceDate");

            migrationBuilder.CreateTable(
                name: "QrCode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefferenceType = table.Column<int>(type: "int", maxLength: 20, nullable: false, comment: "RefferenceType"),
                    RefferenceId = table.Column<long>(type: "bigint", maxLength: 30, nullable: false, comment: "RefferenceId"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 30, nullable: false, comment: "UserId"),
                    GenerateCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "GenerateCode"),
                    RegisterStatus = table.Column<int>(type: "int", maxLength: 30, nullable: false, comment: "RegisterStatus"),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false, comment: "RegisterTime"),
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
                    table.PrimaryKey("PK_QrCode", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_DateCreate_UserCreate_HandledId",
                table: "QrCode",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QrCode");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "UserCourse",
                type: "nvarchar(max)",
                nullable: true,
                comment: "CourseId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "AttendanceDate",
                table: "UserCourse",
                type: "nvarchar(max)",
                nullable: true,
                comment: "AttendanceDate",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "AttendanceDate");
        }
    }
}
