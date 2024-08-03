using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CyberMinds.Web.Models;

public partial class Sucursale
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<Vendedore> Vendedores { get; set; } = new List<Vendedore>();
}
