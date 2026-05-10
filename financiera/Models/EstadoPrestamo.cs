using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class EstadoPrestamo
{
    public int IdEstadoPrestamo { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
