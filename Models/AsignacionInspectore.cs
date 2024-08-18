using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class AsignacionInspectore
{
    public int PkAsignacionId { get; set; }

    public int? FkServicio { get; set; }

    public int? FkUsuario { get; set; }

    public virtual Servicio? FkServicioNavigation { get; set; }

    public virtual Usuario? FkUsuarioNavigation { get; set; }
}
