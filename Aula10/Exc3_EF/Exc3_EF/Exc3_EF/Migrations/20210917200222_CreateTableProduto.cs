using Microsoft.EntityFrameworkCore.Migrations;

namespace Exc3_EF.Migrations
{
    public partial class CreateTableProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lcunha_tblProduto",
                columns: table => new
                {
                    Id_Produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Produto = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Valor_Produto = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lcunha_tblProduto", x => x.Id_Produto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lcunha_tblProduto");
        }
    }
}
