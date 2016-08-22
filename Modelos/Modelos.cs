using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [DataContract]
    public class FacturaModel
    {
        
        int stringValue;
        [DataMember]
        public int Id
        {
            get { return stringValue; }
            set { stringValue = value; }
        }

        decimal cantidadFacturada;
        [DataMember]
        public decimal CantidadFacturada
        {
            get { return cantidadFacturada; }
            set { cantidadFacturada = value; }
        }

        string nombrePersona;
        [DataMember]
        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }
    }
}
