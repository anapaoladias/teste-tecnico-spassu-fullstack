import { Component, OnInit, TemplateRef } from '@angular/core';
import { AssuntoService } from '../../services/assunto.service';
import { Assunto } from '../../models/assunto';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-assunto',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  providers: [AssuntoService],
  templateUrl: './assunto.component.html'
})
export class AssuntoComponent implements OnInit {
  assuntos: Assunto[] = [];
  assunto = { codigo: 0, descricao: '' };
  mostrarModalNova = false;
  mostrarAlertSucesso = false;
  mostrarAlertErro = false;
  mensagemSucesso = '';
  mensagemErro = '';

  constructor(private assuntoService: AssuntoService, private modalService: NgbModal) { }

  ngOnInit() {
    this.obterLista();
  }

  obterLista() {
    this.assuntoService.getAssuntos().subscribe(data => {
      this.assuntos = data;
    });
  }

  openModal(content: TemplateRef<any>) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  abrirModalEditar(assunto: any, modal: TemplateRef<any>) {
    this.assunto = { ...assunto };
    this.openModal(modal);
  }

  criarRegistro() {
    this.assuntoService.addAssunto(this.assunto).subscribe(
      (registro) => {
        this.tratarMsgSucesso('Registro criado com sucesso!');
      },
      (erro) => {
        this.tratarMsgErro(erro);
      }
    );
  }

  atualizarRegistro() {
    this.assuntoService.alterAssunto(this.assunto.codigo, this.assunto).subscribe(
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
    this.assuntoService.deleteAssunto(codigo).subscribe(
      (registro) => {
        this.tratarMsgSucesso('Registro excluído com sucesso!');
      },
      (erro) => {
        this.tratarMsgErro(erro);
      }
    );
  }

  tratarMsgSucesso(msg: string) {
    this.assunto = { codigo: 0, descricao: '' };
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