import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { LivroComponent } from './app/components/livro/livro.component';
import { routes } from './app/app.routes';

bootstrapApplication(LivroComponent, {
  providers: [provideHttpClient(), provideRouter(routes)]
}).catch(err => console.error(err));
