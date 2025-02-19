import { Component, OnInit } from '@angular/core';
import { RelatorioService } from '../../services/relatorio.service';

@Component({
  selector: 'app-relatorio',
  imports: [],
  templateUrl: './relatorio.component.html',
  styleUrl: './relatorio.component.css',
  providers: [RelatorioService],
})
export class RelatorioComponent implements OnInit {
  //

  constructor(relatorioService: RelatorioService) { }

  ngOnInit() {
    //
  }


}
