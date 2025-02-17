using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecFullstackAngular.Api.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablesInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    CodAs = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.CodAs);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.CodAu);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Codl = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Editora = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Edicao = table.Column<int>(type: "INTEGER", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "VARCHAR(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Codl);
                });

            migrationBuilder.CreateTable(
                name: "LivroAssunto",
                columns: table => new
                {
                    Livro_CodI = table.Column<int>(type: "INTEGER", nullable: false),
                    Assunto_codAs = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAssunto", x => new { x.Livro_CodI, x.Assunto_codAs });
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Assunto_Assunto_codAs",
                        column: x => x.Assunto_codAs,
                        principalTable: "Assunto",
                        principalColumn: "CodAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Livros_Livro_CodI",
                        column: x => x.Livro_CodI,
                        principalTable: "Livros",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    Livro_CodI = table.Column<int>(type: "INTEGER", nullable: false),
                    Autor_CodAu = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => new { x.Livro_CodI, x.Autor_CodAu });
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_Autor_CodAu",
                        column: x => x.Autor_CodAu,
                        principalTable: "Autor",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livros_Livro_CodI",
                        column: x => x.Livro_CodI,
                        principalTable: "Livros",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_Assunto_codAs",
                table: "LivroAssunto",
                column: "Assunto_codAs");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_Autor_CodAu",
                table: "LivroAutor",
                column: "Autor_CodAu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAssunto");

            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
