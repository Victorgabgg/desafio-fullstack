# Desafio Fullstack - Sistema de Títulos

Sistema fullstack desenvolvido para cadastro e cálculo de títulos com parcelas, juros e multa.

O objetivo do projeto é demonstrar conhecimento em backend .NET, frontend Angular e boas práticas de arquitetura e testes.

---

# Funcionalidades

- Cadastro de títulos com parcelas
- Cálculo de valor atualizado com:
  - Juros por atraso (proporcional ao tempo)
  - Multa fixa sobre valor total
- Listagem de títulos
- Integração API REST entre frontend e backend
- Documentação via Swagger
- Testes unitários da regra de negócio

---

# Tecnologias utilizadas

## Backend
- .NET 10
- Entity Framework Core
- SQLite
- Swagger
- xUnit

## Frontend
- Angular 21
- Angular Material (latest)
- Reactive Forms
- TypeScript

---

# Como rodar

1 - Acessar a pasta do backend
2 - Restaurar as dependências 
    - dotnet restore
3 - Criar banco SQLite (migrations)
    - dotnet ef migrations add InitialCreate
4 - Atualizar banco de dados
    - dotnet ef database update
5 - Executar API
    - dotnet run

6- Instalar as dependências no front e rodar
npm install
ng serve



# Pré-requisitos

instale:

- .NET SDK 10
- Node.js LTS
- Angular CLI

```bash
npm install -g @angular/cli
