using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnOfTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
   

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Teacher",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teacher");
        }
    }
}
