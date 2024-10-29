using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineScheduling.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableNameAvailiableDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableTime");

            migrationBuilder.CreateTable(
                name: "AvailableDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalId = table.Column<int>(type: "INT", nullable: true, defaultValue: 0),
                    StartAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Interval = table.Column<int>(type: "INT", nullable: false),
                    Active = table.Column<int>(type: "INT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableDate_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDate_ProfessionalId",
                table: "AvailableDate",
                column: "ProfessionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableDate");

            migrationBuilder.CreateTable(
                name: "AvailableTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalId = table.Column<int>(type: "INT", nullable: true, defaultValue: 0),
                    Active = table.Column<int>(type: "INT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    Interval = table.Column<int>(type: "INT", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableTime_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTime_ProfessionalId",
                table: "AvailableTime",
                column: "ProfessionalId");
        }
    }
}
