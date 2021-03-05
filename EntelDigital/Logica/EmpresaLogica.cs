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
    public class EmpresaLogica : ConexionLogica<Empresa>
    {
        public async Task<List<Empresa>> EmpresaListar(Ruc objRucBE)
        {
            using (SqlConnection cn = new SqlConnection(this.entelStringConexion))
            {
                await cn.OpenAsync();
                EmpresaDatos objEmpresaDA = new EmpresaDatos();
                return await objEmpresaDA.ListarEmpresaByRUC(cn, objRucBE);
            }
        }
    }
}
