export class Relatorio {

    codigoAutor: number;
    autor: string;
    livros: 
      {
        codigoLivro: number,
        titulo: string,
        editora: string,
        edicao: number,
        anoPublicacao: number,
        valor: number,
        assuntos: string
      }[];

    constructor(
        codigoAutor: number = 0,
        autor: string = '',
        livros: {
            codigoLivro: number;
            titulo: string;
            editora: string;
            edicao: number;
            anoPublicacao: number;
            valor: number;
            assuntos: string;
        }[] = []
    ) {
        this.codigoAutor = codigoAutor;
        this.autor = autor;
        this.livros = livros;
    }

    [Symbol.iterator]() {
        let index = 0;
        const livros = this.livros;
        return {
            next: () => {
                if (index < livros.length) {
                    return { value: livros[index++], done: false };
                } else {
                    return { done: true };
                }
            }
        };
    }
}