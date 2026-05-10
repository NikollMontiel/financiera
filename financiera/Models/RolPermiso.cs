using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class RolPermiso
{
    public int IdRol { get; set; }

    public int IdPermiso { get; set; }

    public bool? Activo { get; set; }

    public virtual Permiso IdPermisoNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
