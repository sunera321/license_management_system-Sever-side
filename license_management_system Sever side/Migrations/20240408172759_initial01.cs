using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseKey",
                columns: table => new
                {
                    key_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    activation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deactivated_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseKey", x => x.key_id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinaceManager_UserRole = table.Column<int>(type: "int", nullable: true),
                    Partner_UserRole = table.Column<int>(type: "int", nullable: true),
                    UserRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EndClients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MackAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndClients", x => x.id);
                    table.ForeignKey(
                        name: "FK_EndClients_Users_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestKeys",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_finance_mgt = table.Column<int>(type: "int", nullable: true),
                    status_Partner_mgt = table.Column<int>(type: "int", nullable: true),
                    comment_finace_mgt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    comment_partner_mgt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    EndClientId = table.Column<int>(type: "int", nullable: false),
                    LicenseKeyId = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    FinaceManagerId = table.Column<int>(type: "int", nullable: true),
                    PartnerManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestKeys", x => x.request_id);
                    table.ForeignKey(
                        name: "FK_RequestKeys_EndClients_EndClientId",
                        column: x => x.EndClientId,
                        principalTable: "EndClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestKeys_LicenseKey_LicenseKeyId",
                        column: x => x.LicenseKeyId,
                        principalTable: "LicenseKey",
                        principalColumn: "key_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestKeys_Users_FinaceManagerId",
                        column: x => x.FinaceManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestKeys_Users_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RequestKeys_Users_PartnerManagerID",
                        column: x => x.PartnerManagerID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
                name: "IX_EndClients_PartnerId",
                table: "EndClients",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulesRequestKey_RequestKeyRequestID",
                table: "ModulesRequestKey",
                column: "RequestKeyRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_EndClientId",
                table: "RequestKeys",
                column: "EndClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_FinaceManagerId",
                table: "RequestKeys",
                column: "FinaceManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_LicenseKeyId",
                table: "RequestKeys",
                column: "LicenseKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_PartnerId",
                table: "RequestKeys",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_PartnerManagerID",
                table: "RequestKeys",
                column: "PartnerManagerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulesRequestKey");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "RequestKeys");

            migrationBuilder.DropTable(
                name: "EndClients");

            migrationBuilder.DropTable(
                name: "LicenseKey");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
