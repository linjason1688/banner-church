using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ReNameTableUserContractToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserContract");

            migrationBuilder.DropColumn(
                name: "IsContract",
                table: "MOD_MEMBER");

            migrationBuilder.AddColumn<bool>(
                name: "IsContact",
                table: "MOD_MEMBER",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "IsContact");

            migrationBuilder.AlterColumn<long>(
                name: "OrganizationId",
                table: "Course",
                type: "bigint",
                maxLength: 200,
                nullable: true,
                comment: "OrganizationId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 200,
                oldComment: "OrganizationId");

            migrationBuilder.AlterColumn<long>(
                name: "CourseManagementId",
                table: "Course",
                type: "bigint",
                maxLength: 200,
                nullable: true,
                comment: "CourseManagementId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 200,
                oldComment: "CourseManagementId");

            migrationBuilder.CreateTable(
                name: "UserContact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Name"),
                    Relative = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Relative"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Phone"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
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
                    table.PrimaryKey("PK_UserContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContact_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserContact_DateCreate_UserCreate_HandledId",
                table: "UserContact",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserContact_UserId",
                table: "UserContact",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserContact");

            migrationBuilder.DropColumn(
                name: "IsContact",
                table: "MOD_MEMBER");

            migrationBuilder.AddColumn<bool>(
                name: "IsContract",
                table: "MOD_MEMBER",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "IsContract");

            migrationBuilder.AlterColumn<long>(
                name: "OrganizationId",
                table: "Course",
                type: "bigint",
                maxLength: 200,
                nullable: false,
                defaultValue: 0L,
                comment: "OrganizationId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "OrganizationId");

            migrationBuilder.AlterColumn<long>(
                name: "CourseManagementId",
                table: "Course",
                type: "bigint",
                maxLength: 200,
                nullable: false,
                defaultValue: 0L,
                comment: "CourseManagementId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "CourseManagementId");

            migrationBuilder.CreateTable(
                name: "UserContract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "UserId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Name"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Phone"),
                    Relative = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Relative"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員")
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

            migrationBuilder.CreateIndex(
                name: "IX_UserContract_DateCreate_UserCreate_HandledId",
                table: "UserContract",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserContract_UserId",
                table: "UserContract",
                column: "UserId");
        }
    }
}
