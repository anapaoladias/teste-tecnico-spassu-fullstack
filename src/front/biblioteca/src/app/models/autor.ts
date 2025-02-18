export class Autor {
    codigo: number;
    nome: string;

    constructor(
        codigo: number = 0,
        nome: string = '',
    ) {
        this.codigo = codigo;
        this.nome = nome;
    }
}  