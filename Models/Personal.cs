﻿using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Personal
{
    public int PkPersonal { get; set; }

    public int? FkUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Dni { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<AsignacionProfesore> AsignacionProfesores { get; set; } = new List<AsignacionProfesore>();

    public virtual Usuario? FkUsuarioNavigation { get; set; }
}
