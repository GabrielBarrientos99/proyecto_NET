using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class CertificadoCurso
{
    public int PkCertificadoCurso { get; set; }

    public int? FkServicio { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public DateOnly? FechaCaducidad { get; set; }

    public virtual Servicio? FkServicioNavigation { get; set; }
}
