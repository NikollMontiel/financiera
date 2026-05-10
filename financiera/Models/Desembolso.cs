using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Desembolso
{
    public int IdDesembolso { get; set; }

    public int IdPrestamo { get; set; }

    public DateTime? FechaDesembolso { get; set; }

    public decimal? Monto { get; set; }

    public string? Metodo { get; set; }

    public string? NumeroReferencia { get; set; }

    public int? IdEstadoDesembolso { get; set; }

    public virtual EstadoDesembolso? IdEstadoDesembolsoNavigation { get; set; }

    public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;
}
