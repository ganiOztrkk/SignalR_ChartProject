using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SignalRChartServer.Models;

public partial class SatisDBContext : DbContext
{
    public SatisDBContext()
    {
    }

    public SatisDBContext(DbContextOptions<SatisDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personeller> Personellers { get; set; }

    public virtual DbSet<Satislar> Satislars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=SatisDB; User Id=sa; Password=148951753Gg(.);TrustServerCertificate=True; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personeller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Id");

            entity.ToTable("Personeller");

            entity.Property(e => e.Adi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Soyadi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Satislar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Satislar_PK");

            entity.ToTable("Satislar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
