using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudInfo.EfDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Version = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Apps", static x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cartridges",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Remains = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Cartridges", static x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Contacts", static x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Link = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Login = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Passwords", static x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerRacks",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    InventarNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_ServerRacks", static x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ReminderTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Tasks", static x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NumberCabinet = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonalPhone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    WorkPhone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    PhoneLocal = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Users", static x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    InventarNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PosiitionInServerRack = table.Column<int>(type: "INTEGER", nullable: true),
                    IpAddress = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ServerRackId = table.Column<int>(type: "INTEGER", nullable: true),
                    OperatingSystem = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Servers", static x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servers_ServerRacks_ServerRackId",
                        column: static x => x.ServerRackId,
                        principalTable: "ServerRacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ip = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    OS = table.Column<int>(type: "INTEGER", nullable: false),
                    CPU = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GPU = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ROM = table.Column<int>(type: "INTEGER", nullable: false),
                    RAM = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberCabinet = table.Column<int>(type: "INTEGER", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InventarNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    YearRelease = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Computers", static x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_Users_UserId",
                        column: static x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rutokens",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    EndDateCertificate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Rutokens", static x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rutokens_Users_UserId",
                        column: static x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppEntityComputer",
                columns: static table => new
                {
                    AppsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ComputersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_AppEntityComputer", static x => new { x.AppsId, x.ComputersId });
                    table.ForeignKey(
                        name: "FK_AppEntityComputer_Apps_AppsId",
                        column: static x => x.AppsId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppEntityComputer_Computers_ComputersId",
                        column: static x => x.ComputersId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ScreenSize = table.Column<int>(type: "INTEGER", nullable: false),
                    ScreenResolutionWidth = table.Column<int>(type: "INTEGER", nullable: false),
                    ScreenResolutionHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InventarNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    YearRelease = table.Column<int>(type: "INTEGER", nullable: false),
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Monitors", static x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitors_Computers_ComputerId",
                        column: static x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Peripheries",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InventarNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Peripheries", static x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peripheries_Computers_ComputerId",
                        column: static x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Printers",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Ip = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    NumberCabinet = table.Column<int>(type: "INTEGER", nullable: false),
                    YearRelease = table.Column<int>(type: "INTEGER", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InventarNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_Printers", static x => x.Id);
                    table.ForeignKey(
                        name: "FK_Printers_Computers_ComputerId",
                        column: static x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppEntityComputer_ComputersId",
                table: "AppEntityComputer",
                column: "ComputersId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridges_Name",
                table: "Cartridges",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_UserId",
                table: "Computers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_ComputerId",
                table: "Monitors",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Peripheries_ComputerId",
                table: "Peripheries",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Printers_ComputerId",
                table: "Printers",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rutokens_UserId",
                table: "Rutokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerRacks_Position",
                table: "ServerRacks",
                column: "Position",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servers_ServerRackId",
                table: "Servers",
                column: "ServerRackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppEntityComputer");

            migrationBuilder.DropTable(
                name: "Cartridges");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "Peripheries");

            migrationBuilder.DropTable(
                name: "Printers");

            migrationBuilder.DropTable(
                name: "Rutokens");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "ServerRacks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
