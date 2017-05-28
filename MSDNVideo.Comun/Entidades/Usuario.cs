using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    [KnownType(typeof(Socio))]
    [KnownType(typeof(Admin))]
    public partial class Usuario : IDataErrorInfo
    {
        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                if (this["NIF"] == null)
                    return null;
                else
                    return "Error en usuario";
            }
        }

        public string this[string columnName]
        {
            get 
            {
                if (columnName == "NIF")
                {
                    if (!ValidacionesEntidad.ValidarNIF(NIF))
                        return "Introduzca un NIF válido";
                }

                return null;
            }
        }

        #endregion
    }
}
