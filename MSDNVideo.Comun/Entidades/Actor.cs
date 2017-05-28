using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MSDNVideo.Comun
{
    public partial class Actor : IDataErrorInfo
    {
        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                if (this["Nombre"] == null &&
                    this["UrlPersonal"] == null)
                    return null;
                else
                    return "Error en actor";
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Nombre")
                {
                    if (!ValidacionesEntidad.ValidarExiste(Nombre))
                        return "Introduzca un nombre de actor válido";
                    if (!ValidacionesEntidad.ValidarLongitudMaxima(Nombre, 200))
                        return "El nombre debe tener una longitud menor de 200 caracteres";
                }

                if (columnName == "UrlPersonal")
                {
                    if (!ValidacionesEntidad.ValidarLongitudMaxima(UrlPersonal, 150))
                        return "La URL personal debe tener una longitud menor de 150 caracteres";
                }

                return null;
            }
        }

        #endregion
    }
}
