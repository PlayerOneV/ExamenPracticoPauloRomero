using ExamenPracticoPauloRomero.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamenPracticoPauloRomero.Controllers
{
    public class ComerciosController : ApiController
    {

        private string connectionString = "Data Source=PLAYERONE;Initial Catalog=ExamenPractico;Integrated Security=True";

        [HttpGet]
        public IEnumerable<Comercio> Get()
        {
            List<Comercio> comercios = new List<Comercio>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT c.*, p.*, s.* FROM Comercios as c LEFT JOIN PROMOCIONES as p ON c.Id = p.ComercioId LEFT JOIN Sucursales as s ON c.Id = s.ComercioId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Comercio comercio = new Comercio();
                            comercio.Id = reader.GetInt32(0);
                            comercio.Nombre = reader.GetString(1);
                            comercio.Giro = reader.GetString(2);
                            comercio.Web = reader.GetString(3);
                            comercio.Facebook = reader.GetString(4);
                            comercio.Promociones = new List<Promocion>();
                            comercio.Sucursales = new List<Sucursal>();
                            
                            if (!reader.IsDBNull(5))
                            {
                                Promocion promocion = new Promocion();
                                promocion.Id = reader.GetInt32(5);
                                promocion.Descripcion = reader.GetString(6);
                                promocion.Restricciones = reader.GetString(7);
                                promocion.FechaInicio = reader.GetString(8);
                                promocion.FechaFin = reader.GetString(9);
                                comercio.Promociones.Add(promocion);
                            
                                }
/*                            if (!reader.IsDBNull(10))
                            {
                                Sucursal sucursal = new Sucursal();
                                sucursal.Id = reader.GetInt32(10);
                                sucursal.Nombre = reader.GetString(11);
                                sucursal.calle = reader.GetString(12);
                                sucursal.Numero = reader.GetString(13);
                                sucursal.Colonia = reader.GetString(14);
                                sucursal.Municipio = reader.GetString(15);
                                sucursal.Estado = reader.GetString(16);
                                sucursal.CP = reader.GetString(17);
                                comercio.Sucursales.Add(sucursal);
                            }*/

                            comercios.Add(comercio);
                        }
                    }
                }
            }
            return comercios;
        }

        [HttpGet]
        public Comercio Get(int id)
        {
            Comercio comercio = new Comercio();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT c.*, p.*, s.* FROM Comercios as c LEFT JOIN PROMOCIONES as p ON c.Id = p.ComercioId LEFT JOIN Sucursales as s ON c.Id = s.ComercioId WHERE c.Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comercio.Id = reader.GetInt32(0);
                            comercio.Nombre = reader.GetString(1);
                            comercio.Giro = reader.GetString(2);
                            comercio.Web = reader.GetString(3);
                            comercio.Facebook = reader.GetString(4);
                            comercio.Promociones = new List<Promocion>();
                            comercio.Sucursales = new List<Sucursal>();
                            if (!reader.IsDBNull(5))
                            {
                                Promocion promocion = new Promocion();
                                promocion.Id = reader.GetInt32(5);
                                promocion.Descripcion = reader.GetString(6);
                                promocion.Restricciones = reader.GetString(7);
                                promocion.FechaInicio = reader.GetString(8);
                                promocion.FechaFin = reader.GetString(9);
                                promocion.ComercioId = reader.GetInt32(10);
                                comercio.Promociones.Add(promocion);
                            }
                            
                        }
                    }
                }
            }
            return comercio;
        }

        [HttpPost]
        public void Post([FromBody] Comercio comercio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Comercios (Nombre, Giro, Web, Facebook) VALUES (@Nombre, @Giro, @Web, @Facebook)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", comercio.Nombre);
                    command.Parameters.AddWithValue("@Giro", comercio.Giro);
                    command.Parameters.AddWithValue("@Web", comercio.Web);
                    command.Parameters.AddWithValue("@Facebook", comercio.Facebook);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
