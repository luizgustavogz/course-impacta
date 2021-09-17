using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEF.Migrations
{
    public partial class ForeignKeyUserBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_User_Blog",
                table: "tblBlog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblBlog_Id_User_Blog",
                table: "tblBlog",
                column: "Id_User_Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBlog_tblUser_Id_User_Blog",
                table: "tblBlog",
                column: "Id_User_Blog",
                principalTable: "tblUser",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBlog_tblUser_Id_User_Blog",
                table: "tblBlog");

            migrationBuilder.DropIndex(
                name: "IX_tblBlog_Id_User_Blog",
                table: "tblBlog");

            migrationBuilder.DropColumn(
                name: "Id_User_Blog",
                table: "tblBlog");
        }
    }
}
