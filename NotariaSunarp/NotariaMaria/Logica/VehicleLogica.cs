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
    public class VehicleLogica : ConexionLogica<Vehicle>
    {
        public async Task<List<Vehicle>> VehicleListar(ListaPlaca objPlacasBE)
        {
            using (NpgsqlConnection cn = new NpgsqlConnection(this.sunarpStringConexion))
            {
                await cn.OpenAsync();
                VehicleDatos objVehiculeDA = new VehicleDatos();
                return await objVehiculeDA.ListarVehiclePlaca(cn, objPlacasBE);
            }
        }

    }
}
