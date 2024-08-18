using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Curso
{
    public int PkCurso { get; set; }

    public int? FkServicio { get; set; }

    public int? HorasTeoria { get; set; }

    public int? HorasPractica { get; set; }

    public virtual Servicio? FkServicioNavigation { get; set; }

    public virtual ICollection<ParticipantesCurso> ParticipantesCursos { get; set; } = new List<ParticipantesCurso>();
}
