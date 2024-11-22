using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineScheduling.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ALterTableScheduleAddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Schedule",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Schedule",
                newName: "Active");
        }
    }
}
