using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class addMessageInformationApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "OrganizationId"),
                    MeetingPointId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "MeetingPointId"),
                    PastoralId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "PastoralId"),
                    MinistryRespId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "MinistryRespId"),
                    MinistryId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "MinistryId"),
                    CourseId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "CourseId"),
                    GenderType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "GenderType"),
                    BirthdayYearRange = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "BirthdayYearRange"),
                    ProfessionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "ProfessionType"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Title"),
                    Descriptions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Descriptions"),
                    MessageSendType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "MessageSendType"),
                    SendCounter = table.Column<int>(type: "int", maxLength: 10, nullable: false, comment: "SendCounter"),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Remark"),
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
                    table.PrimaryKey("PK_MessageInformation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageInformation_DateCreate_UserCreate_HandledId",
                table: "MessageInformation",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageInformation");
        }
    }
}
