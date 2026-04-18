namespace Aula04.Classes;

// Abstração e Herança
public abstract class Funcionario
{
    // Propriedades com Encapsulamento
    public int Id { get; private set; }
    public string Nome { get; set; }
    protected double SalarioBase { get; set; }

    public Funcionario(int id, string nome, double salarioBase)
    {
        Id = id;
        Nome = nome;
        SalarioBase = salarioBase;
    }

    // Polimorfismo: Cada tipo de funcionário calculará de um jeito
    public virtual double CalcularPagamento() 
    {
        return SalarioBase;
    }
}

public class Desenvolvedor : Funcionario
{
    public Desenvolvedor(int id, string nome, double salarioBase) 
        : base(id, nome, salarioBase) { }

    public override double CalcularPagamento()
    {
        return SalarioBase * 1.15; // Aritmética: +15% bônus
    }
}

public class Gerente : Funcionario
{
    public double Gratificacao { get; set; }

    public Gerente(int id, string nome, double salarioBase, double gratificacao) 
        : base(id, nome, salarioBase) 
    {
        Gratificacao = gratificacao;
    }

    public override double CalcularPagamento()
    {
        return SalarioBase + Gratificacao;
    }
}