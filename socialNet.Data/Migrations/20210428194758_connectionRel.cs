using Microsoft.EntityFrameworkCore.Migrations;

namespace socialNet.Data.Migrations
{
    public partial class connectionRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Connections_UserId",
                table: "Connections");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_UserId",
                table: "Connections",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Connections_UserId",
                table: "Connections");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_UserId",
                table: "Connections",
                column: "UserId",
                unique: true);
        }
    }
}
