using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MSDNVideo.Comun
{
    public partial class Socio : IDataErrorInfo
    {
        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get 
            {
                if (base.Error == null &&
                    this["Nombre"] == null &&
                    this["Telefono"] == null &&
                    this["Email"] == null &&
                    this["Direccion"] == null &&
                    this["Ciudad"] == null &&
                    this["Provincia"] == null &&
                    this["CodigoPostal"] == null &&
                    this["Saldo"] == null)

                    return null;
                else
                    return "Error en socio";

            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get 
            {
                if (base[columnName] != null)
                    return base[columnName];

                if (columnName == "Nombre")
                {
                    if (!ValidacionesEntidad.ValidarExiste(Nombre))
                        return "Introduzca un nombre";
                }

                if (columnName == "Telefono")
                {
                    if (!ValidacionesEntidad.ValidarExiste(Telefono))
                        return "Introduzca un teléfono válido";
                }

                if (columnName == "Email")
                {
                    if (!ValidacionesEntidad.ValidarEmail(Email))
                        return "Introduzca un email válido";
                }

                if (columnName == "Direccion")
                {
                    if (!ValidacionesEntidad.ValidarExiste(Direccion))
                        return "Introduzca una dirección";
                }

                if (columnName == "Ciudad")
                {
                    if (!ValidacionesEntidad.ValidarExiste(Ciudad))
                        return "Introduzca una ciudad";
                }

                if (columnName == "Provincia")
                {
                    if (!ValidacionesEntidad.ValidarExiste(Provincia))
                        return "Introduzca una provincia";
                }

                if (columnName == "CodigoPostal")
                {
                    if (!CodigoPostal.HasValue)
                        return "Introduzca un código postal";
                    if(!ValidacionesEntidad.ValidarValorMinimo(CodigoPostal, 0))
                        return "Introduzca un código postal válido";
                    if(!ValidacionesEntidad.ValidarValorMaximo(CodigoPostal, 99999))
                        return "Introduzca un código postal válido";
                }

                if (columnName == "Saldo")
                {
                    if (!ValidacionesEntidad.ValidarValorMinimo(Saldo, 0))
                        return "Introduzca un saldo mayor de cero";
                }

                return null;
            }
        }

        #endregion
    }
}
