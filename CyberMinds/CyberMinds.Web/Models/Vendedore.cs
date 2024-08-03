using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CyberMinds.Web.Models;

public partial class Vendedore
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public int? SucursalId { get; set; }

    public virtual Sucursale? Sucursal { get; set; }
}
