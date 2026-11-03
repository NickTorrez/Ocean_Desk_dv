using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocean_Desk_dv.Data.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class InitialOceanDeskLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalCustomer",
                columns: table => new
                {
                    LocalCustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServerCustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CachedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SynchronizedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SyncStatus = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false),
                    LastSyncError = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalCustomer", x => x.LocalCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "OfflineOperation",
                columns: table => new
                {
                    OperationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EntityType = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    LocalRecordId = table.Column<int>(type: "INTEGER", nullable: false),
                    PayloadJson = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false),
                    AttemptCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastAttemptAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NextAttemptAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SynchronizedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastError = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfflineOperation", x => x.OperationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalCustomer_Phone",
                table: "LocalCustomer",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_LocalCustomer_ServerCustomerId",
                table: "LocalCustomer",
                column: "ServerCustomerId",
                unique: true,
                filter: "\"ServerCustomerId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocalCustomer_SyncStatus_CreatedAtUtc",
                table: "LocalCustomer",
                columns: new[] { "SyncStatus", "CreatedAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_OfflineOperation_EntityType_LocalRecordId",
                table: "OfflineOperation",
                columns: new[] { "EntityType", "LocalRecordId" });

            migrationBuilder.CreateIndex(
                name: "IX_OfflineOperation_Status_NextAttemptAtUtc_CreatedAtUtc",
                table: "OfflineOperation",
                columns: new[] { "Status", "NextAttemptAtUtc", "CreatedAtUtc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalCustomer");

            migrationBuilder.DropTable(
                name: "OfflineOperation");
        }
    }
}
