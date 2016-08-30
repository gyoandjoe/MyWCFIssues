using Modelos;
using NetaSystems.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NetaSystems.Servicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFacturacionServicio
    {

        [OperationContract]
        [WebInvoke
        (Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetData(int value);

        [OperationContract]
        [WebInvoke
        (Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<FacturaModel> ObtenerFacturas(int noPagina, int tamanoPagina);


        [OperationContract]
        [WebInvoke
        (Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        FacturaModel BuscarFacturaXId(int idFactura);


        [OperationContract]
        [WebGet(            
            RequestFormat =  WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ObtenerFactura2/{noPagina}/{criterioBusqueda}"
            )]
        IEnumerable<Factura2> ObtenerFacturas2(string noPagina, string criterioBusqueda);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
