using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class AsignacionProfesore
{
    public int PkAsignacionProfesores { get; set; }

    public int? FkServicio { get; set; }

    public int? FkPersonal { get; set; }

    public virtual Personal? FkPersonalNavigation { get; set; }

    public virtual Servicio? FkServicioNavigation { get; set; }
}
