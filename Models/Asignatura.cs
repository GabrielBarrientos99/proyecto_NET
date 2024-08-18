using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Asignatura
{
    public int PkAsignatura { get; set; }

    public string? Nombre { get; set; }

    public string? HorasTeoria { get; set; }

    public string? HoraPractica { get; set; }
}
