using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddTableFilterUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseManagementFilterUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementFilterId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "CourseManagementFilterId"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "UserId"),
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
                    table.PrimaryKey("PK_CourseManagementFilterUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagementFilterUser_DateCreate_UserCreate_HandledId",
                table: "CourseManagementFilterUser",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseManagementFilterUser");
        }
    }
}
