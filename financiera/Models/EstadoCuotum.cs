using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class EstadoCuotum
{
    public int IdEstadoCuota { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Cuotum> Cuota { get; set; } = new List<Cuotum>();
}
