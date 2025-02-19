import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Livro } from '../models/livro';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class RelatorioService {
  private apiUrl = `${environment.apiUrl}/Relatorios`;

  constructor(private http: HttpClient) { }

  getLivrosAgrupadosPorAutor(): Observable<any[]> { return this.http.get<any[]>(`${this.apiUrl}/livros/lista-agrupada-autor`); }
}
