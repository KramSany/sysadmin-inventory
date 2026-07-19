using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class v221 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPersonal",
                table: "Phones",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPersonal",
                table: "Peripheries",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPersonal",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "IsPersonal",
                table: "Peripheries");
        }
    }
}
