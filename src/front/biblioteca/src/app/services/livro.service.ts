import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Livro } from '../models/livro';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class LivroService {
  private apiUrl = `${environment.apiUrl}/livros`;

  constructor(private http: HttpClient) { }

  getLivros(): Observable<Livro[]> { return this.http.get<Livro[]>(this.apiUrl); }
  getLivro(id: number): Observable<Livro> { return this.http.get<Livro>(`${this.apiUrl}/${id}`); }
  addLivro(livro: Livro): Observable<Livro> { return this.http.post<Livro>(this.apiUrl, livro); }
  alterLivro(id: number, livro: Livro): Observable<Livro> { return this.http.put<Livro>(`${this.apiUrl}/${id}`, livro); }
  deleteLivro(id: number): Observable<void> { return this.http.delete<void>(`${this.apiUrl}/${id}`); }
}
