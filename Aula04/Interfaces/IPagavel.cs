namespace Aula04.Interfaces;

public interface IPagavel
{
    // Interfaces não dizem COMO fazer, apenas O QUE ter.
    // Não usamos modificadores de acesso (public) aqui dentro.
    decimal CalcularPagamento();
}