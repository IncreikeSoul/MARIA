using Logica;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace NotariaMaria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> InsertarPlaca(ListaPlaca objListaPlacaBE)
        {
            ListaPlacaLogica objPlacaSoatLog = new ListaPlacaLogica();
            PlacaLogica objPlacaSunarpLog = new PlacaLogica();

            try
            {
                await objPlacaSoatLog.RegistrarPlaca(objListaPlacaBE);
                await objPlacaSunarpLog.RegistrarPlaca(objListaPlacaBE);
            }
            catch(Exception e)
            {
                Console.WriteLine(""+e);
            }

            return RedirectToAction("Index");
        }

        public async Task<JsonResult> ListarInfoVehiculo(ListaPlaca objListaPlacaBE)
        {
            SoatLogica objSoatLog = new SoatLogica();
            VehicleLogica objVehicleLog = new VehicleLogica();

            var listaSoat = await objSoatLog.SoatListar(objListaPlacaBE);
            var listaSunarp = await objVehicleLog.VehicleListar(objListaPlacaBE);

            Enlistados objEnlt = new Enlistados(listaSoat, listaSunarp);
            List<Enlistados> lista_conc = new List<Enlistados>();
            lista_conc.Add(objEnlt);
            
            return Json(lista_conc, JsonRequestBehavior.AllowGet);
        }

    }
}