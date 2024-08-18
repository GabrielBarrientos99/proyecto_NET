using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class ParticipantesCurso
{
    public int PkParticipantesCursos { get; set; }

    public int? FkCurso { get; set; }

    public int? FkPersonas { get; set; }

    public virtual Curso? FkCursoNavigation { get; set; }

    public virtual Persona? FkPersonasNavigation { get; set; }
}
