using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "EndClientModules",
                columns: table => new
                {
                    ModuleEndClientsId = table.Column<int>(type: "int", nullable: false),
                    ModuleEndClientsModulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndClientModules", x => new { x.ModuleEndClientsId, x.ModuleEndClientsModulesId });
                    table.ForeignKey(
                        name: "FK_EndClientModules_EndClients_ModuleEndClientsId",
                        column: x => x.ModuleEndClientsId,
                        principalTable: "EndClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndClientModules_Modules_ModuleEndClientsModulesId",
                        column: x => x.ModuleEndClientsModulesId,
                        principalTable: "Modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EndClientModules_ModuleEndClientsModulesId",
                table: "EndClientModules",
                column: "ModuleEndClientsModulesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "ModuleEndClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndClientId = table.Column<int>(type: "int", nullable: false),
                    ModulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleEndClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleEndClient_EndClients_EndClientId",
                        column: x => x.EndClientId,
                        principalTable: "EndClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleEndClient_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleEndClient_EndClientId",
                table: "ModuleEndClient",
                column: "EndClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleEndClient_ModulesId",
                table: "ModuleEndClient",
                column: "ModulesId");
        }
    }
}
