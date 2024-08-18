using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Inspeccione
{
    public int PkInspeccion { get; set; }

    public int? FkServicio { get; set; }

    public int? FkEmpresas { get; set; }

    public int? FkTipoInspecciones { get; set; }

    public DateOnly? FechaInspeccion { get; set; }

    public string? Descripcion { get; set; }

    public virtual Empresa? FkEmpresasNavigation { get; set; }

    public virtual Servicio? FkServicioNavigation { get; set; }

    public virtual TipoInspeccion? FkTipoInspeccionesNavigation { get; set; }
}
