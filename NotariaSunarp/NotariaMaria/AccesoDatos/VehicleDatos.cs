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
    public class VehicleDatos
    {

        public async Task<List<Vehicle>> ListarVehiclePlaca(NpgsqlConnection cn, ListaPlaca objPlacasBE)
        {
            List<Vehicle> lstVehicleBE = null;
            NpgsqlCommand cmd = new NpgsqlCommand
            {
                CommandText = "SELECT * FROM \"public\".vehicle WHERE id = @placa",
                Connection = cn
            };
            cmd.Parameters.AddWithValue("placa", objPlacasBE.placa);

            using (NpgsqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstVehicleBE = new List<Vehicle>();
                while (await dtr.ReadAsync())
                {
                    lstVehicleBE.Add(new Vehicle
                    {
                        id = dtr.GetString(dtr.GetOrdinal("id")),
                        plate_number = dtr.GetString(dtr.GetOrdinal("plate_number")),
                        serial_number = dtr.IsDBNull(dtr.GetOrdinal("serial_number")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("serial_number")),
                        vin_number = dtr.IsDBNull(dtr.GetOrdinal("vin_number")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("vin_number")),
                        engine_number = dtr.IsDBNull(dtr.GetOrdinal("engine_number")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("engine_number")),
                        color = dtr.IsDBNull(dtr.GetOrdinal("color")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("color")),
                        make = dtr.IsDBNull(dtr.GetOrdinal("make")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("make")),
                        model = dtr.IsDBNull(dtr.GetOrdinal("model")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("model")),
                        valid_plate_number = dtr.IsDBNull(dtr.GetOrdinal("valid_plate_number")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("valid_plate_number")),
                        previous_plate_number = dtr.IsDBNull(dtr.GetOrdinal("previous_plate_number")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("previous_plate_number")),
                        state = dtr.IsDBNull(dtr.GetOrdinal("state")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("state")),
                        notes = dtr.IsDBNull(dtr.GetOrdinal("notes")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("notes")),
                        branch = dtr.IsDBNull(dtr.GetOrdinal("branch")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("branch")),
                        owners = dtr.IsDBNull(dtr.GetOrdinal("owners")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("owners")),
                        status = dtr.GetInt32(dtr.GetOrdinal("status")),
                        created = dtr.GetDateTime(dtr.GetOrdinal("created")),
                        image_path = dtr.IsDBNull(dtr.GetOrdinal("image_path")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("image_path"))
                    });
                }
            }
            return lstVehicleBE;
        }

    }
}
