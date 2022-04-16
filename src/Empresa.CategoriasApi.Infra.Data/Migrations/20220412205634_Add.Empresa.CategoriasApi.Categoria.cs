using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa.CategoriasApi.Infra.Data.Migrations
{
    public partial class AddEmpresaCategoriasApiCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    categoria_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    categoria = table.Column<string>(type: "VarChar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.categoria_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoria_categoria",
                table: "categoria",
                column: "categoria",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
