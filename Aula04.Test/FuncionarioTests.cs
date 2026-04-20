using Aula04.Models;
using Xunit;

namespace Aula04.Test;

public class FuncionarioTests
{
    [Fact]
    public void Desenvolvedor_DeveReceberQuinzePorCentoDeBonus()
    {
        // Arrange (Preparar o cenário)
        decimal salarioBase = 2000.00m;
        decimal esperado = 2300.00m; // 2000 + 15%
        var dev = new Desenvolvedor(1, "Jefferson", salarioBase);

        // Act (Agir/Executar a funcionalidade)
        decimal resultado = dev.CalcularPagamento();

        // Assert (Verificar se o resultado é o esperado)
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void Gerente_DeveReceberGratificacaoTotal()
    {
        // Arrange
        decimal salarioBase = 5000.00m;
        decimal gratificacao = 1500.00m;
        decimal esperado = 6500.00m;
        var gerente = new Gerente(2, "Ana", salarioBase, gratificacao);

        // Act
        decimal resultado = gerente.CalcularPagamento();

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Theory] // Indica que este teste recebe parâmetros
    [InlineData(1000.00, 1000.00)] // Caso 1: Salário 1000 -> Esperado 1000
    [InlineData(2000.00, 2300.00)] // Caso 2: Salário 2000 -> Esperado 2300
    [InlineData(0.00, 0.00)]       // Caso 3: Salário 0 -> Esperado 0
    [InlineData(1500.00, 1500.00)] // Caso 4: Salário 1500 -> Esperado 1500 (Teste para salário sem bônus)
    public void CalcularPagamento_DeveAplicarQuinzePorCento_ParaVariosSalarios(decimal valorBase, decimal valorEsperado)
    {
        // Arrange
        var dev = new Desenvolvedor(1, "Teste", valorBase);

        // Act
        decimal resultado = dev.CalcularPagamento();
        Assert.Equal(valorEsperado, dev.CalcularPagamento());

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    [Fact]
    public void Construtor_NaoDeveAceitarSalarioNegativo()
    {
        // Arrange
        decimal salarioInvalido = -1000.00m;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Desenvolvedor(1, "Invalido", salarioInvalido));
    }

    [Fact]
    public void Nome_NaoDeveAceitarValorVazioOuNulo()
    {
        // Arrange
        var dev = new Desenvolvedor(1, "Jefferson", 2000m);

        // Act & Assert: Tentando mudar o nome para algo inválido
        Assert.Throws<ArgumentException>(() => dev.Nome = "");
    }

    [Fact]
public void ListaDeEquipe_DeveArmazenarVariosFuncionarios()
{
    // Arrange
    var listaEquipe = new List<Funcionario>();
    var dev = new Desenvolvedor(1, "Dev 1", 2000m);
    var gerente = new Gerente(2, "Gerente 1", 5000m, 1000m);

    // Act
    listaEquipe.Add(dev);
    listaEquipe.Add(gerente);

    // Assert
    Assert.Equal(2, listaEquipe.Count); // Verifica se há 2 itens
    Assert.Contains(dev, listaEquipe);  // Verifica se o dev está lá
    Assert.Contains(gerente, listaEquipe); // Verifica se a gerente está lá
}
}