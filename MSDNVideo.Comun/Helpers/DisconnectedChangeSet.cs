using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace MSDNVideo.Comun
{
    [DataContract()]
    [KnownType(typeof(Pelicula))]
    [KnownType(typeof(ActoresPelicula))]
    [KnownType(typeof(Actor))]
    [KnownType(typeof(Usuario))]
    [KnownType(typeof(Socio))]
    [KnownType(typeof(Admin))]
    [KnownType(typeof(Alquiler))]
    [KnownType(typeof(Historico))]
    [KnownType(typeof(Notificacion))]
    [KnownType(typeof(Puntuacion))]
    public class DisconnectedChangeSet
    {
        List<object> _modificados = new List<object>();
        List<object> _modificadosOriginales = new List<object>();
        List<object> _eliminados = new List<object>();
        List<object> _agregados = new List<object>();

        [DataMember]
        public List<object> Modificados
        {
            get { return _modificados; }
            set { _modificados = value; }
        }

        [DataMember]
        public List<object> ModificadosOriginal
        {
            get { return _modificadosOriginales; }
            set { _modificadosOriginales = value; }
        }

        [DataMember]
        public List<object> Eliminados
        {
            get { return _eliminados; }
            set { _eliminados = value; }
        }

        [DataMember]
        public List<object> Agregados
        {
            get { return _agregados; }
            set { _agregados = value; }
        }

        public bool HayCambios
        {
            get
            {
                return (_modificados.Count > 0) || (_agregados.Count > 0) || (_eliminados.Count > 0);
            }
        }

        public bool Validate()
        {
            int i;
            IDataErrorInfo entidad;
            
            for (i = 0; i < _modificados.Count; i++)
            {
                entidad = _modificados[i] as IDataErrorInfo;
                if (entidad != null && entidad.Error != null)
                {
                    return false;
                }
            }

            for (i = 0; i < _agregados.Count; i++)
            {
                entidad = _agregados[i] as IDataErrorInfo;
                if (entidad != null && entidad.Error != null)
                {
                    return false;
                }
            }
            
            return true;
        }

        internal DisconnectedChangeSet(DataContext dataContext)
        {
            // Obtenemos el ChangeSet del DataContext
            Dictionary<object, object> listaEntidades = new Dictionary<object,object>();
            ChangeSet changeSet = dataContext.GetChangeSet();
            _modificados = new List<object>(changeSet.Updates);
            _eliminados = new List<object>(changeSet.Deletes);
            _agregados = new List<object>(changeSet.Inserts);

            // Obtenemos los valores originales
            int i;

            for (i = 0; i < _modificados.Count; i++)
            {
                _modificadosOriginales.Add(OperacionesEntidad.ObtenerEntidadOriginal(dataContext, _modificados[i]));
            }

            for (i = 0; i < _eliminados.Count; i++)
            {
                _eliminados[i] = OperacionesEntidad.ObtenerEntidadOriginal(dataContext, _eliminados[i]);
            }

            // Creamos copias para no serializar las relaciones
            for (i = 0; i < _modificados.Count; i++)
            {
                _modificados[i] = OperacionesEntidad.CreateDataCopy(_modificados[i], true);
                listaEntidades.Add(changeSet.Updates[i], _modificados[i]);
            }
            for (i = 0; i < _eliminados.Count; i++)
            {
                _eliminados[i] = OperacionesEntidad.CreateDataCopy(_eliminados[i], true);
                listaEntidades.Add(changeSet.Deletes[i], _eliminados[i]);
            }
            for (i = 0; i < _agregados.Count; i++)
            {
                _agregados[i] = OperacionesEntidad.CreateDataCopy(_agregados[i], true);
                listaEntidades.Add(changeSet.Inserts[i], _agregados[i]);
            }
            for (i = 0; i < _modificadosOriginales.Count; i++)
                _modificadosOriginales[i] = OperacionesEntidad.CreateDataCopy(_modificadosOriginales[i], true);

            // Actualizamos asociaciones a copias
            for (i = 0; i < _modificados.Count; i++)
            {
                OperacionesEntidad.ActualizarAsociaciones(changeSet.Updates[i], _modificados[i], listaEntidades);
            }
            for (i = 0; i < _eliminados.Count; i++)
            {
                OperacionesEntidad.ActualizarAsociaciones(changeSet.Deletes[i], _eliminados[i], listaEntidades);
            }
            for (i = 0; i < _agregados.Count; i++)
            {
                OperacionesEntidad.ActualizarAsociaciones(changeSet.Inserts[i], _agregados[i], listaEntidades);
            }

        }


    }
}
