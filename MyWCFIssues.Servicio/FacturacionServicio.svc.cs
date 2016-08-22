using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NetaSystems.Servicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FacturacionServicio : IFacturacionServicio
    {

        private readonly Facturacion.Facturacion _facturacion = new Facturacion.Facturacion();

        public FacturaModel BuscarFacturaXId(int idFactura)
        {
            return _facturacion.BuscarFacturaXId(idFactura);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List< FacturaModel> ObtenerFacturas(int noPagina, int tamanoPagina)
        {
            return _facturacion.ObtenerFacturas(noPagina, tamanoPagina).ToList();
            //return _repoFactura.ObtenerFacturas(1,2).
            //return new FacturaModel
            //{
            //    BoolValue = false,
            //    StringValue = "Nos defiende"
            //};
            
        }
    }
}
