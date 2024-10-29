using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineScheduling.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAvailableDateRemoveFKProfessional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableDate_Professional_ProfessionalId",
                table: "AvailableDate");

            migrationBuilder.DropIndex(
                name: "IX_AvailableDate_ProfessionalId",
                table: "AvailableDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AvailableDate_ProfessionalId",
                table: "AvailableDate",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableDate_Professional_ProfessionalId",
                table: "AvailableDate",
                column: "ProfessionalId",
                principalTable: "Professional",
                principalColumn: "Id");
        }
    }
}
