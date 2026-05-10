using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int IdCliente { get; set; }

    public int IdTipoPrestamo { get; set; }

    public int CodMoneda { get; set; }

    public decimal Monto { get; set; }

    public decimal TasaInteres { get; set; }

    public int PlazoMeses { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public int? IdEstadoPrestamo { get; set; }

    public string? Observacion { get; set; }

    public bool? Activo { get; set; }

    public virtual TipoMonedum CodMonedaNavigation { get; set; } = null!;

    public virtual ICollection<Cuotum> Cuota { get; set; } = new List<Cuotum>();

    public virtual Desembolso? Desembolso { get; set; }

    public virtual Evaluacion? Evaluacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual EstadoPrestamo? IdEstadoPrestamoNavigation { get; set; }

    public virtual TipoPrestamo IdTipoPrestamoNavigation { get; set; } = null!;
}
