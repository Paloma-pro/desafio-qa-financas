using Xunit;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MinhaFinancas.Tests.Integration
{
    public class ExclusaoPessoasTest
    {
        [Fact]
        public void DeveExcluirTransacoesQuando_PessoaForExcluida()
        {
            var options = new DbContextOptionsBuilder<MinhasFinancasDbContext>()
                .UseInMemoryDatabase(databaseName: "TesteCascata")
                .Options;

                using (var context = new MinhasFinancasDbContext(options))
                {
                    var pessoa = new Pessoa {  };

                    context.Pessoas.Add(pessoa);
                    context.SaveChanges();

                    var gasto = new Transacao{  };

                    context.Transacoes.Add(gasto);
                    context.SaveChanges();
                }

                using (var context = new MinhasFinancasDbContext(options))
                {
                    var pessoaParaDeletar = context.Pessoas.First();
                    context.Pessoas.Remove(pessoaParaDeletar);
                    context.SaveChanges();
                }

                using (var context = new MinhasFinancasDbContext(options))
                {
                    var transacaoNoBanco = context.Transacoes.ToList();
                    Assert.Empty(transacaoNoBanco);
                }
        }
    }
}