using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class EstadoEvaluacion
{
    public int IdEstadoEvaluacion { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Evaluacion> Evaluacions { get; set; } = new List<Evaluacion>();
}
