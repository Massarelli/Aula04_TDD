namespace Aula04.Classes;

// Abstração e Herança
public abstract class Funcionario
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
    protected double SalarioBase { get; set; }

    public Funcionario(int id, string nome, double salarioBase)
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
    // Estrutura Condicional: Se o salário for até 1500, não ganha bônus
    if (SalarioBase <= 1500.00)
    {
        return SalarioBase;
    }

    // Caso contrário, mantém o bônus de 15%
    return SalarioBase * 1.15;
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