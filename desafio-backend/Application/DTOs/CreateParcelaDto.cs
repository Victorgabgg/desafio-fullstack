using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs;

public class CreateParcelaDto
{
    public int NumeroParcela { get; set; }

    public DateTime DataVencimento { get; set; }

    public decimal Valor { get; set; }
}
