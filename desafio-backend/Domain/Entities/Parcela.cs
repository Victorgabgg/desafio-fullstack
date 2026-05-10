using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities;

public class Parcela
{
    public Guid Id { get; set; }

    public int NumeroParcela { get; set; }

    public DateTime DataVencimento { get; set; }

    public decimal Valor { get; set; }

    public Guid TituloId { get; set; }
}
