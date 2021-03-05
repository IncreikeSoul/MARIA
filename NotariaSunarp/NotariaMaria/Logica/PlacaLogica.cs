using AccesoDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Logica
{
    public class PlacaLogica : ConexionLogica<Placas>
    {
        public async Task<bool> RegistrarPlaca(ListaPlaca objListaPlacaBE)
        {
            using (NpgsqlConnection cn = new NpgsqlConnection(this.sunarpStringConexion))
            {
                await cn.OpenAsync();
                PlacasDatos objPlacasDA = new PlacasDatos();
                return await objPlacasDA.RegistrarPlaca(cn, objListaPlacaBE);
            }
        }

    }
}
