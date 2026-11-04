using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocean_Desk_dv.Data.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalProductsAndTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalProduct",
                columns: table => new
                {
                    ServerProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductCode = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CachedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalProduct", x => x.ServerProductId);
                });

            migrationBuilder.CreateTable(
                name: "LocalRestaurantTable",
                columns: table => new
                {
                    ServerTableId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TableNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<byte>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CachedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalRestaurantTable", x => x.ServerTableId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalProduct_ProductCode",
                table: "LocalProduct",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalRestaurantTable_TableNumber",
                table: "LocalRestaurantTable",
                column: "TableNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalProduct");

            migrationBuilder.DropTable(
                name: "LocalRestaurantTable");
        }
    }
}
