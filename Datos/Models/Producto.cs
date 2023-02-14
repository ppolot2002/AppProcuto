using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Producto
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int? Status { get; set; }

    public int? Stock { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

}
