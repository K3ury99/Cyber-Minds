using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CyberMinds.Web.Models;

public partial class Cliente
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }
}
