using Aula04.Interfaces;

namespace Aula04.Models;

public class PrestadorServico : IPagavel
{
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; } // Mantendo o CNPJ que você já tinha
    public decimal ValorHora { get; set; }
    public int HorasTrabalhadas { get; set; }

    public PrestadorServico(string razaoSocial, string cnpj, decimal valorHora, int horasTrabalhadas)
    {
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        ValorHora = valorHora;
        HorasTrabalhadas = horasTrabalhadas;
    }

    public decimal CalcularPagamento()
    {
        decimal valorBruto = ValorHora * HorasTrabalhadas;

        // Regra de Negócio: Retenção de impostos para serviços acima de 1000
        if (valorBruto > 1000.00m)
        {
            return valorBruto * 0.95m; // Retém 5%, paga 95%
        }

        return valorBruto;
    }
}