using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class v2305 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TyepROM",
                table: "Computers",
                newName: "TypeROM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeROM",
                table: "Computers",
                newName: "TyepROM");
        }
    }
}
