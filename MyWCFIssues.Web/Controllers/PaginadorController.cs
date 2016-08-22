using MyWCFIssues.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWCFIssues.Web.Controllers
{
    public class PaginadorController : Controller
    {
        private const int tamanoPagina = 2;
        
        // GET: Paginador
        public ActionResult Index()
        {
            var facturas = Utilidades.ConsumirRESTFullService<List<FacturaViewModel>>("http://localhost:26787/FacturacionServicio.svc/ObtenerFacturas",
               new
               {
                   noPagina = 1,
                   tamanoPagina = tamanoPagina
               });
            ViewBag.paginaActual = 1;
            return View(facturas);
        }

        public ActionResult ObtenerFacturasXPagina(int noPagina)
        {
            //Verificamos que no obtengamos una pagina con numero negativo
            if (noPagina < 1)
                noPagina = 1;
            

            var facturas = Utilidades.ConsumirRESTFullService<List<FacturaViewModel>>("http://localhost:26787/FacturacionServicio.svc/ObtenerFacturas",
                new
                {
                    noPagina = noPagina,
                    tamanoPagina = tamanoPagina
                });

            //Verificamos que no obtengamos una pagina con un numero muy alto
            if (noPagina > 1)
                if (facturas.Count == 0)
                {
                    noPagina--;
                    facturas = Utilidades.ConsumirRESTFullService<List<FacturaViewModel>>("http://localhost:26787/FacturacionServicio.svc/ObtenerFacturas",
                    new
                    {
                        noPagina = noPagina,
                        tamanoPagina = tamanoPagina
                    });
                }

            ViewBag.paginaActual = noPagina;
            return View("Index",facturas);
            //return Json(facturas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetalleFactura(int idFactura)
        {
            var factura = Utilidades.ConsumirRESTFullService<FacturaViewModel>("http://localhost:26787/FacturacionServicio.svc/BuscarFacturaXId",
                new
                {
                    idFactura
                });
            return View(factura);
            //return Json(factura, JsonRequestBehavior.AllowGet);
        }
    }
}