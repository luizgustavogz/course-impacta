using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoMVC.Migrations
{
    public partial class UpdateIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVenda_tblUsuario_Id_Usuario",
                table: "tblVenda");

            migrationBuilder.DropTable(
                name: "tblUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Usuario",
                table: "tblVenda",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblVenda_AspNetUsers_Id_Usuario",
                table: "tblVenda",
                column: "Id_Usuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVenda_AspNetUsers_Id_Usuario",
                table: "tblVenda");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Usuario",
                table: "tblVenda",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tblUsuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_Usuario = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsuario", x => x.Id_Usuario);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tblVenda_tblUsuario_Id_Usuario",
                table: "tblVenda",
                column: "Id_Usuario",
                principalTable: "tblUsuario",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
