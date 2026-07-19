using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class v22010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneLocal",
                table: "Users",
                newName: "LocalPhone");

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InventarNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsBroken = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    BreakdownDescription = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    IsDecommissioned = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Phones", static x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Users_UserId",
                        column: static x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.RenameColumn(
                name: "LocalPhone",
                table: "Users",
                newName: "PhoneLocal");
        }
    }
}
