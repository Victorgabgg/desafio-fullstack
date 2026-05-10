using System;
using System.Collections.Generic;
using Application.Services;
using Domain.Entities;
using Xunit;

public class TituloServiceTests
{
    [Fact]
    public void CalcularValorAtualizado_Deve_Calcular_JurosEMulta_Corretamente()
    {
        var service = new TituloService();

        var titulo = new Titulo
        {
            PercentualJuros = 10m,   
            PercentualMulta = 10m,  
            Parcelas = new List<Parcela>
            {
                new Parcela
                {
                    Valor = 500m,
                    DataVencimento = new DateTime(2024, 01, 01)
                },
                new Parcela
                {
                    Valor = 500m,
                    DataVencimento = new DateTime(2024, 01, 01)
                }
            }
        };

        var dataReferencia = new DateTime(2024, 01, 10); 


        var resultado = service.CalcularValorAtualizado(titulo, dataReferencia);

        decimal valorOriginal = 1000m;
        decimal multaEsperada = 100m; 

        decimal jurosDiario = (10m / 100m) / 30m; 
        decimal jurosEsperado = jurosDiario * 9 * 1000m;

        var esperado = valorOriginal + multaEsperada + jurosEsperado;

        Assert.Equal(esperado, resultado);
    }
}