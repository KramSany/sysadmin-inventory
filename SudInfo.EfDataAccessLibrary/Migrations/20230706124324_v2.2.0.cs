using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class v220 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BreakdownDescription",
                table: "Computers",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<bool>(
                name: "IsDecommissioned",
                table: "Computers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDecommissioned",
                table: "Computers");

            migrationBuilder.AlterColumn<string>(
                name: "BreakdownDescription",
                table: "Computers",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
