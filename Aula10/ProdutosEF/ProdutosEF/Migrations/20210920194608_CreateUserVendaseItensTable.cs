using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdutosEF.Migrations
{
    public partial class CreateUserVendaseItensTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_USUARIO = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDA",
                columns: table => new
                {
                    ID_VENDA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false),
                    VLR_TOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDA", x => x.ID_VENDA);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_TB_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDA_ITEM",
                columns: table => new
                {
                    ID_VENDA_ITEM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_VENDA = table.Column<int>(type: "int", nullable: false),
                    ID_PRODUTO = table.Column<int>(type: "int", nullable: false),
                    QTD_ITEM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDA_ITEM", x => x.ID_VENDA_ITEM);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_ITEM_TB_PRODUTO_ID_PRODUTO",
                        column: x => x.ID_PRODUTO,
                        principalTable: "TB_PRODUTO",
                        principalColumn: "ID_PRODUTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_ITEM_TB_VENDA_ID_VENDA",
                        column: x => x.ID_VENDA,
                        principalTable: "TB_VENDA",
                        principalColumn: "ID_VENDA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDA_ID_USUARIO",
                table: "TB_VENDA",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDA_ITEM_ID_PRODUTO",
                table: "TB_VENDA_ITEM",
                column: "ID_PRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDA_ITEM_ID_VENDA",
                table: "TB_VENDA_ITEM",
                column: "ID_VENDA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VENDA_ITEM");

            migrationBuilder.DropTable(
                name: "TB_VENDA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
