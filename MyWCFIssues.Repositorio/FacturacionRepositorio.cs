using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetaSystems.Repositorio
{
    public class FacturaRepositorio
    {
        private readonly string _connString = @"Server = DESKTOP-I5000\MSSQLSERVER14; Database = TestNetaSystems; User Id = sa;Password = saluditos1;";
        public DataSet ObtenerFacturas(int noPagina, int tamanoPaginacion = 10)
        {                                    
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_ObtenerFacturasXPagina";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@noPagina", noPagina);
                cmd.Parameters.AddWithValue("@registrosXPagina",tamanoPaginacion );

                conn.Open();
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;

                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet BuscarFacuraXId(int idFactura)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Factura where Id = " + idFactura.ToString();
                cmd.CommandType = System.Data.CommandType.Text;              
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;

                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }

    public class FacturaRepositorio2
    {
        private readonly string conString;
        private readonly int tamanoPaginado;
        public FacturaRepositorio2(string connectionString, int tamanoPaginado)
        {
            this.conString = connectionString;
            this.tamanoPaginado = tamanoPaginado;
        }

        public IEnumerable<Factura2> ObtenerFacturas(int noPagina, string criterioBusqueda)
        {
            using (SqlConnection con = new SqlConnection(this.conString))

            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "SP_ObtenerFacturas2";
                cmd.Parameters.AddWithValue("@NoPagina", noPagina);
                cmd.Parameters.AddWithValue("@TamanoPaginado", this.tamanoPaginado);
                cmd.Parameters.AddWithValue("@busqueda", criterioBusqueda);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return new Factura2
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Cantidad = reader.GetDecimal(2),
                            Fecha = reader.GetDateTime(3)
                        };
                    }
                }

                
            }           
        }
    }

    public class Factura2
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
