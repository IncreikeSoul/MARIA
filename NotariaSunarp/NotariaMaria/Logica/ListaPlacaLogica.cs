using AccesoDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ListaPlacaLogica : ConexionLogica<ListaPlaca>
    {
        public async Task<bool> RegistrarPlaca(ListaPlaca objListaPlacaBE)
        {
            using (SqlConnection cn = new SqlConnection(this.soatStringConexion))
            {
                await cn.OpenAsync();
                ListaPlacaDatos objListaPlacaDA = new ListaPlacaDatos();
                return await objListaPlacaDA.RegistrarListaPlaca(cn, objListaPlacaBE);
            }
        }

    }
}
