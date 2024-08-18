using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class CertificadosDePersonal
{
    public int PkCertificadosDePersonal { get; set; }

    public int? FkUsuario { get; set; }

    public int? FkTipoCertificadoDePersonal { get; set; }

    public string? Especializacion { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public byte[]? CertificadoPdf { get; set; }

    public virtual TipoCertificadoDePersonal? FkTipoCertificadoDePersonalNavigation { get; set; }

    public virtual Usuario? FkUsuarioNavigation { get; set; }
}
