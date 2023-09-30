using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddCourseFilterSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseManagementFilter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseManagementId"),
                    OrganizationId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "OrganizationId"),
                    CourseSex = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "CourseSex"),
                    AgeUp = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "AgeUp"),
                    AgeDown = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "AgeDown"),
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
                    table.PrimaryKey("PK_CourseManagementFilter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseManagementFilterCourse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementFilterId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseManagementFilterId"),
                    CourseManagementId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseManagementId"),
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
                    table.PrimaryKey("PK_CourseManagementFilterCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseManagementFilterPastoral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementFilterId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "CourseManagementFilterId"),
                    PastoralId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "PastoralId"),
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
                    table.PrimaryKey("PK_CourseManagementFilterPastoral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseManagementFilterResp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseManagementFilterId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "CourseManagementFilterId"),
                    MinistryRespId = table.Column<long>(type: "bigint", maxLength: 200, nullable: false, comment: "MinistryRespId"),
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
                    table.PrimaryKey("PK_CourseManagementFilterResp", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagementFilter_DateCreate_UserCreate_HandledId",
                table: "CourseManagementFilter",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagementFilterCourse_DateCreate_UserCreate_HandledId",
                table: "CourseManagementFilterCourse",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagementFilterPastoral_DateCreate_UserCreate_HandledId",
                table: "CourseManagementFilterPastoral",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagementFilterResp_DateCreate_UserCreate_HandledId",
                table: "CourseManagementFilterResp",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseManagementFilter");

            migrationBuilder.DropTable(
                name: "CourseManagementFilterCourse");

            migrationBuilder.DropTable(
                name: "CourseManagementFilterPastoral");

            migrationBuilder.DropTable(
                name: "CourseManagementFilterResp");
        }
    }
}
