using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class InspectoresDisponible
{
    public int PkInspectoresDisponibles { get; set; }

    public int? FkUsuario { get; set; }

    public int? FkTipoInspeccion { get; set; }

    public DateOnly? FechaEmisionCertificado { get; set; }

    public DateOnly? FechaVencimientoCertificado { get; set; }

    public byte[]? CertificadoPdf { get; set; }

    public byte[]? FirmaYselloDigital { get; set; }

    public virtual ICollection<AsignacionInspectoress> AsignacionInspectoresses { get; set; } = new List<AsignacionInspectoress>();

    public virtual TipoInspeccion? FkTipoInspeccionNavigation { get; set; }

    public virtual Usuario? FkUsuarioNavigation { get; set; }
}
