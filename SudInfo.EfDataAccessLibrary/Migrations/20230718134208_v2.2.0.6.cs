using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class v2206 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "Rutokens",
                newName: "SerialNumberRutoken");

            migrationBuilder.AddColumn<string>(
                name: "NumberCertificate",
                table: "Rutokens",
                type: "TEXT",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberCertificate",
                table: "Rutokens");

            migrationBuilder.RenameColumn(
                name: "SerialNumberRutoken",
                table: "Rutokens",
                newName: "SerialNumber");
        }
    }
}
