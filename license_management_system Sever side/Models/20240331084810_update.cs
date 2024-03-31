using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientSTs",
                columns: table => new
                {
                    CID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TImePeriod = table.Column<int>(type: "int", nullable: false),
                    PartnerRequested = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partner = table.Column<bool>(type: "bit", nullable: false),
                    Finance = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSTs", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerMac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidDate = table.Column<int>(type: "int", nullable: false),
                    BFI = table.Column<bool>(type: "bit", nullable: false),
                    MR = table.Column<bool>(type: "bit", nullable: false),
                    Retail = table.Column<bool>(type: "bit", nullable: false),
                    Modules = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Cid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientSTs");

            migrationBuilder.DropTable(
                name: "Keys");
        }
    }
}
