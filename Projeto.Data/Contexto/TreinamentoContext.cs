using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.Data.Entidades;

namespace Projeto.Data.Contexto;

public partial class TreinamentoContext : DbContext
{
    private readonly IConfiguration _configuration;

    public TreinamentoContext()
    {
    }

    public TreinamentoContext(
        DbContextOptions<TreinamentoContext> options,
        IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<AniversariantesDoAno> AniversariantesDoAnos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("conexaoBanco"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alunos__3214EC076DBE36D6");

            entity.Property(e => e.Aniversario).HasColumnType("datetime");
            entity.Property(e => e.Documento)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nome).IsUnicode(false);
        });

        modelBuilder.Entity<AniversariantesDoAno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AniversariantesDoAno");

            entity.Property(e => e.Documento)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DOCUMENTO");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.Property(e => e.Criacao).HasColumnType("datetime");
            entity.Property(e => e.NomeCurso).IsUnicode(false);
        });

        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.Property(e => e.Descricao).IsUnicode(false);
            entity.Property(e => e.Nome).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
