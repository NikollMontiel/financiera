using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class TipoMonedum
{
    public int CodMoneda { get; set; }

    public string NombreMoneda { get; set; } = null!;

    public string? Simbolo { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<CambioMonedum> CambioMoneda { get; set; } = new List<CambioMonedum>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
