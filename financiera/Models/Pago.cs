using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdCuota { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal? MontoPagado { get; set; }

    public decimal? MoraPagada { get; set; }

    public string? MetodoPago { get; set; }

    public bool? Activo { get; set; }

    public virtual Cuotum IdCuotaNavigation { get; set; } = null!;
}
