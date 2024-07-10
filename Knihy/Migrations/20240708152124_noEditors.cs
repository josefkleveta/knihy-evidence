using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knihy.Migrations
{
    /// <inheritdoc />
    public partial class noEditors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Editors_EditorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Editors");

            migrationBuilder.DropIndex(
                name: "IX_Books_EditorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Editors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_EditorId",
                table: "Books",
                column: "EditorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Editors_EditorId",
                table: "Books",
                column: "EditorId",
                principalTable: "Editors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
