namespace Application.DTOs;

public class CreateTituloDto
{
    public string NumeroTitulo { get; set; }

    public string NomeDevedor { get; set; }

    public string CpfDevedor { get; set; }

    public decimal PercentualJuros { get; set; }

    public decimal PercentualMulta { get; set; }

    public List<CreateParcelaDto> Parcelas { get; set; }
}