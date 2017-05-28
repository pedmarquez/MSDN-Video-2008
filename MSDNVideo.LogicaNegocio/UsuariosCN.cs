using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDNVideo.AccesoDatos;
using MSDNVideo.Comun;
using System.ComponentModel;
using System.Security.Principal;
using System.Threading;
using System.Security.Permissions;

namespace MSDNVideo.LogicaNegocio
{
    /// <summary>
    /// Operaciones de negocio sobre usuarios
    /// </summary>
    public class UsuariosCN
    {
        #region Operaciones de filtrado

        /// <summary>
        /// Obtiene todos los usuarios del sistema
        /// Seguridad: Administradores
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<Usuario> ObtenerUsuarios()
        {
            UsuariosAD usuariosAD = new UsuariosAD();

            return usuariosAD.ObtenerUsuarios();
        }

        /// <summary>
        /// Obtiene todos los socios del sistema
        /// Seguridad: Administradores
        /// </summary>
        /// <returns>Lista de socios</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<Socio> ObtenerSocios()
        {
            UsuariosAD usuariosAD = new UsuariosAD();

            return usuariosAD.ObtenerSocios();
        }

        /// <summary>
        /// Realiza una búsqueda de socios por nombre
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nombre">Parte del nombre a buscar</param>
        /// <returns>Lista de socios</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public BindingList<Socio> ObtenerSociosPorNombre(string nombre)
        {
            UsuariosAD usuariosAD = new UsuariosAD();

            return usuariosAD.ObtenerSociosPorNombre(nombre);
        }

        /// <summary>
        /// Obtiene un usuario por NIF
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nif">NIF del usuario</param>
        /// <returns>Usuario</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public Usuario ObtenerUsuarioPorNIF(string nif)
        {
            UsuariosAD usuariosAD = new UsuariosAD();

            return usuariosAD.ObtenerUsuarioPorNIF(nif);
        }

        /// <summary>
        /// Obtiene un socio por NIF
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nif">NIF del socio</param>
        /// <returns>Socio</returns>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public Socio ObtenerSocioPorNIF(string nif)
        {
            UsuariosAD usuariosAD = new UsuariosAD();

            return usuariosAD.ObtenerSocioPorNIF(nif);
        }

        /// <summary>
        /// Obtiene el usuario actual
        /// Seguridad: Público
        /// </summary>
        /// <returns>Usuario</returns>
        public Usuario ObtenerMiUsuario()
        {
            UsuariosAD usuariosAD = new UsuariosAD();
            string nif;

            if (Thread.CurrentPrincipal == null || Thread.CurrentPrincipal.Identity.Name == "invitado")
                return null;

            nif = Thread.CurrentPrincipal.Identity.Name;
            return usuariosAD.ObtenerUsuarioPorNIF(nif);
        }

        #endregion

        #region Mantenimiento de usuarios

        /// <summary>
        /// Modifica el usuario dado
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="usuario">Usuario modificado</param>
        /// <param name="original">Usuario original</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void ActualizarUsuario(Usuario usuario, Usuario original)
        {
            UsuariosAD usuariosAD = new UsuariosAD();

            usuariosAD.ActualizarUsuario(usuario, original);
        }

        /// <summary>
        /// Elimina el usuario dado
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="usuario">Usuario a eliminar</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void EliminarUsuario(Usuario usuario)
        {
            UsuariosAD usuariosAD = new UsuariosAD();

            usuariosAD.EliminarUsuario(usuario);
        }

        /// <summary>
        /// Añade un usuario al sistema
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="usuario">Usuario a añadir</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void AgregarUsuario(Usuario usuario)
        {
            UsuariosAD usuariosAD = new UsuariosAD();

            usuariosAD.AgregarUsuario(usuario);
        }

        #endregion

        #region Operaciones sobre las claves

        /// <summary>
        /// Establece la clave de un usuario
        /// Seguridad: Administradores
        /// </summary>
        /// <param name="nif">NIF del usuario</param>
        /// <param name="clave">Clave cifrada del usuario</param>
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Role = "Admin")]
        public void EstablecerClave(string nif, string clave)
        {
            string hashClave;
            UsuariosAD usuariosAD = new UsuariosAD();

            hashClave = HashHelper.CalcularHash(clave);
            usuariosAD.EstablecerClave(nif, hashClave);
        }

        #endregion

        #region Operaciones de autenticación

        /// <summary>
        /// Valida que el usuario es correcto y que la clave es válida
        /// Seguridad: Público
        /// </summary>
        /// <param name="nifUsuario">NIF del usuario</param>
        /// <param name="clave">Clave a validar</param>
        /// <returns>Usuario</returns>
        public Usuario ValidarUsuario(string nifUsuario, string clave)
        {
            string claveHashed;
            UsuariosAD usuariosAD = new UsuariosAD();

            claveHashed = usuariosAD.ObtenerClave(nifUsuario);
            if (claveHashed == null)
                return null;

            if (HashHelper.ValidarClave(clave, claveHashed))
            {
                // Usuario correcto, devolvemos el registro del usuario
                return usuariosAD.ObtenerUsuarioPorNIF(nifUsuario);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el rol del usuario dado
        /// Seguridad: Público
        /// </summary>
        /// <param name="nifUsuario">NIF del usuario</param>
        /// <returns>Rol</returns>
        public Rol ObtenerRolUsuario(string nifUsuario)
        {
            Usuario usuario;
            UsuariosAD usuariosAD = new UsuariosAD();

            usuario = usuariosAD.ObtenerUsuarioPorNIF(nifUsuario);
            if (usuario != null)
                return usuario.Rol;
            else
                return Rol.Socio;
        }

        #endregion
    }
}
