import { Component, OnInit } from '@angular/core';
import { AutorService } from '../../services/autor.service';
import { Autor } from '../../models/autor';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-autor',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  providers: [AutorService],
  templateUrl: './autor.component.html'
})
export class AutorComponent implements OnInit {
  autores: Autor[] = [];
  autor = { codigo: null, nome: '' };
  mensagemSucesso = '';

  criarAutor() {
    // Lógica para salvar o novo autor (envio para o backend)
    const novoAutor = { ...this.autor, codigo: this.autores.length + 1 };
    this.autores.push(novoAutor);
    this.mensagemSucesso = 'Autor adicionado com sucesso!';
    this.autor = { codigo: null, nome: '' }; // Resetar o campo nome após o sucesso
  }

  abrirModalEditar(autor: any) {
    this.autor = { ...autor };
  }

  atualizarAutor() {
    // Lógica para atualizar o autor (envio para o backend)
    const index = this.autores.findIndex(a => a.codigo === this.autor.codigo);
    if (index !== -1) {
      this.autores[index].nome = this.autor.nome;
      this.mensagemSucesso = 'Autor atualizado com sucesso!';
    }
  }

  confirmarExclusao(codigo: number) {
    // Definir o autor a ser excluído
    //this.autor.codigo = codigo;
  }

  excluirAutor() {
    // Lógica para excluir o autor (envio para o backend)
    this.autores = this.autores.filter(a => a.codigo !== this.autor.codigo);
    this.mensagemSucesso = 'Autor excluído com sucesso!';
  }

  constructor(private autorService: AutorService) { }

  ngOnInit() {
    this.autorService.getAutores().subscribe(data => this.autores = data);
  }
}