using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineScheduling.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableProfessionalServiceAddId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Schedule",
                newName: "ScheduleAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProfessionalServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProfessionalServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProfessionalServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfessionalServices");

            migrationBuilder.RenameColumn(
                name: "ScheduleAt",
                table: "Schedule",
                newName: "Date");
        }
    }
}
