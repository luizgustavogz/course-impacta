using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMercadoFinal.Migrations
{
    public partial class UsuarioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblUsuario",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_Usuario = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CD_Email = table.Column<string>(type: "VARCHAR(60)", nullable: true),
                    CD_Senha = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CD_Perfil_ = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsuario", x => x.ID_Usuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblUsuario");
        }
    }
}
