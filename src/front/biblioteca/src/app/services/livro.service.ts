import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Livro } from '../models/livro';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class LivroService {
  private apiUrl = `${environment.apiUrl}/assuntos`;

  constructor(private http: HttpClient) { }

  getLivros(): Observable<Livro[]> {
    return this.http.get<Livro[]>(this.apiUrl);
  }

  addLivro(livro: Livro): Observable<Livro> {
    return this.http.post<Livro>(this.apiUrl, livro);
  }

  deleteLivro(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
