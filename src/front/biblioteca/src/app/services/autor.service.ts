import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Autor } from '../models/autor';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AutorService {
  private apiUrl = `${environment.apiUrl}/autores`;

  constructor(private http: HttpClient) { }

  getAutores(): Observable<Autor[]> { return this.http.get<Autor[]>(this.apiUrl); }
  getAutor(id: number): Observable<Autor> { return this.http.get<Autor>(`${this.apiUrl}/${id}`); }
  addAutor(autor: Autor): Observable<Autor> { return this.http.post<Autor>(this.apiUrl, autor); }
  alterAutor(id: number, autor: Autor): Observable<Autor> { return this.http.put<Autor>(`${this.apiUrl}/${id}`, autor); }
  deleteAutor(id: number): Observable<void> { return this.http.delete<void>(`${this.apiUrl}/${id}`); }
}
