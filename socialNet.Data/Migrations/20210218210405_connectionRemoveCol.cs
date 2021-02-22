using Microsoft.EntityFrameworkCore.Migrations;

namespace socialNet.Data.Migrations
{
    public partial class connectionRemoveCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Connected",
                table: "Connections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Connected",
                table: "Connections",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
