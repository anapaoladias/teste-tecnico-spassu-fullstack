import { Component, OnInit, TemplateRef } from '@angular/core';
import { LivroService } from '../../services/livro.service';
import { AutorService } from '../../services/autor.service';
import { AssuntoService } from '../../services/assunto.service';
import { Livro } from '../../models/livro';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-livro',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  providers: [LivroService, AssuntoService, AutorService],
  templateUrl: './livro.component.html'
})
export class LivroComponent implements OnInit {
  livros: Livro[] = [];
  livro = new Livro();
  mostrarModalNova = false;
  mostrarAlertSucesso = false;
  mostrarAlertErro = false;
  mensagemSucesso = '';
  mensagemErro = '';

  constructor(
    private livroService: LivroService,
    private assuntoService: AssuntoService,
    private autorService: AutorService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.obterLista();
  }

  obterLista() {
    this.livroService.getLivros().subscribe(data => {
      this.livros = data;
    });
  }

  openModal(content: TemplateRef<any>) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  abrirModalEditar(livro: any, modal: TemplateRef<any>) {
    this.livro = { ...livro };
    this.openModal(modal);
  }

  criarRegistro() {
    this.livro.valor = parseFloat(this.livro.valor.toString().replace(",", "."));

    this.livroService.addLivro(this.livro).subscribe(
      (registro) => {
        this.tratarMsgSucesso('Registro criado com sucesso!');
      },
      (erro) => {
        this.tratarMsgErro(erro);
      }
    );
  }

  atualizarRegistro() {
    console.log(this.livro.valor.toString());
    this.livro.valor = parseFloat(this.livro.valor.toString().replace(",", "."));

    this.livroService.alterLivro(this.livro.codigo, this.livro).subscribe(
      (registro) => {
        this.tratarMsgSucesso('Registro atualizado com sucesso!');
      },
      (erro) => {
        this.tratarMsgErro(erro);
      }
    );
  }

  confirmarExclusao(codigo: number) {
    const confirmacao = confirm('Tem certeza que deseja excluir este registro?');
    if (confirmacao) {
      this.excluirRegistro(codigo);
    }
  }

  excluirRegistro(codigo: number) {
    this.livroService.deleteLivro(codigo).subscribe(
      (registro) => {
        this.tratarMsgSucesso('Registro excluído com sucesso!');
      },
      (erro) => {
        this.tratarMsgErro(erro);
      }
    );
  }

  tratarMsgSucesso(msg: string) {
    this.livro = new Livro();
    this.mensagemSucesso = msg;
    this.mostrarAlertSucesso = true;
    this.mostrarAlertErro = false;
    this.mensagemErro = '';

    this.modalService.dismissAll();
    this.obterLista();
  }

  tratarMsgErro(response: any) {
    this.mensagemSucesso = '';
    this.mostrarAlertSucesso = false;
    this.mostrarAlertErro = true;

    if (response.status == 400) {
      if (response.error.errors) {
        let errorMessage = Object.values(response.error.errors).join(', ');
        this.mensagemErro = `Requisição inválida - Erros: ${errorMessage}`
      }
      else {
        this.mensagemErro = `Requisição inválida - Erro: ${response.error.error}`
      }
    }

    console.error(response);
    this.modalService.dismissAll();
  }
}