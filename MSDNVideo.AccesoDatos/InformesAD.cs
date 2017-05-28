using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Componente de acceso a datos de informes
    /// </summary>
    public class InformesAD : BaseAD
    {
        #region "Operaciones públicas"

        public BindingList<InformeSaldos> ObtenerInformeSaldos()
        {
            EntidadesDataContext dc = GetDC();
            BindingList<InformeSaldos> result = new BindingList<InformeSaldos>();

            using (SqlConnection cnn = (SqlConnection)dc.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtenerInformeSaldos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    InformeSaldos informeSaldos = new InformeSaldos();
                    informeSaldos.NumSocios = (int)reader["NumSocios"];
                    informeSaldos.Saldo = (decimal)reader["Saldo"];

                    result.Add(informeSaldos);
                }
            }

            return result;
        }

        public BindingList<InformeVentas> ObtenerInformeVentas()
        {
            EntidadesDataContext dc = GetDC();
            BindingList<InformeVentas> result = new BindingList<InformeVentas>();

            using (SqlConnection cnn = (SqlConnection)dc.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtenerInformeVentas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InformeVentas informeVentas = new InformeVentas();
                    informeVentas.Alquileres = (decimal)reader["Alquileres"];
                    informeVentas.Ventas = (decimal)reader["Ventas"];
                    informeVentas.DiaSemana = (int)reader["DiaSemana"];

                    result.Add(informeVentas);
                }
            }

            return result;
        }

        public BindingList<InformeStock> ObtenerInformeStock()
        {
            EntidadesDataContext dc = GetDC();
            BindingList<InformeStock> result = new BindingList<InformeStock>();

            using (SqlConnection cnn = (SqlConnection)dc.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtenerInformeStock", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InformeStock informeStock = new InformeStock();
                    informeStock.NumPeliculas = (int)reader["NumPeliculas"];
                    informeStock.Unidades = (int)reader["Unidades"];

                    result.Add(informeStock);
                }
            }

            return result;
        }

        #endregion
    }
}
