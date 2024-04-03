using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_RequestKeys_RequestKeyId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_RequestKeyId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "RequestKeyId",
                table: "Modules");

            migrationBuilder.CreateTable(
                name: "ModulesRequestKeys",
                columns: table => new
                {
                    ModulesId = table.Column<int>(type: "int", nullable: false),
                    RequestKeysRequestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesRequestKeys", x => new { x.ModulesId, x.RequestKeysRequestID });
                    table.ForeignKey(
                        name: "FK_ModulesRequestKeys_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulesRequestKeys_RequestKeys_RequestKeysRequestID",
                        column: x => x.RequestKeysRequestID,
                        principalTable: "RequestKeys",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModulesRequestKeys_RequestKeysRequestID",
                table: "ModulesRequestKeys",
                column: "RequestKeysRequestID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulesRequestKeys");

            migrationBuilder.AddColumn<int>(
                name: "RequestKeyId",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_RequestKeyId",
                table: "Modules",
                column: "RequestKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_RequestKeys_RequestKeyId",
                table: "Modules",
                column: "RequestKeyId",
                principalTable: "RequestKeys",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
