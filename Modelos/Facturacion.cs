using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion
{
    /// <summary>
    /// Negocio relacionado a facturacion
    /// </summary>
    public class Facturacion
    {
        private readonly NetaSystems.Repositorio.FacturaRepositorio _repoFactura = new NetaSystems.Repositorio.FacturaRepositorio();
        public IEnumerable<Modelos.FacturaModel> ObtenerFacturas(int noPagina, int tamanoPagina = 10)
        {
            var ds = _repoFactura.ObtenerFacturas(noPagina, tamanoPagina);
            foreach (DataRow row  in ds.Tables[0].Rows)
            {                
                yield return new Modelos.FacturaModel
                {                    
                    Id = Convert.ToInt32 (row["Id"]),
                    CantidadFacturada =Convert.ToDecimal(  row["CantidadFacturada"]),
                    NombrePersona = row["NombrePersona"].ToString()
                };
            }
        }

        public Modelos.FacturaModel BuscarFacturaXId(int facturaId)
        {

            var ds = _repoFactura.BuscarFacuraXId(facturaId);

            if (ds.Tables[0].Rows.Count == 0)
                throw new Exception("Factura no encontrada");

            if (ds.Tables[0].Rows.Count > 1)            
                throw new Exception("Id de factura repetido");

            return new Modelos.FacturaModel
            {
                Id = Convert.ToInt32(((DataRow)ds.Tables[0].Rows[0])["Id"]),
                CantidadFacturada = Convert.ToDecimal(((DataRow)ds.Tables[0].Rows[0])["CantidadFacturada"]),
                NombrePersona = (((DataRow)ds.Tables[0].Rows[0])["NombrePersona"]).ToString()
            };           
        }
    }
}
