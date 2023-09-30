using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class InitLogTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiAuditLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "操作人員帳號"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "操作人員姓名"),
                    SourceIp = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true, comment: "來源 IP"),
                    HttpMethod = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true, comment: "請求 Method"),
                    RequestPath = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true, comment: "請求網址路徑"),
                    RequestQueryString = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "請求網址參數"),
                    RequestHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "請求網址 headers"),
                    ResponseStatusCode = table.Column<int>(type: "int", nullable: false, comment: "回傳 http 狀態碼"),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "請求資料"),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "回應資料"),
                    TimeElapsed = table.Column<long>(type: "bigint", nullable: false, comment: "執行時間(ms)"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    Creator = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true, comment: "建立人員"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    Modifier = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiAuditLog", x => x.Id);
                },
                comment: "API 系統操作紀錄");

            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true, comment: "MachineName"),
                    Message = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "Message"),
                    Source = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "Source"),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "StackTrace"),
                    ExtraData = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "ExtraData"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    Creator = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true, comment: "建立人員"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    Modifier = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.Id);
                },
                comment: "AP 錯誤紀錄");

            migrationBuilder.CreateIndex(
                name: "IX_ApiAuditLog_CreatedAt_Creator_HandledId",
                table: "ApiAuditLog",
                columns: new[] { "CreatedAt", "Creator", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApiAuditLog_HandledId_Account_Name_HttpMethod_SourceIp_RequestPath_ResponseStatusCode",
                table: "ApiAuditLog",
                columns: new[] { "HandledId", "Account", "Name", "HttpMethod", "SourceIp", "RequestPath", "ResponseStatusCode" });

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLog_CreatedAt_Creator_HandledId",
                table: "ExceptionLog",
                columns: new[] { "CreatedAt", "Creator", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLog_MachineName",
                table: "ExceptionLog",
                column: "MachineName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiAuditLog");

            migrationBuilder.DropTable(
                name: "ExceptionLog");
        }
    }
}
