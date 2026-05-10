using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Evaluacion
{
    public int IdEvaluacion { get; set; }

    public int IdPrestamo { get; set; }

    public decimal? Ingresos { get; set; }

    public decimal? Egresos { get; set; }

    public decimal? CapacidadPago { get; set; }

    public int? ScoreCrediticio { get; set; }

    public int? IdEstadoEvaluacion { get; set; }

    public DateTime? FechaEvaluacion { get; set; }

    public bool? Activo { get; set; }

    public virtual EstadoEvaluacion? IdEstadoEvaluacionNavigation { get; set; }

    public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;
}
