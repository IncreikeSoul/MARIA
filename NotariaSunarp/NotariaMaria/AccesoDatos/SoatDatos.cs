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
    public class SoatDatos
    {

        public async Task<List<Soat>> ListarSoatPlaca(SqlConnection cn, ListaPlaca objListaPlacaBE)
        {
            List<Soat> lstSoatBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_LISTARINFOPLACA",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@placa", objListaPlacaBE.placa);

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstSoatBE = new List<Soat>();
                while (await dtr.ReadAsync())
                {
                    lstSoatBE.Add(new Soat
                    {
                        Placa = dtr.GetString(dtr.GetOrdinal("Placa")),
                        Compania = dtr.GetString(dtr.GetOrdinal("Compania")),
                        Inicio = dtr.GetString(dtr.GetOrdinal("Inicio")),
                        Fin = dtr.GetString(dtr.GetOrdinal("Fin")),
                        NumeroPoliza = dtr.GetString(dtr.GetOrdinal("NumeroPoliza")),
                        UsoVehiculo = dtr.GetString(dtr.GetOrdinal("UsoVehiculo")),
                        ClaseVehiculo = dtr.GetString(dtr.GetOrdinal("ClaseVehiculo")),
                        Estado = dtr.GetString(dtr.GetOrdinal("Estado")),
                        CodigoUnicoPoliza = dtr.GetString(dtr.GetOrdinal("CodigoUnicoPoliza")),
                        CodigoSbsAseguradora = dtr.GetString(dtr.GetOrdinal("CodigoSbsAseguradora")),
                        FechaControlPolicial = dtr.GetString(dtr.GetOrdinal("FechaControlPolicial")),
                        Contratante = dtr.IsDBNull(dtr.GetOrdinal("Contratante")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("Contratante")),
                        Ubigeo = dtr.IsDBNull(dtr.GetOrdinal("Ubigeo")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("Ubigeo")),
                        SerieMotor = dtr.IsDBNull(dtr.GetOrdinal("SerieMotor")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("SerieMotor")),
                        SerieChasis = dtr.IsDBNull(dtr.GetOrdinal("SerieChasis")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("SerieChasis")),
                        NumeroAseguradora = dtr.GetString(dtr.GetOrdinal("NumeroAseguradora")),
                        TipoCertificado = dtr.GetString(dtr.GetOrdinal("TipoCertificado")),
                        Creado = dtr.GetString(dtr.GetOrdinal("Creado")),
                        Actualizado = dtr.GetString(dtr.GetOrdinal("Actualizado"))
                    });
                }
            }
            return lstSoatBE;
        }

    }
}
