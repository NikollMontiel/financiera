using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class CatalogoMora
{
    public int IdMoraCatalogo { get; set; }

    public int? DiasMin { get; set; }

    public int? DiasMax { get; set; }

    public decimal? PorcentajeInteres { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Mora> Moras { get; set; } = new List<Mora>();
}
