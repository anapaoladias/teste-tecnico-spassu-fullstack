using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecFullstackAngular.Api.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class CreateViewRelatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				create view vwLivrosCompleta 
				as
					select 
					l.Codl as CodigoLivro, 
					l.Titulo,
					l.Editora,
					l.Edicao,
					l.AnoPublicacao,
					l.Valor,
					ass.CodAs as CodigoAssunto,
					ass.Descricao as Assunto,
					au.CodAu as CodigoAutor,
					au.Nome as Autor
					from Livro l (nolock)
					join Livro_Assunto lass (nolock) on l.Codl = lass.Livro_CodI
					join Assunto ass (nolock) on lass.Assunto_codAs = ass.CodAs
					join Livro_Autor la (nolock) on l.Codl = la.livro_CodI
					join Autor au (nolock) on la.Autor_CodAu = au.CodAu
				");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
