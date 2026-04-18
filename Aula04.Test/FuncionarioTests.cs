using Aula04.Classes;
using Xunit;

namespace Aula04.Test;

public class FuncionarioTests
{
    [Fact]
    public void Desenvolvedor_DeveReceberQuinzePorCentoDeBonus()
    {
        // Arrange (Preparar o cenário)
        double salarioBase = 2000.00;
        double esperado = 2300.00; // 2000 + 15%
        var dev = new Desenvolvedor(1, "Jefferson", salarioBase);

        // Act (Agir/Executar a funcionalidade)
        double resultado = dev.CalcularPagamento();

        // Assert (Verificar se o resultado é o esperado)
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void Gerente_DeveReceberGratificacaoTotal()
    {
        // Arrange
        double salarioBase = 5000.00;
        double gratificacao = 1500.00;
        double esperado = 6500.00;
        var gerente = new Gerente(2, "Ana", salarioBase, gratificacao);

        // Act
        double resultado = gerente.CalcularPagamento();

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Theory] // Indica que este teste recebe parâmetros
    [InlineData(1000.00, 1000.00)] // Caso 1: Salário 1000 -> Esperado 1000
    [InlineData(2000.00, 2300.00)] // Caso 2: Salário 2000 -> Esperado 2300
    [InlineData(0.00, 0.00)]       // Caso 3: Salário 0 -> Esperado 0
    [InlineData(1500.00, 1500.00)] // Caso 4: Salário 1500 -> Esperado 1500 (Teste para salário sem bônus)
    public void CalcularPagamento_DeveAplicarQuinzePorCento_ParaVariosSalarios(double valorBase, double valorEsperado)
    {
        // Arrange
        var dev = new Desenvolvedor(1, "Teste", valorBase);

        // Act
        double resultado = dev.CalcularPagamento();

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    [Fact]
    public void Construtor_NaoDeveAceitarSalarioNegativo()
    {
        // Arrange
        double salarioInvalido = -1000.00;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Desenvolvedor(1, "Invalido", salarioInvalido));
    }

    [Fact]
    public void Nome_NaoDeveAceitarValorVazioOuNulo()
    {
        // Arrange
        var dev = new Desenvolvedor(1, "Jefferson", 2000);

        // Act & Assert: Tentando mudar o nome para algo inválido
        Assert.Throws<ArgumentException>(() => dev.Nome = "");
    }
}