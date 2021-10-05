using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMercadoFinal.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProduto",
                columns: table => new
                {
                    Id_Produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_Produto = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Vlr_Produto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Dt_Validade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduto", x => x.Id_Produto);
                });

            migrationBuilder.CreateTable(
                name: "tblVenda",
                columns: table => new
                {
                    Id_Venda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Usuario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Vlr_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVenda", x => x.Id_Venda);
                    table.ForeignKey(
                        name: "FK_tblVenda_IdentityUser_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblVenda_Item",
                columns: table => new
                {
                    Id_Venda_Item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Produto = table.Column<int>(type: "int", nullable: false),
                    Id_Venda = table.Column<int>(type: "int", nullable: false),
                    Qtd_Item = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVenda_Item", x => x.Id_Venda_Item);
                    table.ForeignKey(
                        name: "FK_TblVenda_Item_tblProduto_Id_Produto",
                        column: x => x.Id_Produto,
                        principalTable: "tblProduto",
                        principalColumn: "Id_Produto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblVenda_Item_tblVenda_Id_Venda",
                        column: x => x.Id_Venda,
                        principalTable: "tblVenda",
                        principalColumn: "Id_Venda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblVenda_Id_Usuario",
                table: "tblVenda",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TblVenda_Item_Id_Produto",
                table: "TblVenda_Item",
                column: "Id_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_TblVenda_Item_Id_Venda",
                table: "TblVenda_Item",
                column: "Id_Venda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblVenda_Item");

            migrationBuilder.DropTable(
                name: "tblProduto");

            migrationBuilder.DropTable(
                name: "tblVenda");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
