using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Servicio
{
    public int PkServicio { get; set; }

    public int? FkTipoServicio { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<AsignacionInspectore> AsignacionInspectores { get; set; } = new List<AsignacionInspectore>();

    public virtual ICollection<AsignacionProfesore> AsignacionProfesores { get; set; } = new List<AsignacionProfesore>();

    public virtual ICollection<CertificadoCurso> CertificadoCursos { get; set; } = new List<CertificadoCurso>();

    public virtual ICollection<CertificadoInspeccion> CertificadoInspeccions { get; set; } = new List<CertificadoInspeccion>();

    public virtual ICollection<CertificadorAsignado> CertificadorAsignados { get; set; } = new List<CertificadorAsignado>();

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual TiposServicio? FkTipoServicioNavigation { get; set; }

    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
}
