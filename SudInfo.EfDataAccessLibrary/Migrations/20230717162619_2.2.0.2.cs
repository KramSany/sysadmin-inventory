using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class _2202 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cartridges",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cartridges");
        }
    }
}
