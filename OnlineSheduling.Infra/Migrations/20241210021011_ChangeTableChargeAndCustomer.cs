using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineScheduling.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableChargeAndCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTransactionId",
                table: "Charge");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Customer",
                type: "VARCHAR(11)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SolicitationPaymentId",
                table: "Charge",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SolicitationPaymentId",
                table: "Charge");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedTransactionId",
                table: "Charge",
                type: "UNIQUEIDENTIFIER",
                nullable: true);
        }
    }
}
