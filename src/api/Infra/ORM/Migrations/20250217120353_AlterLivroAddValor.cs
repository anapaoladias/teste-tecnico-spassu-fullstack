using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecFullstackAngular.Api.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AlterLivroAddValor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Livros",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Livros");
        }
    }
}
