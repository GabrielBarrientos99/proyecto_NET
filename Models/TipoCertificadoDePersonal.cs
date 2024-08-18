using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class TipoCertificadoDePersonal
{
    public int PkTipoCertificadoDePersonal { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CertificadosDePersonal> CertificadosDePersonals { get; set; } = new List<CertificadosDePersonal>();

    public virtual ICollection<TipoInspeccion> TipoInspeccions { get; set; } = new List<TipoInspeccion>();
}
