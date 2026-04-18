using Aula04.Classes;

// Vetor (Array) de objetos
Funcionario[] equipe = new Funcionario[2];

try 
{
    Console.WriteLine("--- Cadastro de Equipe ---");

    // Interação com o console
    Console.Write("Nome do Desenvolvedor: ");
    string nomeDev = Console.ReadLine() ?? "Sem Nome";
    
    // Tratamento de Erros na conversão
    double salDev;
    Console.Write("Salário Base: ");
    string entradaSalario = Console.ReadLine()!;

    // TryParse: Tenta converter. Se conseguir, guarda em salDev e retorna true.
    while (!double.TryParse(entradaSalario, out salDev))
    {
        Console.Write("Valor inválido! Digite o salário novamente: ");
        entradaSalario = Console.ReadLine()!;
    }

    equipe[0] = new Desenvolvedor(1, nomeDev, salDev);
    equipe[1] = new Gerente(2, "Ana Gerente", 5000, 1500);

    Console.WriteLine("\n--- Relatório de Pagamentos ---");

    // Estrutura de Repetição (foreach)
    foreach (var func in equipe)
    {
        // Estrutura Condicional
        if (func != null)
        {
            // Polimorfismo em ação: chama o método correto para cada tipo
            Console.WriteLine($"ID: {func.Id} | Nome: {func.Nome} | Total: R$ {func.CalcularPagamento():F2}");
        }
    }
}
catch (FormatException)
{
    Console.WriteLine("Erro: Você deve digitar um número válido para o salário.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro inesperado: {ex.Message}");
}
