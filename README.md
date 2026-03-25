# 🧪 Projeto de Automação de Testes - Minhas Finanças

Este repositório contém a suíte de testes desenvolvida para o desafio técnico de QA. O foco foi garantir a qualidade das regras de negócio e a integridade dos dados através de uma abordagem baseada na Pirâmide de Testes.

## 🚀 Tecnologias Obrigatórias Utilizadas
* **Back-end:** C# e .NET 9 com **xUnit**.
* **Front-end (React):** TypeScript com **Vitest** (Unitários) e **Playwright** (E2E).
* **CI/CD:** GitHub Actions (Execução automatizada dos testes).

## 🏗️ Estratégia de Testes (Pirâmide de Testes)

A estratégia foi estruturada para cobrir todas as camadas da aplicação:

### 1. Testes Unitários (Vitest)
* **Foco:** Lógica pura de negócio no Front-end React.
* **Cenário:** Validação das regras de idade para permissão de registro de receitas.
* **Justificativa:** Garantir que a lógica de cálculo e validação esteja correta de forma isolada e rápida.
* **Comando:** `cd frontendTests/vitest && npx vitest run`

### 2. Testes de Integração (xUnit)
* **Foco:** Persistência e Integridade referencial no Back-end .NET.
* **Cenário:** Validação da exclusão em cascata (BUG identificado nesta camada).
* **Justificativa:** Validar a comunicação entre o código e o banco de dados (InMemory), garantindo que a exclusão de registros pai remova os registros filhos.
* **Comando:** `cd backendTests && dotnet test`

### 3. Testes End-to-End (Playwright)
* **Foco:** Jornada real do usuário na interface React.
* **Cenário:** Fluxo completo de tentativa de inserção de receita por menores de idade.
* **Justificativa:** Garantir que todos os componentes (Front, API e Banco) funcionem juntos e que a interface exiba as travas de segurança corretamente.
* **Comando:** `cd frontendTests/playwright && npx playwright test`

## 🐞 Bugs Encontrados (Resumo)

Durante o ciclo de testes, foram identificadas falhas críticas:

* **[CRÍTICO] Falha na Exclusão em Cascata:** Ao deletar uma pessoa, suas transações permanecem no banco.
* **[UI/UX] Mensagem de Erro Genérica:** O sistema barra categorias inválidas, mas não informa o motivo ao usuário.

> Detalhes técnicos e prints de evidência estão disponíveis no arquivo **[BUGS.md](./docs/BUGS.md)**.


Nota sobre o CI/CD (GitHub Actions): > Os testes de integração de Back-end foram projetados para rodar localmente ou em um ambiente onde o código-fonte da API esteja presente. Como este repositório contém apenas a camada de testes, o pipeline do GitHub Actions executará com sucesso apenas os testes de Front-end (Unitários e E2E), enquanto os de Back-end devem ser validados via execução local com acesso ao código completo.

## 📁 Estrutura do Projeto
```text
meuProjetoTestes/
├── .github/workflows/   # Pipeline de CI/CD (GitHub Actions)
├── backendTests/        # Testes de Integração (C#)
├── frontendTests/
│   ├── vitest/          # Testes Unitários (React/TS)
│   └── playwright/      # Testes E2E (React/TS)
├── evidencias/          # Prints das falhas
└── docs/
    └── BUGS.md          # Relatório detalhado de falhas