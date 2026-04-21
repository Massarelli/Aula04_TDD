using Aula04.Interfaces;
namespace Aula04.Models;

// Abstração e Herança
public abstract class Funcionario : IPagavel
{
    // Propriedades com Encapsulamento
    public int Id { get; private set; }
    private string _nome = string.Empty; // Inicializa com um texto vazio para silenciar o aviso

    public string Nome 
    { 
        get { return _nome; } 
        set 
        { 
            if (string.IsNullOrWhiteSpace(value)) 
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }
            _nome = value; 
        } 
    }
    protected decimal SalarioBase { get; set; }

    public Funcionario(int id, string nome, decimal salarioBase)
    {
        if (salarioBase < 0)
        {
        throw new ArgumentException("O salário não pode ser negativo.");
        }

        if (string.IsNullOrWhiteSpace(nome))
        {
        throw new ArgumentException("O nome do funcionário é obrigatório.");
        }
        
        Id = id;
        Nome = nome;
        SalarioBase = salarioBase;
    }

    // Polimorfismo: Cada tipo de funcionário calculará de um jeito
    public virtual decimal CalcularPagamento() 
    {
        return SalarioBase;
    }
}

public class Desenvolvedor : Funcionario
{
    public Desenvolvedor(int id, string nome, decimal salarioBase) 
        : base(id, nome, salarioBase) { }

    public override decimal CalcularPagamento()
    {
    // Estrutura Condicional: Se o salário for até 1500, não ganha bônus
    if (SalarioBase <= 1500.00m)
    {
        return SalarioBase;
    }

    // Caso contrário, mantém o bônus de 15%
    return SalarioBase * 1.15m;
    }
}

public class Gerente : Funcionario
{
    public decimal Gratificacao { get; set; }

    public Gerente(int id, string nome, decimal salarioBase, decimal gratificacao) 
        : base(id, nome, salarioBase) // Chama o pai
    {
        Gratificacao = gratificacao; // Faz a parte específica dele
    }

    public override decimal CalcularPagamento()
    {
        return SalarioBase + Gratificacao;
    }
}