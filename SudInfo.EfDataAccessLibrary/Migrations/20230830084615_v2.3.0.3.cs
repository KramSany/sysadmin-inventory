using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class v2303 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BreakdownDescription",
                table: "Peripheries",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBroken",
                table: "Peripheries",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakdownDescription",
                table: "Peripheries");

            migrationBuilder.DropColumn(
                name: "IsBroken",
                table: "Peripheries");
        }
    }
}
