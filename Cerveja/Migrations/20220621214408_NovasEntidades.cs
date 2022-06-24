using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cerveja.Migrations
{
    public partial class NovasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rotulo",
                newName: "Nome");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Rotulo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Salario = table.Column<double>(type: "double", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedor_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VendedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Rotulo_PedidoId",
                table: "Rotulo",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_VendedorId",
                table: "Pedido",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rotulo_Pedido_PedidoId",
                table: "Rotulo",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rotulo_Pedido_PedidoId",
                table: "Rotulo");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Rotulo_PedidoId",
                table: "Rotulo");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Rotulo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Rotulo",
                newName: "Name");
        }
    }
}
