import { Component, OnInit, TemplateRef } from '@angular/core';
import { AutorService } from '../../services/autor.service';
import { Autor } from '../../models/autor';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-autor',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  providers: [AutorService],
  templateUrl: './autor.component.html'
})
export class AutorComponent implements OnInit {
  autores: Autor[] = [];
  autor = { codigo: 0, nome: '' };
  mostrarModalNova = false;
  mostrarAlertSucesso = false;
  mostrarAlertErro = false;
  mensagemSucesso = '';
  mensagemErro = '';

  constructor(private autorService: AutorService, private modalService: NgbModal) { }

  ngOnInit() {
    this.obterLista();
  }

  obterLista() {
    this.autorService.getAutores().subscribe(data => {
      this.autores = data;
    });
  }

  openModal(content: TemplateRef<any>) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  abrirModalEditar(autor: any, modal: TemplateRef<any>) {
    this.autor = { ...autor };
    this.openModal(modal);
  }

  criarRegistro() {
    this.autorService.addAutor(this.autor).subscribe(
      (registro) => {
        this.tratarMsgSucesso('Registro criado com sucesso!');
      },
      (erro) => {
        this.tratarMsgErro(erro);
      }
    );
  }

  atualizarRegistro() {
    this.autorService.alterAutor(this.autor.codigo, this.autor).subscribe(
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
    this.autorService.deleteAutor(codigo).subscribe(
      (registro) => {
        this.tratarMsgSucesso('Registro excluído com sucesso!');
      },
      (erro) => {
        this.tratarMsgErro(erro);
      }
    );
  }

  tratarMsgSucesso(msg: string) {
    this.autor = { codigo: 0, nome: '' };
    this.mensagemSucesso = 'Registro criado com sucesso!';
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