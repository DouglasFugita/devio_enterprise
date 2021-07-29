using Microsoft.EntityFrameworkCore.Migrations;

namespace NStore.Carrinho.API.Migrations
{
    public partial class carrinhoCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItems_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItems");

            migrationBuilder.AlterColumn<string>(
                name: "VoucherCodigo",
                table: "CarrinhoCliente",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItems_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItems",
                column: "CarrinhoId",
                principalTable: "CarrinhoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItems_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItems");

            migrationBuilder.AlterColumn<string>(
                name: "VoucherCodigo",
                table: "CarrinhoCliente",
                type: "varchar(50",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItems_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItems",
                column: "CarrinhoId",
                principalTable: "CarrinhoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
