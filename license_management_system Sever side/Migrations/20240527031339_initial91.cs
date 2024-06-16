using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial91 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulesRequestKey");

            migrationBuilder.AddColumn<int>(
                name: "RequestKeyRequestID",
                table: "Modules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModuleID",
                table: "EndClients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_RequestKeyRequestID",
                table: "Modules",
                column: "RequestKeyRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_RequestKeys_RequestKeyRequestID",
                table: "Modules",
                column: "RequestKeyRequestID",
                principalTable: "RequestKeys",
                principalColumn: "request_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_RequestKeys_RequestKeyRequestID",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_RequestKeyRequestID",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "RequestKeyRequestID",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ModuleID",
                table: "EndClients");

            migrationBuilder.CreateTable(
                name: "ModulesRequestKey",
                columns: table => new
                {
                    ModulesId = table.Column<int>(type: "int", nullable: false),
                    RequestKeyRequestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesRequestKey", x => new { x.ModulesId, x.RequestKeyRequestID });
                    table.ForeignKey(
                        name: "FK_ModulesRequestKey_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulesRequestKey_RequestKeys_RequestKeyRequestID",
                        column: x => x.RequestKeyRequestID,
                        principalTable: "RequestKeys",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModulesRequestKey_RequestKeyRequestID",
                table: "ModulesRequestKey",
                column: "RequestKeyRequestID");
        }
    }
}
