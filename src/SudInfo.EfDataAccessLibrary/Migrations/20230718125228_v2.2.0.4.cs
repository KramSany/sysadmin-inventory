using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class v2204 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBroken",
                table: "Printers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDecommissioned",
                table: "Printers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStock",
                table: "Printers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBroken",
                table: "Monitors",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDecommissioned",
                table: "Monitors",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStock",
                table: "Monitors",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBroken",
                table: "Printers");

            migrationBuilder.DropColumn(
                name: "IsDecommissioned",
                table: "Printers");

            migrationBuilder.DropColumn(
                name: "IsStock",
                table: "Printers");

            migrationBuilder.DropColumn(
                name: "IsBroken",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "IsDecommissioned",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "IsStock",
                table: "Monitors");
        }
    }
}
