using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWCFIssues.Web.Models
{
    public class FacturaViewModel
    {               
        public int Id
        {
            get; set;
        }
        
        public decimal CantidadFacturada
        {
            get;
            set;
        }
                
        public string NombrePersona
        {
            get;
            set;
        }
    }
}