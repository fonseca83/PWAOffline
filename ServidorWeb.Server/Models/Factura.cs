using System;
using System.Collections.Generic;

namespace ServidorWeb.Server.Models;

public partial class Factura
{
    public int Id { get; set; }

    public string Cliente { get; set; } = null!;

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }
}
