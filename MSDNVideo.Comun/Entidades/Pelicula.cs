using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    public partial class Pelicula : IDataErrorInfo
    {
        private decimal _puntuacionMedia;

        #region IDataErrorInfo Members

        public string Error
        {
            get 
            {
                if (this["CodBarras"] == null &&
                    this["Titulo"] == null &&
                    this["Sinopsis"] == null &&
                    this["Duracion"] == null &&
                    this["URLTrailer"] == null &&
                    this["UnidadesAlquiler"] == null &&
                    this["UnidadesVenta"] == null &&
                    this["UnidadesVentaAlquiler"] == null)

                    return null;
                else
                    return "Error en película";
            }
        }

        public string this[string columnName]
        {
            get 
            {
                if (columnName == "CodBarras")
                {
                    if (!ValidacionesEntidad.ValidarCodBarras(CodBarras))
                        return "Introduzca un código de barras válido";
                }

                if (columnName == "Titulo")
                {
                    if (!ValidacionesEntidad.ValidarLongitudMaxima(Titulo, 200))
                        return "El título debe tener una longitud menor de 200 caracteres";
                    if (!ValidacionesEntidad.ValidarExiste(Titulo))
                        return "Introduzca un título";
                }

                if (columnName == "Sinopsis")
                {
                    if (!ValidacionesEntidad.ValidarLongitudMaxima(Sinopsis, 2000))
                        return "La sinopsis debe tener una longitud menor de 2000 caracteres";
                }

                if (columnName == "Duracion")
                {
                    if (!ValidacionesEntidad.ValidarValorMaximo(Duracion, 1000))
                        return "La duración debe ser menor de 1000 minutos";
                    if (!ValidacionesEntidad.ValidarValorMinimo(Duracion, 1))
                        return "Introduzca una duración";
                }

                if (columnName == "URLTrailer")
                {
                    if (!ValidacionesEntidad.ValidarLongitudMaxima(URLTrailer, 150))
                        return "La URL del trailer debe tener una longitud menor de 150 caracteres";
                }

                if (columnName == "UnidadesAlquiler")
                {
                    if (!ValidacionesEntidad.ValidarValorMinimo(UnidadesAlquiler, 0))
                        return "Introduzca un valor válido para las unidades en alquiler";
                }

                if (columnName == "UnidadesVenta")
                {
                    if (!ValidacionesEntidad.ValidarValorMinimo(UnidadesVenta, 0))
                        return "Introduzca un valor válido para las unidades en venta";
                }

                if (columnName == "UnidadesVentaAlquiler")
                {
                    if (!ValidacionesEntidad.ValidarValorMinimo(UnidadesVentaAlquiler, 0))
                        return "Introduzca un valor válido para las unidades en venta y alquiler";
                }



                return null;
            }
        }

        #endregion

        public int DisponibleVenta
        {
            get
            {
                int sobreAlquiler = UnidadesAlquiladas - UnidadesAlquiler;
                if (sobreAlquiler < 0)
                    sobreAlquiler = 0;

                return UnidadesVenta + UnidadesVentaAlquiler - sobreAlquiler;
            }
        }

        public int DisponibleAlquiler
        {
            get
            {
                return UnidadesAlquiler + UnidadesVentaAlquiler - UnidadesAlquiladas;
            }
        }

        [DataMember]
        public decimal PuntuacionMedia
        {
            get
            {
                return _puntuacionMedia;
            }
            set
            {
                _puntuacionMedia = value;
            }
        }

    }
}
