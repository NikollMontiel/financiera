using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class TipoCliente
{
    public int IdTipoCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
