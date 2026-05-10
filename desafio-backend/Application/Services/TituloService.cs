using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities;

namespace Application.Services;

public class TituloService
{
    public decimal CalcularValorAtualizado(Titulo titulo, DateTime dataReferencia)
    {
        decimal totalJuros = 0;
        decimal valorOriginalTotal = titulo.Parcelas.Sum(p => p.Valor);

        foreach (var parcela in titulo.Parcelas)
        {
            int diasAtraso = (dataReferencia - parcela.DataVencimento).Days;

            if (diasAtraso > 0)
            {
               
                decimal jurosDiario = (titulo.PercentualJuros / 100) / 30;
                totalJuros += jurosDiario * diasAtraso * parcela.Valor;
            }
        }

        decimal valorMulta = valorOriginalTotal * (titulo.PercentualMulta / 100);

        return valorOriginalTotal + valorMulta + totalJuros;
    }

}
