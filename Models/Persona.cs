using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Persona
{
    public int PkPersonas { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? NroDocumento { get; set; }

    public int? FkTipoDocumentoIdentidad { get; set; }

    public virtual TipoDocumentoIdentidad? FkTipoDocumentoIdentidadNavigation { get; set; }

    public virtual ICollection<ParticipantesCurso> ParticipantesCursos { get; set; } = new List<ParticipantesCurso>();
}
