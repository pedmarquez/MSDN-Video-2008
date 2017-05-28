using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace MSDNVideo.Comun
{
    public class ValidacionesEntidad
    {
        public static bool ValidarLongitudMaxima(string value, int longitud)
        {
            if (value != null && value.Length > longitud)
                return false;
            else
                return true;
        }

        public static bool ValidarLongitudMinima(string value, int longitud)
        {
            if (value != null && value.Length < longitud)
                return false;
            else
                return true;
        }

        public static bool ValidarExiste(string value)
        {
            if (value == null || value.Length == 0)
                return false;
            else
                return true;
        }

        public static bool ValidarCodBarras(string codBarras)
        {
            if (codBarras != null && codBarras.Length == 13)
                return true;
            else
                return false;
        }

        internal static bool ValidarValorMaximo(int value, int maxValue)
        {
            if (value > maxValue)
                return false;
            else
                return true;
        }

        internal static bool ValidarValorMinimo(int value, int minValue)
        {
            if (value < minValue)
                return false;
            else
                return true;
        }

        internal static bool ValidarValorMaximo(decimal? value, decimal? maxValue)
        {
            if (value > maxValue)
                return false;
            else
                return true;
        }

        internal static bool ValidarValorMinimo(decimal? value, decimal? minValue)
        {
            if (value < minValue)
                return false;
            else
                return true;
        }


        internal static bool ValidarNIF(string nif)
        {
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            int nifNum;
            bool valido = true;

            if (nif == null)
                return false;

            if (!System.Text.RegularExpressions.Regex.IsMatch(nif, @"^\d{8}[" + letras + "]$"))
                valido = false;
            else
            {
                nifNum = int.Parse(nif.Substring(0, nif.Length - 1));
                if(nif[8] != letras[nifNum % 23])
                    valido = false;
            }

            return valido;
        }

        internal static bool ValidarEmail(string email)
        {
            if (email == null)
                return false;

            if (System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                return true;
            else
                return false;
        }

        internal static bool ValidarReferenciaExiste<T>(EntityRef<T> referencia) where T : class
        {
            if (referencia.HasLoadedOrAssignedValue && referencia.Entity == null)
                return false;

            return true;
        }
    }
}
