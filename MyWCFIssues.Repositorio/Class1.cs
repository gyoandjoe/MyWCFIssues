using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetaSystems.Repositorio
{
    public class Class1
    {
        public void ObtenerFacturas(int noPagina, int tamanoPaginacion = 10)
        {
            //C#
            string connString = "Data Source=FAMILYFRIENDLY;Integrated Security=SSPI;Initial Catalog=TEstNetaSystems;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT CustomerId, CompanyName FROM Customers";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@noPagina", noPagina);
                cmd.Parameters.AddWithValue("@registrosXPagina",tamanoPaginacion );

                conn.Open();

                SqlParameter returnValue = new SqlParameter();
                //returnValue.Direction

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;

                DataSet ds = new DataSet();
                da.Fill(ds);

                using (SqlDataReader dr = cmd.ExecuteReader())

                {
                    while (dr.Read())
                        Console.WriteLine("{0}\t{1}", dr.GetString(0), dr.GetString(1));
                }
            }
        }
    }
}
