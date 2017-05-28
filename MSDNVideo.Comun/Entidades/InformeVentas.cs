using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    [DataContract]
    public class InformeVentas
    {
        decimal _ventas;
        decimal _alquileres;
        int _diaSemana;

        [DataMember]
        public decimal Ventas
        {
            get
            {
                return _ventas;
            }
            set
            {
                _ventas = value;
            }
        }

        [DataMember]
        public decimal Alquileres
        {
            get
            {
                return _alquileres;
            }
            set
            {
                _alquileres = value;
            }
        }

        [DataMember]
        public int DiaSemana
        {
            get
            {
                return _diaSemana;
            }
            set
            {
                _diaSemana = value;
            }
        }
    }
}
