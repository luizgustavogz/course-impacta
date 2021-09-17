using Microsoft.EntityFrameworkCore.Migrations;

namespace Exc3_EF.Migrations
{
    public partial class ForeignKeyProdutoMarca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lcunha_tblMarca",
                columns: table => new
                {
                    Id_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Produto_Marca = table.Column<int>(type: "int", nullable: false),
                    Nome_Marca = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lcunha_tblMarca", x => x.Id_Marca);
                    table.ForeignKey(
                        name: "FK_lcunha_tblMarca_lcunha_tblProduto_Id_Produto_Marca",
                        column: x => x.Id_Produto_Marca,
                        principalTable: "lcunha_tblProduto",
                        principalColumn: "Id_Produto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lcunha_tblMarca_Id_Produto_Marca",
                table: "lcunha_tblMarca",
                column: "Id_Produto_Marca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lcunha_tblMarca");
        }
    }
}
