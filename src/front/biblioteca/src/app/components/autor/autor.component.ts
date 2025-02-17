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

  constructor(private autorService: AutorService) { }

  ngOnInit() {
    this.autorService.getAutores().subscribe(data => this.autores = data);
  }
}