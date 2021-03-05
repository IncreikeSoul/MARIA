using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class RucDatos
    {

        public async Task<bool> RegistrarRUC(SqlConnection cn, Ruc objRucBE)
        {
            try
            {
                bool resultado = false;
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SP_INSERTAR_RUC",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cn
                };

                SqlParameter param1 = cmd.Parameters.AddWithValue("@ruc", objRucBE.RUC);
                param1.Direction = ParameterDirection.Input;

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
