## Comandos utilizados para criação do front

### Iniciais
```
npm install -g @angular/cli
ng new biblioteca --defaults
cd biblioteca
ng generate component components/livro --standalone
ng generate component components/autor --standalone
ng generate component components/assunto --standalone
ng generate component components/relatorio --standalone
ng generate service services/livro
ng generate service services/autor
ng generate service services/assunto
ng generate service services/relatorio
```

### Apoio a construção das telas
```
npm install bootstrap
npm install @popperjs/core
ng add @ng-bootstrap/ng-bootstrap
npm install --save @ng-select/ng-select
```