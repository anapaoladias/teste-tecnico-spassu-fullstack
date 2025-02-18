import { Assunto } from "./assunto";
import { Autor } from "./autor";

export class Livro {
    codigo: number;
    titulo: string;
    editora: string;
    edicao: number;
    anoPublicacao: string;
    valor: number;
    assuntos: Assunto[] = [];
    autores: Autor[] = [];

    constructor(
        codigo: number = 0,
        titulo: string = '',
        editora: string = '',
        edicao: number = 0,
        anoPublicacao: string = '',
        valor: number = 0
    ) {
        this.codigo = codigo;
        this.titulo = titulo;
        this.editora = editora;
        this.edicao = edicao;
        this.anoPublicacao = anoPublicacao;
        this.valor = valor;
    }
}


