
using HotChocolate.Data;

using Microsoft.EntityFrameworkCore;

namespace GraphQLPruebas.Models;

public partial class AppJuJuDataBaseDevContext : DbContext
{
    public AppJuJuDataBaseDevContext()
    {
    }

    public AppJuJuDataBaseDevContext(DbContextOptions<AppJuJuDataBaseDevContext> options)
        : base(options)
    {
    }

    [UseSorting] public virtual DbSet<DEvento> DEventos { get; set; } = null!;

    public virtual DbSet<DLinksPorEvento> DLinksPorEventos { get; set; } = null!;

    public virtual DbSet<DRutasImagenesPorEvento> DRutasImagenesPorEventos { get; set; } = null!;

    public virtual DbSet<MMunicipio> MMunicipios { get; set; } = null!;

    public virtual DbSet<MProvincia> MProvincias { get; set; } = null!;

    public virtual DbSet<MTiposEvento> MTiposEventos { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AppJuJu_DataBase_Dev;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DEvento>(entity =>
        {
            entity.HasKey(e => e.PK).HasName("PK__tmp_ms_x__321507876DDA0893");

            entity.ToTable("d_Eventos");

            entity.HasIndex(e => e.FechaHora, "IX_FechaHora");

            entity.HasIndex(e => e.FkMunicipio, "IX_Municipio");

            entity.Property(e => e.PK).HasColumnName("PK");
            entity.Property(e => e.Elenco)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Entidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora).HasPrecision(0);
            entity.Property(e => e.FkMunicipio).HasColumnName("FK_Municipio");
            entity.Property(e => e.FkTipoEvento).HasColumnName("FK_TipoEvento");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InformacionAdicional)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.InformacionImportante)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Lugar)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.OtroTipoEvento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PrecioMaximo).HasColumnType("smallmoney");
            entity.Property(e => e.PrecioMinimo).HasColumnType("smallmoney");
            entity.Property(e => e.Sinopsis)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.FkMunicipioNavigation).WithMany(p => p.DEventos)
                .HasForeignKey(d => d.FkMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__d_Eventos__FK_Mu__71D1E811");

            entity.HasOne(d => d.FkTipoEventoNavigation).WithMany(p => p.DEventos)
                .HasForeignKey(d => d.FkTipoEvento)
                .HasConstraintName("FK__d_Eventos__FK_Ti__74AE54BC");
        });

        modelBuilder.Entity<DLinksPorEvento>(entity =>
        {
            entity.HasKey(e => new { e.FkEvento, e.Orden }).HasName("PK__tmp_ms_x__82092A344F8088F1");

            entity.ToTable("d_LinksPorEvento");

            entity.Property(e => e.FkEvento).HasColumnName("FK_Evento");
            entity.Property(e => e.Titulo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasOne(d => d.FkEventoNavigation).WithMany(p => p.DLinksPorEventos)
                .HasForeignKey(d => d.FkEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__d_LinksPo__FK_Ev__72C60C4A");
        });

        modelBuilder.Entity<DRutasImagenesPorEvento>(entity =>
        {
            entity.HasKey(e => new { e.FkEvento, e.Orden }).HasName("PK__tmp_ms_x__82092A344730641D");

            entity.ToTable("d_RutasImagenesPorEvento");

            entity.Property(e => e.FkEvento).HasColumnName("FK_Evento");
            entity.Property(e => e.Ruta)
                .HasMaxLength(260)
                .IsUnicode(false);

            entity.HasOne(d => d.FkEventoNavigation).WithMany(p => p.DRutasImagenesPorEventos)
                .HasForeignKey(d => d.FkEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__d_RutasIm__FK_Ev__73BA3083");
        });

        modelBuilder.Entity<MMunicipio>(entity =>
        {
            entity.HasKey(e => e.PK).HasName("PK__m_Munici__3215078773EAE072");

            entity.ToTable("m_Municipios");

            entity.HasIndex(e => e.Nombre, "IX_Nombre");

            entity.HasIndex(e => e.FkProvincia, "IX_Provincia");

            entity.Property(e => e.PK)
                .ValueGeneratedNever()
                .HasColumnName("PK");
            entity.Property(e => e.FkProvincia).HasColumnName("FK_Provincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.FkProvinciaNavigation).WithMany(p => p.MMunicipios)
                .HasForeignKey(d => d.FkProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__m_Municip__FK_Pr__267ABA7A");
        });

        modelBuilder.Entity<MProvincia>(entity =>
        {
            entity.HasKey(e => e.PK).HasName("PK__m_Provin__321507873FB2D8EE");

            entity.ToTable("m_Provincias");

            entity.HasIndex(e => e.Nombre, "IX_Nombre");

            entity.Property(e => e.PK)
                .ValueGeneratedNever()
                .HasColumnName("PK");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MTiposEvento>(entity =>
        {
            entity.HasKey(e => e.PK).HasName("PK__m_TiposE__321507874E9382CF");

            entity.ToTable("m_TiposEvento");

            entity.Property(e => e.PK)
                .ValueGeneratedNever()
                .HasColumnName("PK");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
