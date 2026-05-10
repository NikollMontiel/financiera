using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public int IdPais { get; set; }

    public string NombreDepartamento { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual Pai IdPaisNavigation { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();

    public virtual ICollection<Cliente> Clientes { get; set; }
    = new List<Cliente>();
}
