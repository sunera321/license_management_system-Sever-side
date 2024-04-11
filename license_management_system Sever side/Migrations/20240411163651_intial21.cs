using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class intial21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulesRequestKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
