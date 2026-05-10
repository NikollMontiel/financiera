using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class EstadoDesembolso
{
    public int IdEstadoDesembolso { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Desembolso> Desembolsos { get; set; } = new List<Desembolso>();
}
