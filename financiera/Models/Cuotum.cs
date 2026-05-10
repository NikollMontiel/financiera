using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Cuotum
{
    public int IdCuota { get; set; }

    public int IdPrestamo { get; set; }

    public int NumeroCuota { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public decimal? MontoCapital { get; set; }

    public decimal? MontoInteres { get; set; }

    public decimal? MontoTotal { get; set; }

    public int? IdEstadoCuota { get; set; }

    public bool? Activo { get; set; }

    public virtual EstadoCuotum? IdEstadoCuotaNavigation { get; set; }

    public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;

    public virtual Mora? Mora { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
