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
    public class RucLogica : ConexionLogica<Ruc>
    {
        public async Task<bool> RegistrarRUC(Ruc objRucBE)
        {
            using (SqlConnection cn = new SqlConnection(this.entelStringConexion))
            {
                await cn.OpenAsync();
                RucDatos objRucDA = new RucDatos();
                return await objRucDA.RegistrarRUC(cn, objRucBE);
            }
        }
    }
}
