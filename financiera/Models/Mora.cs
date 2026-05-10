using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Mora
{
    public int IdMora { get; set; }

    public int IdCuota { get; set; }

    public int? DiasMora { get; set; }

    public decimal? InteresCalculado { get; set; }

    public int? IdMoraCatalogo { get; set; }

    public bool? Activo { get; set; }

    public virtual Cuotum IdCuotaNavigation { get; set; } = null!;

    public virtual CatalogoMora? IdMoraCatalogoNavigation { get; set; }
}
