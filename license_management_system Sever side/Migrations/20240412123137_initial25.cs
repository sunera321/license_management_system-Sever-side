using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "License_keys",
                columns: table => new
                {
                    key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    activation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deactivated_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License_keys", x => x.key_id);
                    table.ForeignKey(
                        name: "FK_License_keys_RequestKeys_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestKeys",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_License_keys_RequestId",
                table: "License_keys",
                column: "RequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "License_keys");

            migrationBuilder.CreateTable(
                name: "LicenseKeys",
                columns: table => new
                {
                    key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    activation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deactivated_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Key_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseKeys", x => x.key_id);
                    table.ForeignKey(
                        name: "FK_LicenseKeys_RequestKeys_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestKeys",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicenseKeys_RequestId",
                table: "LicenseKeys",
                column: "RequestId",
                unique: true);
        }
    }
}
