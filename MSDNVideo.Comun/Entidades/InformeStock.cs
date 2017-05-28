using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    [DataContract]
    public class InformeStock
    {
        int _numPeliculas;
        int _unidades;

        [DataMember]
        public int NumPeliculas
        {
            get
            {
                return _numPeliculas;
            }
            set
            {
                _numPeliculas = value;
            }
        }

        [DataMember]
        public int Unidades
        {
            get
            {
                return _unidades;
            }
            set
            {
                _unidades= value;
            }
        }

    }
}
