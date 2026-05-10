using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Titulo> Titulos { get; set; }
    public DbSet<Parcela> Parcelas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Titulo>()
            .HasMany(t => t.Parcelas)
            .WithOne()
            .HasForeignKey(p => p.TituloId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Titulo>()
            .Property(t => t.NumeroTitulo)
            .IsRequired();

        modelBuilder.Entity<Titulo>()
            .Property(t => t.NomeDevedor)
            .IsRequired();

        modelBuilder.Entity<Parcela>()
            .Property(p => p.Valor)
            .HasColumnType("decimal(18,2)");
    }
}