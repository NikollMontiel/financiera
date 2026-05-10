using System;
using System.Collections.Generic;

namespace financiera.Models;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public int IdDepartamento { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public bool? Activo { get; set; }


    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
}
