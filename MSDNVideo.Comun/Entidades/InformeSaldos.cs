using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    [DataContract]
    public class InformeSaldos
    {
        int _numSocios;
        decimal _saldo;

        [DataMember]
        public int NumSocios
        {
            get
            {
                return _numSocios;
            }
            set
            {
                _numSocios = value;
            }
        }

        [DataMember]
        public decimal Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                _saldo = value;
            }
        }

    }
}
