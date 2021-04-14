using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hahn.ApplicationProcess.February2021.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AssetName = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<int>(type: "integer", nullable: false),
                    CountryOfDepartment = table.Column<string>(type: "text", nullable: true),
                    EMailAddressOfDepartment = table.Column<string>(type: "text", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Broken = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
