using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knihy.Migrations
{
    /// <inheritdoc />
    public partial class NoEditor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Editors_EditorId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editors",
                table: "Editors");

            migrationBuilder.RenameTable(
                name: "Editors",
                newName: "Editor");

            migrationBuilder.AlterColumn<int>(
                name: "EditorId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editor",
                table: "Editor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Editor_EditorId",
                table: "Books",
                column: "EditorId",
                principalTable: "Editor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Editor_EditorId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editor",
                table: "Editor");

            migrationBuilder.RenameTable(
                name: "Editor",
                newName: "Editors");

            migrationBuilder.AlterColumn<int>(
                name: "EditorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editors",
                table: "Editors",
                column: "Id");

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
