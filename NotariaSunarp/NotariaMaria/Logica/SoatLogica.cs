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
    public class SoatLogica : ConexionLogica<Soat>
    {
        public async Task<List<Soat>> SoatListar(ListaPlaca objListaPlacaBE)
        {
            using (SqlConnection cn = new SqlConnection(this.soatStringConexion))
            {
                await cn.OpenAsync();
                SoatDatos objSoatDA = new SoatDatos();
                return await objSoatDA.ListarSoatPlaca(cn, objListaPlacaBE);
            }
        }

    }
}
