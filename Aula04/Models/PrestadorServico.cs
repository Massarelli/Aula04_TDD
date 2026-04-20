using Aula04.Interfaces;

namespace Aula04.Models;

public class PrestadorServico : IPagavel
{
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public decimal ValorHora { get; set; }
    public int HorasTrabalhadas { get; set; }

    public PrestadorServico(string razaoSocial, string cnpj, decimal valorHora, int horasTrabalhadas)
    {
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        ValorHora = valorHora;
        HorasTrabalhadas = horasTrabalhadas;
    }

    // Aqui está a obrigação do contrato IPagavel
    public decimal CalcularPagamento()
    {
        return ValorHora * HorasTrabalhadas;
    }
}