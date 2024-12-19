using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineScheduling.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableCharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Charge_ScheduleId",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "SolicitationPaymentId",
                table: "Charge");

            migrationBuilder.RenameColumn(
                name: "CompletedTransactionId",
                table: "Charge",
                newName: "EfiBankChargeId");

            migrationBuilder.CreateTable(
                name: "EfiBankCharge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolicitationPaymentId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    LocationId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<int>(type: "INT", nullable: false),
                    ImageQrCode = table.Column<string>(type: "VARCHAR(5000)", nullable: true),
                    LinkQrCode = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    PixCopyAndPaste = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EfiBankCharge", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charge_ScheduleId",
                table: "Charge",
                column: "ScheduleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EfiBankCharge");

            migrationBuilder.DropIndex(
                name: "IX_Charge_ScheduleId",
                table: "Charge");

            migrationBuilder.RenameColumn(
                name: "EfiBankChargeId",
                table: "Charge",
                newName: "CompletedTransactionId");

            migrationBuilder.AddColumn<Guid>(
                name: "SolicitationPaymentId",
                table: "Charge",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Charge_ScheduleId",
                table: "Charge",
                column: "ScheduleId");
        }
    }
}
