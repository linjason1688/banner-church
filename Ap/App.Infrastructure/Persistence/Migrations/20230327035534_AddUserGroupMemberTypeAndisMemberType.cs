using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddUserGroupMemberTypeAndisMemberType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupMemberType",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValue: "0",
                comment: "GroupMemberType");

            migrationBuilder.AddColumn<string>(
                name: "IsMember",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "IsMember");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupMemberType",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsMember",
                table: "User");
        }
    }
}
