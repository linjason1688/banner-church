using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddShoppingCartAndOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "UserId"),
                    CourseId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseId"),
                    Count = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "Count"),
                    ShoppingCartStatus = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "ShoppingCartStatus"),
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
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "UserId"),
                    TotalAmount = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "TotalAmount"),
                    PaymentAmount = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "PaymentAmount"),
                    RefundAmount = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "RefundAmount"),
                    OrderPayStatus = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "OrderPayStatus"),
                    PaymentTransactionNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "PaymentTransactionNo"),
                    PaymentTransactionDate = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false, comment: "PaymentTransactionDate"),
                    PaymentTransactionDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "PaymentTransactionDescription"),
                    PaymentType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "PaymentType"),
                    RefundTransactionNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "RefundTransactionNo"),
                    RefundTransactionDate = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false, comment: "RefundTransactionDate"),
                    RefundType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "RefundType"),
                    RefundDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "RefundDescription"),
                    OrderStatus = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "OrderStatus"),
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
                    table.PrimaryKey("PK_ShoppingOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingOrderDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingOrderId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "ShoppingOrderId"),
                    CourseId = table.Column<long>(type: "bigint", maxLength: 32, nullable: false, comment: "CourseId"),
                    Price = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "Price"),
                    Count = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "Count"),
                    Amount = table.Column<int>(type: "int", maxLength: 32, nullable: false, comment: "Amount"),
                    OrderDetailStatus = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, comment: "OrderDetailStatus"),
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
                    table.PrimaryKey("PK_ShoppingOrderDetail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_DateCreate_UserCreate_HandledId",
                table: "ShoppingCart",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrder_DateCreate_UserCreate_HandledId",
                table: "ShoppingOrder",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrderDetail_DateCreate_UserCreate_HandledId",
                table: "ShoppingOrderDetail",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingOrder");

            migrationBuilder.DropTable(
                name: "ShoppingOrderDetail");
        }
    }
}
