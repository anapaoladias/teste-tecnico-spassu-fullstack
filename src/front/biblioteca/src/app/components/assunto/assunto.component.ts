import { Component, OnInit } from '@angular/core';
import { AssuntoService } from '../../services/assunto.service';
import { Assunto } from '../../models/assunto';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-assunto',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  providers: [AssuntoService],
  templateUrl: './assunto.component.html'
})

export class AssuntoComponent implements OnInit {
  assuntos: Assunto[] = [];

  constructor(private assuntoService: AssuntoService) { }

  ngOnInit() {
    this.assuntoService.getAssuntos().subscribe(data => this.assuntos = data);
  }
}