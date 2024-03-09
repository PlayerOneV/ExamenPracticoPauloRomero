using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenPracticoPauloRomero.Models
{
    public class Comercio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Giro { get; set; }
        public string Web { get; set; }
        public string Facebook { get; set; }
        public List<Promocion> Promociones { get; set; } = null;
        public List<Sucursal> Sucursales { get; set; } = null;
    }
}