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
}
