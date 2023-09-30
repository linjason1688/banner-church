using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddMailSmsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendCounter",
                table: "MessageInformation");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "MessageInformationUser",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Email");

            migrationBuilder.AddColumn<string>(
                name: "SMS",
                table: "MessageInformationUser",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "SMS");

            migrationBuilder.AddColumn<int>(
                name: "SendEmailCounter",
                table: "MessageInformation",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                comment: "SendEmailCounter");

            migrationBuilder.AddColumn<int>(
                name: "SendLineCounter",
                table: "MessageInformation",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                comment: "SendLineCounter");

            migrationBuilder.AddColumn<int>(
                name: "SendSMSCounter",
                table: "MessageInformation",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                comment: "SendSMSCounter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "MessageInformationUser");

            migrationBuilder.DropColumn(
                name: "SMS",
                table: "MessageInformationUser");

            migrationBuilder.DropColumn(
                name: "SendEmailCounter",
                table: "MessageInformation");

            migrationBuilder.DropColumn(
                name: "SendLineCounter",
                table: "MessageInformation");

            migrationBuilder.DropColumn(
                name: "SendSMSCounter",
                table: "MessageInformation");

            migrationBuilder.AddColumn<int>(
                name: "SendCounter",
                table: "MessageInformation",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                comment: "SendCounter");
        }
    }
}
