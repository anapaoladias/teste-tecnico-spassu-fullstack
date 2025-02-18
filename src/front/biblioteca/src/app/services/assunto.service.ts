import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Assunto } from '../models/assunto';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AssuntoService {
  private apiUrl = `${environment.apiUrl}/assuntos`;

  constructor(private http: HttpClient) { }

  getAssuntos(): Observable<Assunto[]> { return this.http.get<Assunto[]>(this.apiUrl); }
  getAssunto(id: number): Observable<Assunto> { return this.http.get<Assunto>(`${this.apiUrl}/${id}`); }
  addAssunto(assunto: Assunto): Observable<Assunto> { return this.http.post<Assunto>(this.apiUrl, assunto); }
  alterAssunto(id: number, assunto: Assunto): Observable<Assunto> { return this.http.put<Assunto>(`${this.apiUrl}/${id}`, assunto); }
  deleteAssunto(id: number): Observable<void> { return this.http.delete<void>(`${this.apiUrl}/${id}`); }
}
