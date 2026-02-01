using System;
using System.Collections.Generic;

namespace DemoApi.Infrastructure;

public partial class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public bool ClienteActivo { get; set; } = true;
}
