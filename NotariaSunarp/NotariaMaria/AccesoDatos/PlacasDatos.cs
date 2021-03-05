using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AccesoDatos
{
    public class PlacasDatos
    {
        public async Task<bool> RegistrarPlaca(NpgsqlConnection cn, ListaPlaca objListaPlacaBE)
        {
            try
            {
                bool resultado = false;
                NpgsqlCommand cmd = new NpgsqlCommand
                {
                    CommandText = "INSERT INTO \"public\".placas (id, plate_number, status, created) VALUES (@placa, @placa_number, 0, NOW())",
                    Connection = cn
                };

                cmd.Parameters.AddWithValue("placa", objListaPlacaBE.placa);
                cmd.Parameters.AddWithValue("placa_number", objListaPlacaBE.placa);
                cmd.Prepare();

                /*NpgsqlParameter param1 = cmd.Parameters.AddWithValue("@placa", objPlacasBE.id);
                param1.Direction = ParameterDirection.Input;*/

                int rpta = await cmd.ExecuteNonQueryAsync();
                if (rpta > 0)
                    resultado = true;

                return resultado;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return false;
            }
        }

    }
}
