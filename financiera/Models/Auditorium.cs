using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Auditorium
{
    public int IdAuditoria { get; set; }

    public int? IdUsuario { get; set; }

    public string? TablaAfectada { get; set; }

    public string? Accion { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
