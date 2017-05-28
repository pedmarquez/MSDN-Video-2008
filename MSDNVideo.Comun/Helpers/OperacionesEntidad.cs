using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.Collections;
using System.Data.Linq;

namespace MSDNVideo.Comun
{
    public class OperacionesEntidad
    {
        private static Dictionary<string, EntityKeyComparer> _cachedComparers = new Dictionary<string, EntityKeyComparer>();
        private static Dictionary<string, ITable> _cachedTables = new Dictionary<string, ITable>();
        private static DataContext _cachedDataContext;

        public static object ObtenerEntidadOriginal(DataContext dataContext, object entidad)
        {
            ITable tabla = GetTablaFromEntidad(dataContext, entidad);
            return tabla.GetOriginalEntityState(entidad);
        }

        public static object CreateDataCopy(object source, bool copyAssociations)
        {
            Type sourceType = source.GetType();
            object dest = Activator.CreateInstance(sourceType);

            int i;
            PropertyInfo[] properties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo hasLoadedValueProp, entityProp;
            FieldInfo entityRefField;
            object valueOrigen;
            object[] atts;
            AssociationAttribute assocAtt;
            object entityRef;

            for (i = 0; i < properties.Length; i++)
            {
                // Comprobamos si la propiedad es una asociación
                atts = properties[i].GetCustomAttributes(typeof(AssociationAttribute), false);
                if (atts.Length > 0)
                {
                    // Es una asociación
                    if (copyAssociations)
                    {
                        assocAtt = (AssociationAttribute)atts[0];
                        if (assocAtt.IsForeignKey || assocAtt.IsUnique)
                        {
                            // Relación 1:1
                            entityRefField = sourceType.GetField(assocAtt.Storage, BindingFlags.NonPublic | BindingFlags.Instance);
                            entityRef = entityRefField.GetValue(source);
                            hasLoadedValueProp = entityRef.GetType().GetProperty("HasLoadedOrAssignedValue");
                            if ((bool)hasLoadedValueProp.GetValue(entityRef, null))
                            {
                                // La fuente tiene un valor en la asociación, copiamos
                                valueOrigen = properties[i].GetValue(source, null);
                                entityRef = entityRefField.GetValue(dest);
                                entityProp = entityRef.GetType().GetProperty("Entity");
                                entityProp.SetValue(entityRef, valueOrigen, null);
                            }
                        }
                    }
                }
                else
                {
                    // No es una asociación, copiamos directamente
                    if (properties[i].CanWrite)
                    {
                        valueOrigen = properties[i].GetValue(source, null);
                        properties[i].SetValue(dest, valueOrigen, null);
                    }
                }
            }

            return dest;
        }


        public static ITable GetTablaFromEntidad(DataContext dataContext, object entidad)
        {
            // Buscamos en caché
            string tipoEntidad = entidad.GetType().Name;
            if (object.ReferenceEquals(dataContext, _cachedDataContext))
            {
                if (_cachedTables.ContainsKey(tipoEntidad))
                    return _cachedTables[tipoEntidad];
            }
            else
            {
                _cachedTables.Clear();
                _cachedDataContext = dataContext;
            }

            // Recuperamos la propiedad de tabla para la entidad dada
            int i;
            Type dcType = dataContext.GetType();
            Type propType;
            Type[] genericTypes;
            PropertyInfo[] properties = dcType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            ITable tabla;

            for (i = 0; i < properties.Length; i++)
            {
                propType = properties[i].PropertyType;
                if (typeof(ITable).IsAssignableFrom(propType))
                {
                    genericTypes = propType.GetGenericArguments();
                    if (genericTypes.Length > 0 && genericTypes[0].IsAssignableFrom(entidad.GetType()))
                    {
                        tabla = (ITable)properties[i].GetValue(dataContext, null);
                        _cachedTables.Add(tipoEntidad, tabla);
                        return tabla;
                    }
                }
            }

            return null;
        }

        public static bool IsPrimaryKeyEqual(object entidad1, object entidad2)
        {
            Type tipoEntidad = entidad1.GetType();

            if (!tipoEntidad.IsAssignableFrom(entidad2.GetType()))
            {
                return false;
            }

            if (_cachedComparers.ContainsKey(tipoEntidad.Name))
            {
                return _cachedComparers[tipoEntidad.Name].Comparar(entidad1, entidad2);
            }
            else
            {
                EntityKeyComparer comparer = new EntityKeyComparer(tipoEntidad);
                _cachedComparers.Add(tipoEntidad.Name, comparer);
                return comparer.Comparar(entidad1, entidad2);
            }

        }

        internal static void ActualizarAsociaciones(object entidadOriginal, object entidadCopia, Dictionary<object, object> listaEntidades)
        {
            Type tipoEntidad = entidadOriginal.GetType();
            object reference;
            int i;
            PropertyInfo[] properties = tipoEntidad.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (i = 0; i < properties.Length; i++)
            {
                if (properties[i].GetCustomAttributes(typeof(AssociationAttribute), false).Length > 0)
                {
                    reference = properties[i].GetValue(entidadOriginal, null);
                    if (reference != null && listaEntidades.ContainsKey(reference))
                    {
                        properties[i].SetValue(entidadCopia, listaEntidades[reference], null);
                    }
                }
            }            
        }
    }

    public class EntityKeyComparer
    {
        private List<PropertyInfo> _pkProperties = new List<PropertyInfo>();

        public EntityKeyComparer(Type tipoEntidad)
        {
            int i;
            PropertyInfo[] properties;
            object[] columnAttribute;

            properties = tipoEntidad.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (i = 0; i < properties.Length; i++)
            {
                columnAttribute = properties[i].GetCustomAttributes(typeof(ColumnAttribute), false);
                if (columnAttribute.Length > 0 && ((ColumnAttribute)columnAttribute[0]).IsPrimaryKey)
                {
                    // La columna es clave primaria
                    _pkProperties.Add(properties[i]);
                }
            }
        }

        public bool Comparar(object entidad1, object entidad2)
        {
            bool areEqual = true;
            int i;

            for (i = 0; i < _pkProperties.Count; i++)
            {
                if (((IComparable)_pkProperties[i].GetValue(entidad1, null)).CompareTo(_pkProperties[i].GetValue(entidad2, null)) != 0)
                    areEqual = false;
            }

            return areEqual;
        }

    }
}
