using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenPracticoPauloRomero.Models
{
    public class Promocion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Restricciones { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int ComercioId { get; set; }
    }
}