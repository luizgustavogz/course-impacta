using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEF.Migrations
{
    public partial class RenameTableUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "tblUser");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tblUser",
                newName: "Nome_User");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblUser",
                newName: "Id_User");

            migrationBuilder.AlterColumn<string>(
                name: "Nome_User",
                table: "tblUser",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser",
                column: "Id_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser");

            migrationBuilder.RenameTable(
                name: "tblUser",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Nome_User",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "User",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }
    }
}
