using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MauiApp2.Modelos;

public class Contacto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? CorreoElectronico { get; set; }
    public bool Activo { get; set; }
}