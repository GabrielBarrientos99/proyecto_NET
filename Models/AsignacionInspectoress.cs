using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class AsignacionInspectoress
{
    public int PkAsignacionId { get; set; }

    public int? FkInspectoresDisponibles { get; set; }

    public virtual InspectoresDisponible? FkInspectoresDisponiblesNavigation { get; set; }
}
