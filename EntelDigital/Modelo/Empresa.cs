using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Empresa
    {
        public string ruc { get; set; }
        public string tipoContribuyente { get; set; }
        public string nombre { get; set; }
        public string nombreComercial { get; set; }
        public string fechaInscripcion { get; set; }
        public string fechaInicioActividades { get; set; }
        public string estadoContribuyente { get; set; }
        public string condicionContribuyente { get; set; }
        public string direccionDomicilioFiscal { get; set; }
        public string departamentoDomicilioFiscal { get; set; }
        public string provinciaDomicilioFiscal { get; set; }
        public string distritoDomicilioFiscal { get; set; }
        public string sistemaEmisionComprobante { get; set; }
        public string actividadComercioExterior { get; set; }
        public string sistemaDeContabilidad { get; set; }
        public string emisorElectronicoDesde { get; set; }
        public string afiliadoPLEDesde { get; set; }
        
    }
}
