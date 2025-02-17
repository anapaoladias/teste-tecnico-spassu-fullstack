import { Component, OnInit } from '@angular/core';
import { LivroService } from '../../services/livro.service';
import { Livro } from '../../models/livro';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-livro',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  providers: [LivroService],
  templateUrl: './livro.component.html'
})
export class LivroComponent implements OnInit {
  livros: Livro[] = [];

  constructor(private livroService: LivroService) { }

  ngOnInit() {
    this.livroService.getLivros().subscribe(data => this.livros = data);
  }
}