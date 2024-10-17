using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Danilo.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalarioLiquido",
                table: "Folhas",
                newName: "Liquido");

            migrationBuilder.RenameColumn(
                name: "SalarioBruto",
                table: "Folhas",
                newName: "Ir");

            migrationBuilder.RenameColumn(
                name: "ImpostoIrrf",
                table: "Folhas",
                newName: "Inss");

            migrationBuilder.RenameColumn(
                name: "ImpostoInss",
                table: "Folhas",
                newName: "Fgts");

            migrationBuilder.RenameColumn(
                name: "ImpostoFgts",
                table: "Folhas",
                newName: "Bruto");

            migrationBuilder.RenameColumn(
                name: "FolhaId",
                table: "Folhas",
                newName: "Id");

            migrationBuilder.AlterColumn<double>(
                name: "Quantidade",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Liquido",
                table: "Folhas",
                newName: "SalarioLiquido");

            migrationBuilder.RenameColumn(
                name: "Ir",
                table: "Folhas",
                newName: "SalarioBruto");

            migrationBuilder.RenameColumn(
                name: "Inss",
                table: "Folhas",
                newName: "ImpostoIrrf");

            migrationBuilder.RenameColumn(
                name: "Fgts",
                table: "Folhas",
                newName: "ImpostoInss");

            migrationBuilder.RenameColumn(
                name: "Bruto",
                table: "Folhas",
                newName: "ImpostoFgts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Folhas",
                newName: "FolhaId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
