using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TitulosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TituloService _service;

    public TitulosController(
        AppDbContext context,
        TituloService service)
    {
        _context = context;
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CreateTituloDto dto)
    {
        var titulo = new Titulo
        {
            Id = Guid.NewGuid(),
            NumeroTitulo = dto.NumeroTitulo,
            NomeDevedor = dto.NomeDevedor,
            CpfDevedor = dto.CpfDevedor,
            PercentualJuros = dto.PercentualJuros,
            PercentualMulta = dto.PercentualMulta,
            Parcelas = dto.Parcelas.Select(p => new Parcela
            {
                Id = Guid.NewGuid(),
                NumeroParcela = p.NumeroParcela,
                DataVencimento = p.DataVencimento,
                Valor = p.Valor
            }).ToList()
        };

        await _context.Titulos.AddAsync(titulo);

        await _context.SaveChangesAsync();

        return Ok(titulo);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var hoje = DateTime.Now;

        var titulos = await _context.Titulos
            .Include(t => t.Parcelas)
            .ToListAsync();

        var resultado = titulos.Select(t =>
        {
            var parcelas = t.Parcelas ?? new List<Parcela>();

            return new
            {
                t.NumeroTitulo,
                t.NomeDevedor,

                QuantidadeParcelas = parcelas.Count,

                ValorOriginal = parcelas.Sum(p => p.Valor),

                DiasEmAtraso = parcelas.Any()
                    ? parcelas.Max(p =>
                        Math.Max((hoje - p.DataVencimento).Days, 0)
                      )
                    : 0,

                ValorAtualizado = _service.CalcularValorAtualizado(t, hoje)
            };
        });

        return Ok(resultado);
    }
}