using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class configerdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPanals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivetDta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeactivatedDta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPanals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    moduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    moduleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.moduleId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Partners_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeverMacAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientId);
                    table.ForeignKey(
                        name: "FK_Clients_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RequestKeys",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isFinanceApproval = table.Column<bool>(type: "bit", nullable: false),
                    isPartnerMgrApproval = table.Column<bool>(type: "bit", nullable: false),
                    CommentFinaceMgt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentPartnerMgt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestKeys", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_RequestKeys_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "FinaceManagers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinaceManagers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_FinaceManagers_RequestKeys_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestKeys",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "FK_FinaceManagers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "licenseKeys",
                columns: table => new
                {
                    KeyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activetiondate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeactivatedDta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsIssused = table.Column<bool>(type: "bit", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licenseKeys", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_licenseKeys_RequestKeys_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestKeys",
                        principalColumn: "RequestId");
                });

            migrationBuilder.CreateTable(
                name: "PartnerManagers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerManagers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PartnerManagers_RequestKeys_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestKeys",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "FK_PartnerManagers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestKeyEndClinet",
                columns: table => new
                {
                    endClientsclientId = table.Column<int>(type: "int", nullable: false),
                    requestKeysRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestKeyEndClinet", x => new { x.endClientsclientId, x.requestKeysRequestId });
                    table.ForeignKey(
                        name: "FK_RequestKeyEndClinet_Clients_endClientsclientId",
                        column: x => x.endClientsclientId,
                        principalTable: "Clients",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestKeyEndClinet_RequestKeys_requestKeysRequestId",
                        column: x => x.requestKeysRequestId,
                        principalTable: "RequestKeys",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestKeyModules",
                columns: table => new
                {
                    modulesmoduleId = table.Column<int>(type: "int", nullable: false),
                    requestKeysRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestKeyModules", x => new { x.modulesmoduleId, x.requestKeysRequestId });
                    table.ForeignKey(
                        name: "FK_RequestKeyModules_Modules_modulesmoduleId",
                        column: x => x.modulesmoduleId,
                        principalTable: "Modules",
                        principalColumn: "moduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestKeyModules_RequestKeys_requestKeysRequestId",
                        column: x => x.requestKeysRequestId,
                        principalTable: "RequestKeys",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PartnerId",
                table: "Clients",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinaceManagers_RequestId",
                table: "FinaceManagers",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_licenseKeys_RequestId",
                table: "licenseKeys",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartnerManagers_RequestId",
                table: "PartnerManagers",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeyEndClinet_requestKeysRequestId",
                table: "RequestKeyEndClinet",
                column: "requestKeysRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeyModules_requestKeysRequestId",
                table: "RequestKeyModules",
                column: "requestKeysRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_PartnerId",
                table: "RequestKeys",
                column: "PartnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPanals");

            migrationBuilder.DropTable(
                name: "FinaceManagers");

            migrationBuilder.DropTable(
                name: "licenseKeys");

            migrationBuilder.DropTable(
                name: "PartnerManagers");

            migrationBuilder.DropTable(
                name: "RequestKeyEndClinet");

            migrationBuilder.DropTable(
                name: "RequestKeyModules");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "RequestKeys");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
