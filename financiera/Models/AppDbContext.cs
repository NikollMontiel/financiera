using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace financiera.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<CambioMonedum> CambioMoneda { get; set; }

    public virtual DbSet<CatalogoMora> CatalogoMoras { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuotum> Cuota { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Desembolso> Desembolsos { get; set; }

    public virtual DbSet<EstadoCuotum> EstadoCuota { get; set; }

    public virtual DbSet<EstadoDesembolso> EstadoDesembolsos { get; set; }

    public virtual DbSet<EstadoEvaluacion> EstadoEvaluacions { get; set; }

    public virtual DbSet<EstadoPrestamo> EstadoPrestamos { get; set; }

    public virtual DbSet<Evaluacion> Evaluacions { get; set; }

    public virtual DbSet<Mora> Moras { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }

    public virtual DbSet<TipoMonedum> TipoMoneda { get; set; }

    public virtual DbSet<TipoPrestamo> TipoPrestamos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.IdAuditoria).HasName("PK__Auditori__7FD13FA0B016E1CC");

            entity.Property(e => e.IdAuditoria).ValueGeneratedNever();
            entity.Property(e => e.Accion).HasMaxLength(50);
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TablaAfectada).HasMaxLength(50);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Auditoria__IdUsu__17F790F9");
        });

        modelBuilder.Entity<CambioMonedum>(entity =>
        {
            entity.HasKey(e => e.IdCambioMoneda).HasName("PK__CambioMo__E4F5A752DE6A1417");

            entity.Property(e => e.IdCambioMoneda).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TasaCambio).HasColumnType("decimal(12, 6)");

            entity.HasOne(d => d.CodMonedaNavigation).WithMany(p => p.CambioMoneda)
                .HasForeignKey(d => d.CodMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CambioMon__CodMo__52593CB8");
        });

        modelBuilder.Entity<CatalogoMora>(entity =>
        {
            entity.HasKey(e => e.IdMoraCatalogo).HasName("PK__Catalogo__77B989C21EDE04AF");

            entity.ToTable("CatalogoMora");

            entity.Property(e => e.IdMoraCatalogo).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.PorcentajeInteres).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642E6877DA9");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Cedula, "IDX_Cliente_Cedula");

            entity.HasIndex(e => e.Cedula, "UQ__Cliente__B4ADFE38EBFD8A87").IsUnique();

            entity.Property(e => e.IdCliente).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(150);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PrimerApellido).HasMaxLength(50);
            entity.Property(e => e.PrimerNombre).HasMaxLength(50);
            entity.Property(e => e.RazonSocial).HasMaxLength(100);
            entity.Property(e => e.SegundoApellido).HasMaxLength(50);
            entity.Property(e => e.SegundoNombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_Cliente_Departamento");

            entity.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__IdTipoC__49C3F6B7");
        });

        modelBuilder.Entity<Cuotum>(entity =>
        {
            entity.HasKey(e => e.IdCuota).HasName("PK__Cuota__0899C148EC7BB1C7");

            entity.HasIndex(e => e.IdPrestamo, "IDX_Cuota_Prestamo");

            entity.HasIndex(e => new { e.IdPrestamo, e.NumeroCuota }, "UQ_Cuota").IsUnique();

            entity.Property(e => e.IdCuota).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.MontoCapital).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.MontoInteres).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdEstadoCuotaNavigation).WithMany(p => p.Cuota)
                .HasForeignKey(d => d.IdEstadoCuota)
                .HasConstraintName("FK__Cuota__IdEstadoC__76969D2E");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.Cuota)
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuota__IdPrestam__75A278F5");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433D61DF3DB7");

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamento).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreDepartamento).HasMaxLength(100);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Departame__IdPai__3D5E1FD2");
        });

        modelBuilder.Entity<Desembolso>(entity =>
        {
            entity.HasKey(e => e.IdDesembolso).HasName("PK__Desembol__33AB0DE8D6C4A527");

            entity.ToTable("Desembolso");

            entity.HasIndex(e => e.IdPrestamo, "UQ__Desembol__6FF194C1BAF3EF88").IsUnique();

            entity.Property(e => e.IdDesembolso).ValueGeneratedNever();
            entity.Property(e => e.FechaDesembolso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Metodo).HasMaxLength(50);
            entity.Property(e => e.Monto).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.NumeroReferencia).HasMaxLength(100);

            entity.HasOne(d => d.IdEstadoDesembolsoNavigation).WithMany(p => p.Desembolsos)
                .HasForeignKey(d => d.IdEstadoDesembolso)
                .HasConstraintName("FK__Desembols__IdEst__70DDC3D8");

            entity.HasOne(d => d.IdPrestamoNavigation).WithOne(p => p.Desembolso)
                .HasForeignKey<Desembolso>(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Desembols__IdPre__6FE99F9F");
        });

        modelBuilder.Entity<EstadoCuotum>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCuota).HasName("PK__EstadoCu__DE8B51960210CE5C");

            entity.Property(e => e.IdEstadoCuota).ValueGeneratedNever();
            entity.Property(e => e.NombreEstado).HasMaxLength(20);
        });

        modelBuilder.Entity<EstadoDesembolso>(entity =>
        {
            entity.HasKey(e => e.IdEstadoDesembolso).HasName("PK__EstadoDe__D1EBDECAF886A256");

            entity.ToTable("EstadoDesembolso");

            entity.Property(e => e.IdEstadoDesembolso).ValueGeneratedNever();
            entity.Property(e => e.NombreEstado).HasMaxLength(20);
        });

        modelBuilder.Entity<EstadoEvaluacion>(entity =>
        {
            entity.HasKey(e => e.IdEstadoEvaluacion).HasName("PK__EstadoEv__35FAD07F16279F56");

            entity.ToTable("EstadoEvaluacion");

            entity.Property(e => e.IdEstadoEvaluacion).ValueGeneratedNever();
            entity.Property(e => e.NombreEstado).HasMaxLength(20);
        });

        modelBuilder.Entity<EstadoPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPrestamo).HasName("PK__EstadoPr__BCB87549A2E1A3FA");

            entity.ToTable("EstadoPrestamo");

            entity.Property(e => e.IdEstadoPrestamo).ValueGeneratedNever();
            entity.Property(e => e.NombreEstado).HasMaxLength(20);
        });

        modelBuilder.Entity<Evaluacion>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion).HasName("PK__Evaluaci__A7EA657C9B8030DF");

            entity.ToTable("Evaluacion");

            entity.HasIndex(e => e.IdPrestamo, "UQ__Evaluaci__6FF194C11D3C3B68").IsUnique();

            entity.Property(e => e.IdEvaluacion).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CapacidadPago).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Egresos).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.FechaEvaluacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Ingresos).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdEstadoEvaluacionNavigation).WithMany(p => p.Evaluacions)
                .HasForeignKey(d => d.IdEstadoEvaluacion)
                .HasConstraintName("FK__Evaluacio__IdEst__6B24EA82");

            entity.HasOne(d => d.IdPrestamoNavigation).WithOne(p => p.Evaluacion)
                .HasForeignKey<Evaluacion>(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluacio__IdPre__6A30C649");
        });

        modelBuilder.Entity<Mora>(entity =>
        {
            entity.HasKey(e => e.IdMora).HasName("PK__Mora__33CEC5AB14814DC8");

            entity.ToTable("Mora");

            entity.HasIndex(e => e.IdCuota, "UQ__Mora__0899C14924AF8C68").IsUnique();

            entity.Property(e => e.IdMora).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.InteresCalculado).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdCuotaNavigation).WithOne(p => p.Mora)
                .HasForeignKey<Mora>(d => d.IdCuota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mora__IdCuota__02FC7413");

            entity.HasOne(d => d.IdMoraCatalogoNavigation).WithMany(p => p.Moras)
                .HasForeignKey(d => d.IdMoraCatalogo)
                .HasConstraintName("FK__Mora__IdMoraCata__03F0984C");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__61005978E15910B0");

            entity.ToTable("Municipio");

            entity.Property(e => e.IdMunicipio).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreMunicipio).HasMaxLength(100);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Municipio__IdDep__412EB0B6");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pago__FC851A3A0611B86B");

            entity.ToTable("Pago");

            entity.HasIndex(e => e.IdCuota, "IDX_Pago_Cuota");

            entity.Property(e => e.IdPago).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.MontoPagado).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.MoraPagada).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdCuotaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdCuota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pago__IdCuota__7B5B524B");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__Pais__FC850A7B38F4D188");

            entity.HasIndex(e => e.NombrePais, "UQ__Pais__BFA50269C7AA4C8E").IsUnique();

            entity.HasIndex(e => e.CodigoIso, "UQ__Pais__F2D69746A72E4C25").IsUnique();

            entity.Property(e => e.IdPais).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CodigoIso)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CodigoISO");
            entity.Property(e => e.NombrePais).HasMaxLength(100);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permiso__0D626EC8D56ACF1C");

            entity.ToTable("Permiso");

            entity.Property(e => e.IdPermiso).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombrePermiso).HasMaxLength(50);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__6FF194C07ACD19BB");

            entity.ToTable("Prestamo");

            entity.HasIndex(e => e.IdCliente, "IDX_Prestamo_Cliente");

            entity.Property(e => e.IdPrestamo).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Observacion).HasMaxLength(200);
            entity.Property(e => e.TasaInteres).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.CodMonedaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.CodMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamo__CodMon__6383C8BA");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamo__IdClie__619B8048");

            entity.HasOne(d => d.IdEstadoPrestamoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdEstadoPrestamo)
                .HasConstraintName("FK__Prestamo__IdEsta__6477ECF3");

            entity.HasOne(d => d.IdTipoPrestamoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdTipoPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamo__IdTipo__628FA481");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CDA8D96B0");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => new { e.IdRol, e.IdPermiso }).HasName("PK__Rol_Perm__BA9F7EA06C321A0A");

            entity.ToTable("Rol_Permiso");

            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rol_Permi__IdPer__0E6E26BF");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rol_Permi__IdRol__0D7A0286");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.IdTipoCliente).HasName("PK__TipoClie__F173C7FAD09AECAB");

            entity.ToTable("TipoCliente");

            entity.Property(e => e.IdTipoCliente).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoMonedum>(entity =>
        {
            entity.HasKey(e => e.CodMoneda).HasName("PK__TipoMone__AD8F699C980C5CCC");

            entity.Property(e => e.CodMoneda).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.NombreMoneda).HasMaxLength(50);
            entity.Property(e => e.Simbolo).HasMaxLength(10);
        });

        modelBuilder.Entity<TipoPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdTipoPrestamo).HasName("PK__TipoPres__31F48CEBA8EA4C91");

            entity.ToTable("TipoPrestamo");

            entity.Property(e => e.IdTipoPrestamo).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.MontoMaximo).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.TasaBase).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97C36CFED0");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuario__6B0F5AE05A277E31").IsUnique();

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdRol__1332DBDC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
