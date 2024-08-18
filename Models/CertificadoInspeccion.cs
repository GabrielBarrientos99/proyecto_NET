using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class CertificadoInspeccion
{
    public int PkCertificadoInspeccion { get; set; }

    public int? FkServicio { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public DateOnly? FechaCaducidad { get; set; }

    public virtual Servicio? FkServicioNavigation { get; set; }
}
