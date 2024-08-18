using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class TiposServicio
{
    public int PkTiposServicio { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
