# 🐞 Relatório de Erros (Bug Report)

Este documento detalha as falhas encontradas durante o ciclo de testes manuais e automatizados.

---

## [BUG-01] Falha Crítica: Exclusão em Cascata (Integridade de Dados)
**Severidade:** Crítica 🔴  
**Onde:** Back-end (API/Banco de Dados)

### Descrição:
Ao excluir um registro de `Pessoa`, as `Transações` vinculadas a ela não são removidas, permanecendo como dados no banco de dados.

### Evidência Técnica:
* **Teste de Integração:** `ExclusaoPessoasTest.cs` (Status: **FALHANDO** conforme esperado).
* **Print:** ![Bug Cascata](meuProjetoTestes\evidencias\TransacaoAparenteAposDeletarPessoa.png)

---

## [BUG-02] UX: Mensagem de Erro Genérica
**Severidade:** Menor 🟡  
**Onde:** Front-end / Integração

### Descrição:
Ao tentar salvar uma Categoria incompatível com o Tipo (ex: Categoria "Salário" com Tipo "Despesa"), o sistema exibe apenas "Erro ao salvar", sem explicar o motivo da regra de negócio.

### Evidência:
* **Print:** ![Erro Categoria](meuProjetoTestes\evidencias\ErroCategoria.png)

## [BUG-03] Dashboard: Falha no Resumo Financeiro e Layout
**Severidade:** Alta 🟠  
**Onde:** Dashboard (Página Principal)

### Descrição:
Os indicadores de "Saldo", "Receita" e "Despesa" não refletem os valores das transações cadastradas na lista de "Últimas Transações". Além disso, o gráfico de Resumo Mensal apresenta sérios erros de renderização.

### Evidências:
* **Lógica:** Transação de R$ 3.000,00 visível na lista, mas card de Receita exibe R$ 0,00.
* **UI:** Textos sobrepostos no gráfico de pizza, tornando a legenda ilegível.
* **Print:** ![Bug Dashboard](meuProjetoTestes\evidencias\Dashboard.png)
