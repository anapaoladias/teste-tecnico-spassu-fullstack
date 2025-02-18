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
![image](https://github.com/user-attachments/assets/508ce725-d79e-4330-9f5c-c7f56daf59e1)

![image](https://github.com/user-attachments/assets/0b6fc7b8-72bb-4698-b534-fba68eb2ca79)

### Front

- Telas

![image](https://github.com/user-attachments/assets/9afc34a8-bb0e-44fb-9b33-e0ccd82e8ea0)

![image](https://github.com/user-attachments/assets/4e002586-c329-44b4-8ba9-142e0f801a90)

![image](https://github.com/user-attachments/assets/aca9d147-11ef-4f5f-a785-f1730d1efe69)

![image](https://github.com/user-attachments/assets/bd851b91-b54b-47de-b424-25d2c42b5622)

![image](https://github.com/user-attachments/assets/779603cb-f85c-49ba-890e-8d29f2814d0a)

- Relatório
![image](https://github.com/user-attachments/assets/b1572602-9c22-48df-8342-1e0ac7aa548b)
