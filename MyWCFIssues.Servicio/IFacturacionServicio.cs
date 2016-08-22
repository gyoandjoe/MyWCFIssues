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
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
