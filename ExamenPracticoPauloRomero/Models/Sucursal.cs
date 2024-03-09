using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenPracticoPauloRomero.Models
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CP { get; set; }
        public int ComercioId { get; set; }
    }
}