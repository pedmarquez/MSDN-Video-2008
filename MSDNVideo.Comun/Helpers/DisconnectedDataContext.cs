using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.Collections;
using System.ComponentModel;

namespace MSDNVideo.Comun
{
    public interface IDisconnectedDataContext
    {
        object Attach(object entidad);

        void AttachAll<S>(BindingList<S> entidades);

        void AttachList<S>(BindingList<S> entidades);

        void AcceptChanges();

        void Remove(object entidad);

        void AddNew(object entidad);
    }

    public class DisconnectedDataContext<T> : IDisconnectedDataContext where T : DataContext, new()
    {
        private DataContext _dataContext;
        private List<object> _attachedEntities;
        private IBindingList _attachedList;
        private IBindingList _syncList;

        public DisconnectedDataContext()
        {
            _dataContext = new T();
            _dataContext.DeferredLoadingEnabled = false;
            _attachedEntities = new List<object>();
        }

        public object Attach(object entidad)
        {
            return InternalAttach(entidad, true);
        }

        public void AttachAll<S>(BindingList<S> entidades)
        {
            int i;

            for (i = 0; i < entidades.Count; i++)
            {
                entidades[i] = (S)InternalAttach(entidades[i], true);
            }
        }

        public void AttachList<S>(BindingList<S> entidades)
        {
            int i;
       
            _attachedList = entidades;
            _syncList = new BindingList<S>();
            for (i = 0; i < entidades.Count; i++)
            {
                entidades[i] = (S)InternalAttach(entidades[i], true);
                _syncList.Add(entidades[i]);
            }

            // Escuchamos a los eventos de cambio en la lista
            _attachedList.ListChanged += new ListChangedEventHandler(AttachedList_Changed);
        }

        public void AcceptChanges()
        {
            _dataContext.Dispose();
            _attachedEntities.Clear();

            if (_attachedList != null)
            {
                _attachedList.ListChanged -= new ListChangedEventHandler(AttachedList_Changed);
                _attachedList = null;
            }

            _syncList = null;

            _dataContext = new T();
            _dataContext.DeferredLoadingEnabled = false;
        }

        public void AddNew(object entidad)
        {
            _attachedEntities.Add(entidad);

            ITable tabla = OperacionesEntidad.GetTablaFromEntidad(_dataContext, entidad);
            tabla.InsertOnSubmit(entidad);
        }

        public void Remove(object entidad)
        {
            ITable tabla = OperacionesEntidad.GetTablaFromEntidad(_dataContext, entidad);
            tabla.DeleteOnSubmit(entidad);
        }

        private void AttachedList_Changed(object sender, ListChangedEventArgs e)
        {
            object entidad;

            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                // Se ha añadido un elemento a la lista
                int index = e.NewIndex;
                entidad = _attachedList[index];
                _attachedEntities.Add(entidad);
                _syncList.Insert(index, entidad);

                ITable tabla = OperacionesEntidad.GetTablaFromEntidad(_dataContext, entidad);
                tabla.InsertOnSubmit(entidad);
            }
            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                // Se ha eliminado un elemento de la lista
                entidad = _syncList[e.NewIndex];
                _syncList.RemoveAt(e.NewIndex);

                ITable tabla = OperacionesEntidad.GetTablaFromEntidad(_dataContext, entidad);
                tabla.DeleteOnSubmit(entidad);
            }
        }

        private object InternalAttach(object entidad, bool rootEntity)
        {
            ITable tabla;
            int i, j;

            for (i = 0; i < _attachedEntities.Count; i++)
            {
                if (object.ReferenceEquals(entidad, _attachedEntities[i]))
                {
                    // Misma referencia, es un ciclo. No añadimos
                    return entidad;
                }
                if (OperacionesEntidad.IsPrimaryKeyEqual(entidad, _attachedEntities[i]))
                {
                    // Distintas referencias y mismo Primary Key, sustituimos la referencia del llamante
                    // Sólo lo soportamos para entidades raíz
                    if (rootEntity)
                        return _attachedEntities[i];
                    else
                        throw new DuplicateKeyException(entidad);
                }
            }
            
            _attachedEntities.Add(entidad);

            if (rootEntity)
            {
                tabla = OperacionesEntidad.GetTablaFromEntidad(_dataContext, entidad);
                tabla.Attach(entidad, false);
            }

            // Adjuntamos las relaciones
            Type entidadType = entidad.GetType();
            PropertyInfo[] properties = entidadType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            object propValue;
            for (i = 0; i < properties.Length; i++)
            {
                if (properties[i].GetCustomAttributes(typeof(AssociationAttribute), false).Length > 0)
                {
                    propValue = properties[i].GetValue(entidad, null);
                    if (propValue is IList)
                    {
                        // Es un EntitySet, adjuntamos todas las entidades del mismo
                        IList entitySet = (IList)propValue;
                        for (j = 0; j < entitySet.Count; j++)
                        {
                            InternalAttach(entitySet[j], false);
                        }
                    }
                    else
                    {
                        // Es una entidad
                        if(propValue != null)
                            InternalAttach(propValue, false);
                    }
                }
            }

            return entidad;
        }

        public DisconnectedChangeSet GetChangeSet()
        {
            DisconnectedChangeSet changeSet = new DisconnectedChangeSet(_dataContext);

            return changeSet;
        }

    }
}
