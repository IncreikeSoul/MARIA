using Logica;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntelDigital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ListarInfoEmpresa(Ruc objRucBE)
        {
            RucLogica objRucLog = new RucLogica();
            EmpresaLogica objEmpresaLog = new EmpresaLogica();

            try
            {
                await objRucLog.RegistrarRUC(objRucBE);
            }
            catch (Exception e)
            {
                Console.WriteLine("Mensaje Error: " + e);
            }

            var lstRUCBE = await objEmpresaLog.EmpresaListar(objRucBE);

            return Json(lstRUCBE, JsonRequestBehavior.AllowGet);
        }
    }
}