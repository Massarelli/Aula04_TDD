// 1. Usings e Variáveis Iniciais (equipe, continuar...)
using Aula04.Models;

List<Funcionario> equipe = new List<Funcionario>();
bool continuar = true;

Console.WriteLine("--- Sistema SeDaConta: Gestão de Equipe ---");

// 2. O Loop Principal (while continuar)
while (continuar)
{
    Console.WriteLine("\n[1] Cadastrar Desenvolvedor");
    Console.WriteLine("[2] Cadastrar Gerente");
    Console.WriteLine("[3] Sair e Gerar Relatório");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine()!;

    if (opcao == "3")
    {
        continuar = false;
        continue;
    }

    if (opcao == "1" || opcao == "2")
    {
        // Usando nossos novos métodos!
        string nome = LerTexto("Nome: ");
        decimal salario = LerDecimal("Salário Base: ");

        if (opcao == "1")
        {
            equipe.Add(new Desenvolvedor(equipe.Count + 1, nome, salario));
        }
        else
        {
            decimal gratificacao = LerDecimal("Gratificação: ");
            equipe.Add(new Gerente(equipe.Count + 1, nome, salario, gratificacao));
        }
    }
}

// 3. O Relatório Final (foreach)
// Relatório Final
Console.WriteLine("\n--- Relatório Final de Pagamentos ---");
foreach (var func in equipe)
{
    Console.WriteLine($"ID: {func.Id} | Nome: {func.Nome} | Total: {func.CalcularPagamento():C}");
}

// 4. SEUS MÉTODOS AUXILIARES (Lá no final do arquivo)
// Método para ler texto sem deixar vazio
static string LerTexto(string mensagem)
{
    string entrada = "";
    while (string.IsNullOrWhiteSpace(entrada))
    {
        Console.Write(mensagem);
        entrada = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(entrada)) 
            Console.WriteLine("Erro: Campo obrigatório.");
    }
    return entrada;
}

// Método para ler decimal com segurança
static decimal LerDecimal(string mensagem)
{
    decimal valor;
    Console.Write(mensagem);
    while (!decimal.TryParse(Console.ReadLine(), out valor) || valor < 0)
    {
        Console.WriteLine("Erro: Digite um valor numérico válido (positivo).");
        Console.Write(mensagem);
    }
    return valor;
}