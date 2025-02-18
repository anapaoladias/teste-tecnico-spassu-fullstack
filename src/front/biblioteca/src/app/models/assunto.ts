export class Assunto {
    codigo: number;
    descricao: string;

    constructor(
        codigo: number = 0,
        descricao: string = '',
    ) {
        this.codigo = codigo;
        this.descricao = descricao;
    }
}  