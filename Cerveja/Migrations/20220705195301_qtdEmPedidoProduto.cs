using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cerveja.Migrations
{
    public partial class qtdEmPedidoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "PedidoProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "PedidoProdutos");
        }
    }
}
