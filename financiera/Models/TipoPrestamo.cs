using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class TipoPrestamo
{
    public int IdTipoPrestamo { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? TasaBase { get; set; }

    public int? PlazoMaximo { get; set; }

    public decimal? MontoMaximo { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
