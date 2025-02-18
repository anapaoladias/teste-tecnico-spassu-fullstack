# teste-tecnico-spassu-fullstack

## Instruções de execução local

### Requisitos mínimos de ambiente
- Windows 11
- Banco de Dados SQL Server 2019
- Visual Studio 2022
- .NET Core 8.0.3
- nodejs v22.14.0
- npm 10.9.2
- ng 19.1.7

### Back
- Abra o SQL Server e crie um novo banco de dados 'Biblioteca' `CREATE DATABASE Biblioteca`
- Abrir solution 'src/TesteTecFullstackAngular.sln' no Visual Studio (como administrador)
- Executar F5 e copiar a url que subiu local (ex.: https://localhost:7187)
- Verifique no console a execução das Migrations de criaçao das Tabelas no Banco de Dados

### Front
- Navegue até o diretório src/front/biblioteca
- Edite a variável `apiUrl` em `src/environment.ts` com a Url copiada do back
- Execute o comando `ng serve`
- Abra o navegador na url local indicada no console

## Evidências

### Back

### Front