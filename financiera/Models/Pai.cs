using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Pai
{
    public int IdPais { get; set; }

    public string NombrePais { get; set; } = null!;

    public string CodigoIso { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
