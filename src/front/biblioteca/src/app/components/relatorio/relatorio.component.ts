import { Component, OnInit } from '@angular/core';
import { RelatorioService } from '../../services/relatorio.service';
import { Relatorio } from '../../models/relatorio';

@Component({
  selector: 'app-relatorio',
  templateUrl: './relatorio.component.html',
  styleUrl: './relatorio.component.css',
  providers: [RelatorioService]
})
export class RelatorioComponent implements OnInit {
  //
  relatorio: Relatorio[] = [];

  constructor(private relatorioService: RelatorioService) { }

  ngOnInit() {
    this.relatorioService.getLivrosAgrupadosPorAutor().subscribe(data => {
      this.relatorio = data;
    });
  }
}
