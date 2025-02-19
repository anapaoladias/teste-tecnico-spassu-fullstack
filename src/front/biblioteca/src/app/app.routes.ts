import { Routes } from '@angular/router';
import { LivroComponent } from './components/livro/livro.component';
import { AutorComponent } from './components/autor/autor.component';
import { AssuntoComponent } from './components/assunto/assunto.component';
import { RelatorioComponent } from './components/relatorio/relatorio.component';

export const routes: Routes = [
  { path: 'livros', component: LivroComponent },
  { path: 'autores', component: AutorComponent },
  { path: 'assuntos', component: AssuntoComponent },
  { path: 'relatorio', component: RelatorioComponent },
  { path: '', redirectTo: '/livros', pathMatch: 'full' }
];
