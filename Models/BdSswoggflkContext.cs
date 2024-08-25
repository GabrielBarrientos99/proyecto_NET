using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PROYECTO_FLK.Models;

public partial class BdSswoggflkContext : DbContext
{
    public BdSswoggflkContext()
    {
    }

    public BdSswoggflkContext(DbContextOptions<BdSswoggflkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionInspectoress> AsignacionInspectoresses { get; set; }

    public virtual DbSet<AsignacionProfesore> AsignacionProfesores { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<CertificadoCurso> CertificadoCursos { get; set; }

    public virtual DbSet<CertificadoInspeccion> CertificadoInspeccions { get; set; }

    public virtual DbSet<CertificadorAsignado> CertificadorAsignados { get; set; }

    public virtual DbSet<CertificadoresDisponible> CertificadoresDisponibles { get; set; }

    public virtual DbSet<CertificadosDePersonal> CertificadosDePersonals { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Inspeccione> Inspecciones { get; set; }

    public virtual DbSet<InspectoresDisponible> InspectoresDisponibles { get; set; }

    public virtual DbSet<ParticipantesCurso> ParticipantesCursos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoCertificadoDePersonal> TipoCertificadoDePersonals { get; set; }

    public virtual DbSet<TipoDeVehiculo> TipoDeVehiculos { get; set; }

    public virtual DbSet<TipoDocumentoIdentidad> TipoDocumentoIdentidads { get; set; }

    public virtual DbSet<TipoInspeccion> TipoInspeccions { get; set; }

    public virtual DbSet<TiposServicio> TiposServicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-JV065NN\\SQLEXPRESS;Database=BD_SSWOGGFLK;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionInspectoress>(entity =>
        {
            entity.HasKey(e => e.PkAsignacionId).HasName("PK__Asignaci__05D5AD78E72A3BBC");

            entity.ToTable("AsignacionInspectoress");

            entity.Property(e => e.PkAsignacionId).HasColumnName("PK_AsignacionID");
            entity.Property(e => e.FkInspectoresDisponibles).HasColumnName("FK_InspectoresDisponibles");

            entity.HasOne(d => d.FkInspectoresDisponiblesNavigation).WithMany(p => p.AsignacionInspectoresses)
                .HasForeignKey(d => d.FkInspectoresDisponibles)
                .HasConstraintName("FK_AsignacionInspectores_InspectoresDisponibles");
        });

        modelBuilder.Entity<AsignacionProfesore>(entity =>
        {
            entity.HasKey(e => e.PkAsignacionProfesores).HasName("PK__Asignaci__EFEED6625CF03CDE");

            entity.Property(e => e.PkAsignacionProfesores)
                .ValueGeneratedNever()
                .HasColumnName("PK_AsignacionProfesores");
            entity.Property(e => e.FkPersonal).HasColumnName("FK_Personal");
            entity.Property(e => e.FkServicio).HasColumnName("FK_Servicio");

            entity.HasOne(d => d.FkPersonalNavigation).WithMany(p => p.AsignacionProfesores)
                .HasForeignKey(d => d.FkPersonal)
                .HasConstraintName("FK__Asignacio__FK_Pe__3E1D39E1");

            entity.HasOne(d => d.FkServicioNavigation).WithMany(p => p.AsignacionProfesores)
                .HasForeignKey(d => d.FkServicio)
                .HasConstraintName("FK__Asignacio__FK_Se__3D2915A8");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.PkAsignatura).HasName("PK__Asignatu__41C0F21545DF7D86");

            entity.ToTable("Asignatura");

            entity.Property(e => e.PkAsignatura).HasColumnName("PK_Asignatura");
            entity.Property(e => e.HoraPractica)
                .HasMaxLength(20)
                .HasColumnName("Hora_Practica");
            entity.Property(e => e.HorasTeoria)
                .HasMaxLength(20)
                .HasColumnName("Horas_Teoria");
            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<CertificadoCurso>(entity =>
        {
            entity.HasKey(e => e.PkCertificadoCurso).HasName("PK__Certific__6292FEB021289F57");

            entity.ToTable("CertificadoCurso");

            entity.Property(e => e.PkCertificadoCurso)
                .ValueGeneratedNever()
                .HasColumnName("PK_CertificadoCurso");
            entity.Property(e => e.FkServicio).HasColumnName("FK_Servicio");

            entity.HasOne(d => d.FkServicioNavigation).WithMany(p => p.CertificadoCursos)
                .HasForeignKey(d => d.FkServicio)
                .HasConstraintName("FK__Certifica__FK_Se__114A936A");
        });

        modelBuilder.Entity<CertificadoInspeccion>(entity =>
        {
            entity.HasKey(e => e.PkCertificadoInspeccion).HasName("PK__Certific__29F54AEEE17E6954");

            entity.ToTable("CertificadoInspeccion");

            entity.Property(e => e.PkCertificadoInspeccion)
                .ValueGeneratedNever()
                .HasColumnName("PK_CertificadoInspeccion");
            entity.Property(e => e.FkServicio).HasColumnName("FK_Servicio");

            entity.HasOne(d => d.FkServicioNavigation).WithMany(p => p.CertificadoInspeccions)
                .HasForeignKey(d => d.FkServicio)
                .HasConstraintName("FK__Certifica__FK_Se__0E6E26BF");
        });

        modelBuilder.Entity<CertificadorAsignado>(entity =>
        {
            entity.HasKey(e => e.PkAsignacionId).HasName("PK__Certific__05D5AD7838C7A536");

            entity.ToTable("CertificadorAsignado");

            entity.Property(e => e.PkAsignacionId)
                .ValueGeneratedNever()
                .HasColumnName("PK_AsignacionID");
            entity.Property(e => e.FkServicio).HasColumnName("FK_Servicio");
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

            entity.HasOne(d => d.FkServicioNavigation).WithMany(p => p.CertificadorAsignados)
                .HasForeignKey(d => d.FkServicio)
                .HasConstraintName("FK__Certifica__FK_Se__70DDC3D8");

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.CertificadorAsignados)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK__Certifica__FK_Us__71D1E811");
        });

        modelBuilder.Entity<CertificadoresDisponible>(entity =>
        {
            entity.HasKey(e => e.PkCertificadoresDisponibles).HasName("PK__Certific__05FE5811D1BA45BA");

            entity.Property(e => e.PkCertificadoresDisponibles).HasColumnName("PK_CertificadoresDisponibles");
            entity.Property(e => e.CertificadoPdf).HasColumnName("CertificadoPDF");
            entity.Property(e => e.FirmaYselloDigital).HasColumnName("FirmaYSelloDigital");
            entity.Property(e => e.FkTipoInspeccion).HasColumnName("FK_Tipo_Inspeccion");
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

            entity.HasOne(d => d.FkTipoInspeccionNavigation).WithMany(p => p.CertificadoresDisponibles)
                .HasForeignKey(d => d.FkTipoInspeccion)
                .HasConstraintName("FK_CertificadoresDisponibles_TipoInspeccion");

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.CertificadoresDisponibles)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK_CertificadoresDisponibles_Usuario");
        });

        modelBuilder.Entity<CertificadosDePersonal>(entity =>
        {
            entity.HasKey(e => e.PkCertificadosDePersonal).HasName("PK__Certific__FC3FB7C4C6DDF191");

            entity.ToTable("CertificadosDePersonal");

            entity.Property(e => e.PkCertificadosDePersonal)
                .ValueGeneratedNever()
                .HasColumnName("PK_Certificados_de_Personal");
            entity.Property(e => e.CertificadoPdf).HasColumnName("CertificadoPDF");
            entity.Property(e => e.Especializacion).HasMaxLength(100);
            entity.Property(e => e.FkTipoCertificadoDePersonal).HasColumnName("FK_Tipo_Certificado_de_Personal");
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

            entity.HasOne(d => d.FkTipoCertificadoDePersonalNavigation).WithMany(p => p.CertificadosDePersonals)
                .HasForeignKey(d => d.FkTipoCertificadoDePersonal)
                .HasConstraintName("FK__Certifica__FK_Ti__1CBC4616");

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.CertificadosDePersonals)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK__Certifica__FK_Us__1BC821DD");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.PkCurso).HasName("PK__Cursos__D76122BE0304D8DE");

            entity.Property(e => e.PkCurso)
                .ValueGeneratedNever()
                .HasColumnName("PK_Curso");
            entity.Property(e => e.FkServicio).HasColumnName("FK_Servicio");

            entity.HasOne(d => d.FkServicioNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.FkServicio)
                .HasConstraintName("FK__Cursos__FK_Servi__02FC7413");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.PkEmpresas).HasName("PK__Empresas__1A32D73AE287B7B1");

            entity.Property(e => e.PkEmpresas)
                .ValueGeneratedNever()
                .HasColumnName("PK_Empresas");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RazonSocial).HasMaxLength(100);
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .HasColumnName("RUC");
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Inspeccione>(entity =>
        {
            entity.HasKey(e => e.PkInspeccion).HasName("PK__Inspecci__9B00EA3ACF3E8277");

            entity.Property(e => e.PkInspeccion).HasColumnName("PK_Inspeccion");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FkEmpresas).HasColumnName("FK_Empresas");
            entity.Property(e => e.FkTipoDeServicio).HasColumnName("FK_Tipo_de_Servicio");
            entity.Property(e => e.FkTipoInspecciones).HasColumnName("FK_Tipo_Inspecciones");
            entity.Property(e => e.Ubicacion).HasMaxLength(200);

            entity.HasOne(d => d.FkEmpresasNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkEmpresas)
                .HasConstraintName("FK_Inspecciones_Empresas");

            entity.HasOne(d => d.FkTipoDeServicioNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkTipoDeServicio)
                .HasConstraintName("FK_Inspecciones_TiposServicio");

            entity.HasOne(d => d.FkTipoInspeccionesNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkTipoInspecciones)
                .HasConstraintName("FK_Inspecciones_TipoInspeccion");
        });

        modelBuilder.Entity<InspectoresDisponible>(entity =>
        {
            entity.HasKey(e => e.PkInspectoresDisponibles).HasName("PK__Inspecto__CA7A3A1B14A0EED9");

            entity.Property(e => e.PkInspectoresDisponibles).HasColumnName("PK_InspectoresDisponibles");
            entity.Property(e => e.CertificadoPdf).HasColumnName("CertificadoPDF");
            entity.Property(e => e.FirmaYselloDigital).HasColumnName("FirmaYSelloDigital");
            entity.Property(e => e.FkTipoInspeccion).HasColumnName("FK_Tipo_Inspeccion");
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

            entity.HasOne(d => d.FkTipoInspeccionNavigation).WithMany(p => p.InspectoresDisponibles)
                .HasForeignKey(d => d.FkTipoInspeccion)
                .HasConstraintName("FK_InspectoresDisponibles_TipoInspeccion");

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.InspectoresDisponibles)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK_InspectoresDisponibles_Usuario");
        });

        modelBuilder.Entity<ParticipantesCurso>(entity =>
        {
            entity.HasKey(e => e.PkParticipantesCursos).HasName("PK__Particip__D770F8AF797D881A");

            entity.Property(e => e.PkParticipantesCursos)
                .ValueGeneratedNever()
                .HasColumnName("PK_ParticipantesCursos");
            entity.Property(e => e.FkCurso).HasColumnName("FK_Curso");
            entity.Property(e => e.FkPersonas).HasColumnName("FK_Personas");

            entity.HasOne(d => d.FkCursoNavigation).WithMany(p => p.ParticipantesCursos)
                .HasForeignKey(d => d.FkCurso)
                .HasConstraintName("FK__Participa__FK_Cu__08B54D69");

            entity.HasOne(d => d.FkPersonasNavigation).WithMany(p => p.ParticipantesCursos)
                .HasForeignKey(d => d.FkPersonas)
                .HasConstraintName("FK__Participa__FK_Pe__09A971A2");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.PkPersonas).HasName("PK__Personas__1EA7C93E23177C64");

            entity.Property(e => e.PkPersonas)
                .ValueGeneratedNever()
                .HasColumnName("PK_Personas");
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.FkTipoDocumentoIdentidad).HasColumnName("FK_Tipo_Documento_Identidad");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.NroDocumento)
                .HasMaxLength(50)
                .HasColumnName("Nro_Documento");

            entity.HasOne(d => d.FkTipoDocumentoIdentidadNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.FkTipoDocumentoIdentidad)
                .HasConstraintName("FK__Personas__FK_Tip__05D8E0BE");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.PkPersonal).HasName("PK__Personal__1EA7C9C7318B23D2");

            entity.ToTable("Personal");

            entity.Property(e => e.PkPersonal)
                .ValueGeneratedNever()
                .HasColumnName("PK_Personal");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("DNI");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK__Personal__Telefo__367C1819");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.PkRol).HasName("PK__Rol__15CAC9867EDCB6CD");

            entity.ToTable("Rol");

            entity.Property(e => e.PkRol)
                .ValueGeneratedNever()
                .HasColumnName("PK_Rol");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.PkServicio).HasName("PK__Servicio__4037BCBE1229E410");

            entity.Property(e => e.PkServicio)
                .ValueGeneratedNever()
                .HasColumnName("PK_Servicio");
            entity.Property(e => e.FkTipoServicio).HasColumnName("FK_TipoServicio");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.FkTipoServicioNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.FkTipoServicio)
                .HasConstraintName("FK__Servicios__FK_Ti__6E01572D");
        });

        modelBuilder.Entity<TipoCertificadoDePersonal>(entity =>
        {
            entity.HasKey(e => e.PkTipoCertificadoDePersonal).HasName("PK__Tipo_Cer__ED70B4A497DE2166");

            entity.ToTable("Tipo_Certificado_de_Personal");

            entity.Property(e => e.PkTipoCertificadoDePersonal)
                .ValueGeneratedNever()
                .HasColumnName("PK_Tipo_Certificado_de_Personal");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Titulo).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoDeVehiculo>(entity =>
        {
            entity.HasKey(e => e.PkTipoDeVehiculos).HasName("PK__Tipo_de___436ED725F7D77BB8");

            entity.ToTable("Tipo_de_Vehiculos");

            entity.Property(e => e.PkTipoDeVehiculos).HasColumnName("PK_tipo_de_vehiculos");
            entity.Property(e => e.CapacidadCarga).HasColumnName("capacidad_carga");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.TipoDeVehiculo1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Tipo_de_Vehiculo");
        });

        modelBuilder.Entity<TipoDocumentoIdentidad>(entity =>
        {
            entity.HasKey(e => e.PkTipoDocumentoIdentidad).HasName("PK__TipoDocu__13E624EBB92F4631");

            entity.ToTable("TipoDocumentoIdentidad");

            entity.Property(e => e.PkTipoDocumentoIdentidad)
                .ValueGeneratedNever()
                .HasColumnName("PK_Tipo_Documento_Identidad");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoInspeccion>(entity =>
        {
            entity.HasKey(e => e.PkTipoInspeccion).HasName("PK__TipoInsp__389FF9C84C7284E9");

            entity.ToTable("TipoInspeccion");

            entity.Property(e => e.PkTipoInspeccion)
                .ValueGeneratedNever()
                .HasColumnName("PK_Tipo_Inspeccion");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FkTipoCertificadoDePersonal).HasColumnName("FK_Tipo_Certificado_de_Personal");
            entity.Property(e => e.Titulo).HasMaxLength(50);

            entity.HasOne(d => d.FkTipoCertificadoDePersonalNavigation).WithMany(p => p.TipoInspeccions)
                .HasForeignKey(d => d.FkTipoCertificadoDePersonal)
                .HasConstraintName("FK__TipoInspe__FK_Ti__00200768");
        });

        modelBuilder.Entity<TiposServicio>(entity =>
        {
            entity.HasKey(e => e.PkTiposServicio).HasName("PK__TiposSer__18DBF56EC32D9A34");

            entity.ToTable("TiposServicio");

            entity.Property(e => e.PkTiposServicio)
                .ValueGeneratedNever()
                .HasColumnName("PK_TiposServicio");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.PkUsuario).HasName("PK__Usuario__7D08CC9CB33941FD");

            entity.ToTable("Usuario");

            entity.Property(e => e.PkUsuario).HasColumnName("PK_Usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .HasColumnName("contraseña");
            entity.Property(e => e.FkRol).HasColumnName("FK_Rol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("Nombre_usuario");

            entity.HasOne(d => d.FkRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkRol)
                .HasConstraintName("FK__Usuario__FK_Rol__59063A47");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.PkVehiculo).HasName("PK__Vehiculo__0032D334AA00781C");

            entity.Property(e => e.PkVehiculo).HasColumnName("PK_Vehiculo");
            entity.Property(e => e.Fabricante)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FkEmpresas).HasColumnName("FK_Empresas");
            entity.Property(e => e.FkTipoDeVehiculos).HasColumnName("FK_tipo_de_vehiculos");
            entity.Property(e => e.Marca)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSerie)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Numero_Serie");

            entity.HasOne(d => d.FkEmpresasNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.FkEmpresas)
                .HasConstraintName("FK_Vehiculos_Empresas");

            entity.HasOne(d => d.FkTipoDeVehiculosNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.FkTipoDeVehiculos)
                .HasConstraintName("FK_Vehiculos_TipoDeVehiculos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
