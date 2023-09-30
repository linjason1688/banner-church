using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddUploadFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UploadFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "供 Owner 綁定 key"),
                    OwnerEntity = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true, comment: "擁有者關聯 table"),
                    Filename = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "檔名"),
                    FileExtension = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true, comment: "副檔名"),
                    RelativeFilepath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "檔案存放相對路徑"),
                    FileSize = table.Column<long>(type: "bigint", nullable: false, comment: "檔案大小 (bit)"),
                    Bound = table.Column<bool>(type: "bit", nullable: false, comment: "是否已綁定"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadFile", x => x.Id);
                },
                comment: "檔案上傳");

            migrationBuilder.CreateIndex(
                name: "IX_UploadFile_DateCreate_UserCreate_HandledId",
                table: "UploadFile",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_UploadFile_FileKey",
                table: "UploadFile",
                column: "FileKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploadFile");
        }
    }
}
