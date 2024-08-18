using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class TipoDocumentoIdentidad
{
    public int PkTipoDocumentoIdentidad { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
