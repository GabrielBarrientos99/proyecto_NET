using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Inspeccione
{
    public int PkInspeccion { get; set; }

    public int? FkTipoDeServicio { get; set; }

    public int? FkEmpresas { get; set; }

    public int? FkTipoInspecciones { get; set; }

    public DateOnly? FechaInspeccion { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public string? Descripcion { get; set; }

    public string? Ubicacion { get; set; }

    public virtual Empresa? FkEmpresasNavigation { get; set; }

    public virtual TiposServicio? FkTipoDeServicioNavigation { get; set; }

    public virtual TipoInspeccion? FkTipoInspeccionesNavigation { get; set; }
}
