using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccess.Models;

[Table("EMPLEADO")]
public partial class Empleado
{
    [Key]
    public int IdEmpleado { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(80)]
    public string Correo { get; set; } = null!;

    [StringLength(120)]
    public string Direccion { get; set; } = null!;

    [StringLength(40)]
    public string? Telefono { get; set; }
}
