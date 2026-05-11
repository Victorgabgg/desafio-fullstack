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


# Como rodar com docker

- Clonar o projeto e acessar
    - cd desafio-fullstack
- Subir toda a aplicação
    - docker compose up --build
- Acessar a aplicação 
    - Front: http://localhost:4200 ou http://localhost:4200/titulos
    - Back: http://localhost:8080/swagger


# Como rodar localmente

- Acessar a pasta do backend
- Restaurar as dependências 
- Criar banco SQLite (migrations)
- Atualizar banco de dados
    - dotnet ef database update
- Rodar
    - dotnet run

- Instalar as dependências no front e rodar
    -npm install
    -ng serve


# Pré-requisitos

instale:

- .NET SDK 10
- Node.js LTS
- Angular CLI

```bash
npm install -g @angular/cli
