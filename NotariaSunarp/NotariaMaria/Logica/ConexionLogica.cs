using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ConexionLogica<T>
    {
        public string sunarpStringConexion { get; set; }
        public string soatStringConexion { get; set; }

        public ConexionLogica()
        {
            sunarpStringConexion = ConfigurationManager.ConnectionStrings["CNSunarp"].ConnectionString;
            soatStringConexion = ConfigurationManager.ConnectionStrings["CNSoat"].ConnectionString;
        }

        public virtual Task<int> Edit(T Item)
        {
            return null;
        }
        public virtual Task<IEnumerable<T>> Retrieve(T Item)
        {
            return null;
        }
        public virtual Task<T> Find(T Item)
        {
            return null;
        }
        public virtual Task<int> Delete(T Item)
        {
            return null;
        }
    }
}
