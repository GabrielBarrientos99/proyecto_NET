using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Usuario
{
    public int PkUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contraseña { get; set; }

    public int? FkRol { get; set; }

    public virtual ICollection<AsignacionInspectore> AsignacionInspectores { get; set; } = new List<AsignacionInspectore>();

    public virtual ICollection<AsignacionProfesore> AsignacionProfesores { get; set; } = new List<AsignacionProfesore>();

    public virtual ICollection<CertificadorAsignado> CertificadorAsignados { get; set; } = new List<CertificadorAsignado>();

    public virtual ICollection<CertificadosDePersonal> CertificadosDePersonals { get; set; } = new List<CertificadosDePersonal>();

    public virtual Rol? FkRolNavigation { get; set; }

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
