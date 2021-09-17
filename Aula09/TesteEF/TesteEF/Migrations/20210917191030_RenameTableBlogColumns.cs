using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEF.Migrations
{
    public partial class RenameTableBlogColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "tblBlog");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tblBlog",
                newName: "Desc_Blog");

            migrationBuilder.RenameColumn(
                name: "CreatedTimestamp",
                table: "tblBlog",
                newName: "DT_Created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblBlog",
                newName: "Id_Blog");

            migrationBuilder.AlterColumn<string>(
                name: "Desc_Blog",
                table: "tblBlog",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblBlog",
                table: "tblBlog",
                column: "Id_Blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblBlog",
                table: "tblBlog");

            migrationBuilder.RenameTable(
                name: "tblBlog",
                newName: "Blog");

            migrationBuilder.RenameColumn(
                name: "Desc_Blog",
                table: "Blog",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DT_Created",
                table: "Blog",
                newName: "CreatedTimestamp");

            migrationBuilder.RenameColumn(
                name: "Id_Blog",
                table: "Blog",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");
        }
    }
}
