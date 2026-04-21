using Aula04.Models;
using Aula04.Interfaces;
using Xunit;

namespace Aula04.Test;

public class PagamentoTests
{
    [Fact]
    public void DeveCalcularPagamentoDeDiferentesTiposPagaveis()
    {
        // Arrange (Preparação)
        var dev = new Desenvolvedor(1, "Carlos Dev", 5000m);
        var gerente = new Gerente(2, "Ana Gerente", 7000m, 2000m);
        var prestador = new PrestadorServico("Limpeza LTDA", "123", 50m, 10); // 50 * 10 = 500

        // Criamos uma lista da INTERFACE
        var listaPagaveis = new List<IPagavel> { dev, gerente, prestador };

        // Act (Ação)
        decimal totalPagamentos = 0;
        foreach (var item in listaPagaveis)
        {
            totalPagamentos += item.CalcularPagamento();
        }

        // Assert (Verificação)
        // Dev(5000) + Gerente(9000) + Prestador(500) = 14500
        // Antes era 14500, agora ajustamos para a realidade do bônus de 15%
        Assert.Equal(15250m, totalPagamentos);
    }

    [Fact]
public void PrestadorServico_DeveReterImposto_QuandoValorUltrapassaMil()
    {
        // Arrange: Passando os 4 argumentos agora (RazaoSocial, Cnpj, ValorHora, Horas)
        // 100 * 20 = 2000 (deve reter 5%)
        var prestador = new PrestadorServico("Consultoria TI", "12.345.678/0001-90", 100m, 20);

        // Act
        var resultado = prestador.CalcularPagamento();

        // Assert: 2000 - 5% = 1900
        Assert.Equal(1900m, resultado);
    }
    [Fact]
public void PrestadorServico_NaoDeveReterImposto_QuandoValorForExatamenteMil()
    {
        // Arrange: 100 * 10 = 1000 (No limite, não deve reter conforme nossa regra > 1000)
        var prestador = new PrestadorServico("Serviços Rapidos", "99.888.777/0001-11", 100m, 10);

        // Act
        var resultado = prestador.CalcularPagamento();

        // Assert: Deve retornar os 1000 cheios
        Assert.Equal(1000m, resultado);
    }
}