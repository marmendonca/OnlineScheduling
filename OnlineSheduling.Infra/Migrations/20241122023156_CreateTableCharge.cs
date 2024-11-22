using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineScheduling.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableCharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "INT", nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    Status = table.Column<int>(type: "INT", nullable: false),
                    CreatedTransactionId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    CompletedTransactionId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charge_ScheduleId",
                table: "Charge",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charge");
        }
    }
}
