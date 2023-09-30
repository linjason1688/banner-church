using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnUserIdOfCourseTimeScheduleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CourseTimeScheduleUser",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "UserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Privilege");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RolePrivilegeMapping");

            migrationBuilder.DropTable(
                name: "RoleUserMapping");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CourseTimeScheduleUser");
        }
    }
}
