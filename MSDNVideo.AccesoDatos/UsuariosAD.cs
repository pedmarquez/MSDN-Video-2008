using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq.SqlClient;

namespace MSDNVideo.AccesoDatos
{
    /// <summary>
    /// Componente de acceso a datos de usuarios
    /// </summary>
    public class UsuariosAD : BaseAD
    {
        #region "Operaciones de filtrado"

        /// <summary>
        /// Obtiene todos los usuarios del sistema
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public BindingList<Usuario> ObtenerUsuarios()
        {
            IQueryable<Usuario> query;
            EntidadesDataContext dc = GetDC();

            query = from usuario in dc.Usuarios select usuario;
            return QueryToBindingList(query);
        }

        /// <summary>
        /// Obtiene todos los socios del sistema
        /// </summary>
        /// <returns>Lista de socios</returns>
        public BindingList<Socio> ObtenerSocios()
        {
            IQueryable<Socio> query;
            EntidadesDataContext dc = GetDC();

            query = from usuario in dc.Usuarios where usuario.Rol == Rol.Socio select (Socio)usuario;
            return QueryToBindingList(query);
        }

        /// <summary>
        /// Realiza una búsqueda de socios por nombre
        /// </summary>
        /// <param name="nombre">Parte del nombre a buscar</param>
        /// <returns>Lista de socios</returns>
        public BindingList<Socio> ObtenerSociosPorNombre(string nombre)
        {
            IQueryable<Socio> query;
            EntidadesDataContext dc = GetDC();

            query = from usuario in dc.Usuarios where (usuario.Rol == Rol.Socio && SqlMethods.Like(((Socio)usuario).Nombre, "%" + nombre + "%")) select (Socio)usuario;
            return QueryToBindingList(query);
        }


        /// <summary>
        /// Obtiene un usuario por NIF
        /// </summary>
        /// <param name="nif">NIF del usuario</param>
        /// <returns>Usuario</returns>
        public Usuario ObtenerUsuarioPorNIF(string nif)
        {
            Usuario result;
            EntidadesDataContext dc = GetDC();

            result = dc.Usuarios.Where(usuario => usuario.NIF== nif).SingleOrDefault();

            return result;
        }

        /// <summary>
        /// Obtiene un socio por NIF
        /// </summary>
        /// <param name="nif">NIF del socio</param>
        /// <returns>Socio</returns>
        public Socio ObtenerSocioPorNIF(string nif)
        {
            Socio result;
            IQueryable<Socio> query;
            EntidadesDataContext dc = GetDC();

            query = from usuario in dc.Usuarios where usuario.Rol == Rol.Socio && usuario.NIF == nif select (Socio)usuario;
            result = query.SingleOrDefault();

            return result;
        }

        #endregion

        #region "Operaciones de mantenimiento"

        /// <summary>
        /// Modifica el usuario dado
        /// </summary>
        /// <param name="usuario">Usuario modificado</param>
        /// <param name="original">Usuario original</param>
        public void ActualizarUsuario(Usuario usuario, Usuario original)
        {
            EntidadesDataContext dc = GetDC();

            dc.Usuarios.Attach(usuario, original);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Elimina el usuario dado
        /// </summary>
        /// <param name="usuario">Usuario a eliminar</param>
        public void EliminarUsuario(Usuario usuario)
        {
            EntidadesDataContext dc = GetDC();

            dc.Usuarios.Attach(usuario);
            dc.Usuarios.DeleteOnSubmit(usuario);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Añade un usuario al sistema
        /// </summary>
        /// <param name="usuario">Usuario a añadir</param>
        public void AgregarUsuario(Usuario usuario)
        {
            EntidadesDataContext dc = GetDC();

            dc.Usuarios.InsertOnSubmit(usuario);
            dc.SubmitChanges();
        }

        #endregion

        #region "Operaciones sobre la clave"

        /// <summary>
        /// Establece la clave de un usuario
        /// </summary>
        /// <param name="nif">NIF del usuario</param>
        /// <param name="clave">Clave cifrada del usuario</param>
        public void EstablecerClave(string nif, string clave)
        {
            EntidadesDataContext dc = GetDC();

            using (SqlConnection cnn = (SqlConnection)dc.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModificarClaveUsuario", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("clave", clave);
                cmd.Parameters.AddWithValue("nif", nif);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Obtiene la clave cifrada del usuario dado
        /// </summary>
        /// <param name="nif">NIF del usuario</param>
        /// <returns>Clave cifrada</returns>
        public string ObtenerClave(string nif)
        {
            EntidadesDataContext dc = GetDC();

            using (SqlConnection cnn = (SqlConnection)dc.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtenerClaveUsuario", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nif", nif);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return (string)reader["Clave"];
                else
                    return null;
            }
        }

        #endregion

    }
}
