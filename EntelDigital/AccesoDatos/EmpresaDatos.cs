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
    public class EmpresaDatos
    {

        public async Task<List<Empresa>> ListarEmpresaByRUC(SqlConnection cn, Ruc objRucBE)
        {
            List<Empresa> lstEmpresaBE = null;
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SP_LISTARINFOEMPRESA",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            cmd.Parameters.AddWithValue("@ruc", objRucBE.RUC);

            using (SqlDataReader dtr = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult))
            {
                lstEmpresaBE = new List<Empresa>();
                while (await dtr.ReadAsync())
                {
                    lstEmpresaBE.Add(new Empresa
                    {
                        ruc = dtr.GetString(dtr.GetOrdinal("ruc")),
                        tipoContribuyente = dtr.IsDBNull(dtr.GetOrdinal("tipoContribuyente")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("tipoContribuyente")),
                        nombre = dtr.IsDBNull(dtr.GetOrdinal("nombre")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("nombre")),
                        nombreComercial = dtr.IsDBNull(dtr.GetOrdinal("nombreComercial")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("nombreComercial")),
                        fechaInscripcion = dtr.IsDBNull(dtr.GetOrdinal("fechaInscripcion")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("fechaInscripcion")),
                        fechaInicioActividades = dtr.IsDBNull(dtr.GetOrdinal("fechaInicioActividades")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("fechaInicioActividades")),
                        estadoContribuyente = dtr.IsDBNull(dtr.GetOrdinal("estadoContribuyente")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("estadoContribuyente")),
                        condicionContribuyente = dtr.IsDBNull(dtr.GetOrdinal("condicionContribuyente")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("condicionContribuyente")),
                        direccionDomicilioFiscal = dtr.IsDBNull(dtr.GetOrdinal("direccionDomicilioFiscal")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("direccionDomicilioFiscal")),
                        departamentoDomicilioFiscal = dtr.IsDBNull(dtr.GetOrdinal("departamentoDomicilioFiscal")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("departamentoDomicilioFiscal")),
                        provinciaDomicilioFiscal = dtr.IsDBNull(dtr.GetOrdinal("provinciaDomicilioFiscal")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("provinciaDomicilioFiscal")),
                        distritoDomicilioFiscal = dtr.IsDBNull(dtr.GetOrdinal("distritoDomicilioFiscal")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("distritoDomicilioFiscal")),
                        sistemaEmisionComprobante = dtr.IsDBNull(dtr.GetOrdinal("sistemaEmisionComprobante")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("sistemaEmisionComprobante")),
                        actividadComercioExterior = dtr.IsDBNull(dtr.GetOrdinal("actividadComercioExterior")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("actividadComercioExterior")),
                        sistemaDeContabilidad = dtr.IsDBNull(dtr.GetOrdinal("sistemaDeContabilidad")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("sistemaDeContabilidad")),
                        emisorElectronicoDesde = dtr.IsDBNull(dtr.GetOrdinal("emisorElectronicoDesde")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("emisorElectronicoDesde")),
                        afiliadoPLEDesde = dtr.IsDBNull(dtr.GetOrdinal("afiliadoPLEDesde")) ? string.Empty : dtr.GetString(dtr.GetOrdinal("afiliadoPLEDesde"))
                    });
                }
            }
            return lstEmpresaBE;
        }

    }
}
