using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneDirectoryApp.ReportData.Migrations
{
    public partial class ReportContextDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Report",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ReportName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    RecordUserCount = table.Column<int>(nullable: false),
                    RecordPhoneCount = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report",
                schema: "public");
        }
    }
}
