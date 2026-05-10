using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class CambioMonedum
{
    public int IdCambioMoneda { get; set; }

    public int CodMoneda { get; set; }

    public decimal? TasaCambio { get; set; }

    public DateTime? FechaCambio { get; set; }

    public bool? Activo { get; set; }

    public virtual TipoMonedum CodMonedaNavigation { get; set; } = null!;
}
