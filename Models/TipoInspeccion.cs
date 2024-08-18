using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class TipoInspeccion
{
    public int PkTipoInspeccion { get; set; }

    public int? FkTipoCertificadoDePersonal { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public virtual TipoCertificadoDePersonal? FkTipoCertificadoDePersonalNavigation { get; set; }

    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
}
