using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleID",
                table: "EndClients");

            migrationBuilder.RenameColumn(
                name: "MackAddress",
                table: "EndClients",
                newName: "MacAddress");

            migrationBuilder.RenameColumn(
                name: "ActivetDate",
                table: "EndClients",
                newName: "ActiveDate");

            migrationBuilder.CreateTable(
                name: "EndClientModules",
                columns: table => new
                {
                    EndClientId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndClientModules", x => new { x.EndClientId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_EndClientModules_EndClients_EndClientId",
                        column: x => x.EndClientId,
                        principalTable: "EndClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndClientModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EndClientModules_ModuleId",
                table: "EndClientModules",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndClientModules");

            migrationBuilder.RenameColumn(
                name: "MacAddress",
                table: "EndClients",
                newName: "MackAddress");

            migrationBuilder.RenameColumn(
                name: "ActiveDate",
                table: "EndClients",
                newName: "ActivetDate");

            migrationBuilder.AddColumn<int>(
                name: "ModuleID",
                table: "EndClients",
                type: "int",
                nullable: true);
        }
    }
}
