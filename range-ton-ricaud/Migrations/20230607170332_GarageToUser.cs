using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace range_ton_ricaud.Migrations
{
    /// <inheritdoc />
    public partial class GarageToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Garage",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Garage_UserId",
                table: "Garage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garage_AspNetUsers_UserId",
                table: "Garage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garage_AspNetUsers_UserId",
                table: "Garage");

            migrationBuilder.DropIndex(
                name: "IX_Garage_UserId",
                table: "Garage");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Garage");
        }
    }
}
