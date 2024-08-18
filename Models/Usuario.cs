using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Usuario
{
    public int PkUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contraseña { get; set; }

    public int? FkRol { get; set; }

    public virtual ICollection<CertificadorAsignado> CertificadorAsignados { get; set; } = new List<CertificadorAsignado>();

    public virtual ICollection<CertificadoresDisponible> CertificadoresDisponibles { get; set; } = new List<CertificadoresDisponible>();

    public virtual ICollection<CertificadosDePersonal> CertificadosDePersonals { get; set; } = new List<CertificadosDePersonal>();

    public virtual Rol? FkRolNavigation { get; set; }

    public virtual ICollection<InspectoresDisponible> InspectoresDisponibles { get; set; } = new List<InspectoresDisponible>();

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
