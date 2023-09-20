using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbMigration.Persistence.EF.SQL.Migrations
{
    public partial class init04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Foods",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Foods");
        }
    }
}
