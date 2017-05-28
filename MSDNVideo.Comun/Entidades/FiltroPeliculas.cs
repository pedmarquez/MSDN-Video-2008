using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MSDNVideo.Comun
{
    [DataContract]
    [KnownType(typeof(CamposFiltro))]
    [Serializable]
    public class FiltroPeliculas
    {
        [DataMember]
        public string CodBarras;

        [DataMember]
        public string Titulo;

        [DataMember]
        public bool Novedad;

        [DataMember]
        public Clasificaciones Clasificacion;

        [DataMember]
        public Generos Genero;

        [DataMember]
        public int CamposFiltrado;

        [DataMember]
        public int InicioPagina;

        [DataMember]
        public int PeliculasPagina;

        [DataMember]
        public bool IncluirTotal;
    }
}
