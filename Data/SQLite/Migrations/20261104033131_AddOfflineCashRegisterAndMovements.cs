using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocean_Desk_dv.Data.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddOfflineCashRegisterAndMovements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalCashRegister",
                columns: table => new
                {
                    LocalCashRegisterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServerCashRegisterId = table.Column<int>(type: "INTEGER", nullable: true),
                    OpeningUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpeningDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OpeningAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClosingDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpectedCash = table.Column<decimal>(type: "TEXT", nullable: true),
                    ActualCash = table.Column<decimal>(type: "TEXT", nullable: true),
                    Difference = table.Column<decimal>(type: "TEXT", nullable: true),
                    ClosingUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Origin = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false),
                    SyncStatus = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false),
                    CachedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SynchronizedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastSyncError = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalCashRegister", x => x.LocalCashRegisterId);
                });

            migrationBuilder.CreateTable(
                name: "LocalCashMovement",
                columns: table => new
                {
                    LocalCashMovementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocalCashRegisterId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServerCashMovementId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovementType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Concept = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    MovementDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reference = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    SyncStatus = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false),
                    SynchronizedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastSyncError = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalCashMovement", x => x.LocalCashMovementId);
                    table.ForeignKey(
                        name: "FK_LocalCashMovement_LocalCashRegister_LocalCashRegisterId",
                        column: x => x.LocalCashRegisterId,
                        principalTable: "LocalCashRegister",
                        principalColumn: "LocalCashRegisterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalCashMovement_LocalCashRegisterId_MovementDateTime",
                table: "LocalCashMovement",
                columns: new[] { "LocalCashRegisterId", "MovementDateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_LocalCashMovement_ServerCashMovementId",
                table: "LocalCashMovement",
                column: "ServerCashMovementId",
                unique: true,
                filter: "\"ServerCashMovementId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocalCashRegister_OpeningUserId_Status_CachedAtUtc",
                table: "LocalCashRegister",
                columns: new[] { "OpeningUserId", "Status", "CachedAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_LocalCashRegister_ServerCashRegisterId",
                table: "LocalCashRegister",
                column: "ServerCashRegisterId",
                unique: true,
                filter: "\"ServerCashRegisterId\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalCashMovement");

            migrationBuilder.DropTable(
                name: "LocalCashRegister");
        }
    }
}
