using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace range_ton_ricaud.Migrations
{
    /// <inheritdoc />
    public partial class ToolKeywordSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToolKeyword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolKeyword", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolToolKeyword",
                columns: table => new
                {
                    ToolKeywordsId = table.Column<int>(type: "integer", nullable: false),
                    ToolsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolToolKeyword", x => new { x.ToolKeywordsId, x.ToolsId });
                    table.ForeignKey(
                        name: "FK_ToolToolKeyword_ToolKeyword_ToolKeywordsId",
                        column: x => x.ToolKeywordsId,
                        principalTable: "ToolKeyword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToolToolKeyword_Tool_ToolsId",
                        column: x => x.ToolsId,
                        principalTable: "Tool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToolToolKeyword_ToolsId",
                table: "ToolToolKeyword",
                column: "ToolsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToolToolKeyword");

            migrationBuilder.DropTable(
                name: "ToolKeyword");
        }
    }
}
