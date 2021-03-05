using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Enlistados
    {
        public List<Soat> listaSoat { get; set; }
        public List<Vehicle> listaSunarp { get; set; }

        public Enlistados(List<Soat> listaSoat, List<Vehicle> listaSunarp)
        {
            this.listaSoat = listaSoat;
            this.listaSunarp = listaSunarp;
        }
    }
}
