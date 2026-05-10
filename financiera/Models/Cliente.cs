using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace financiera.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdTipoCliente { get; set; }

    [Required(ErrorMessage = "La cédula es obligatoria")]
    [RegularExpression(@"^\d{3}-\d{6}-\d{4}[A-Z]$",
    ErrorMessage = "Formato inválido. Ejemplo: 001-123456-0001A")]
    public string Cedula { get; set; } = null!;
     
    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? RazonSocial { get; set; }

    public int? IdDepartamento { get; set; }

    public string? Direccion { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [RegularExpression(@"^[2-8]\d{7}$",
    ErrorMessage = "Ingrese un teléfono válido de 8 dígitos")]
    public string Telefono { get; set; } = null!;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
    public string Correo { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual TipoCliente? IdTipoClienteNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
