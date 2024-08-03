using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CyberMinds.Web.Models;

public partial class Producto
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }
}
