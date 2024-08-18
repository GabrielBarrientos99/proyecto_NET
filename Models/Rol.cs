using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Rol
{
    public int PkRol { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
