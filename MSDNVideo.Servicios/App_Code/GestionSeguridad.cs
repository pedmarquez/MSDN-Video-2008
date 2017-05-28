using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;
using System.Security.Principal;
using System.Threading;

/// <summary>
/// Summary description for GestionSeguridad
/// </summary>
public class GestionSeguridad
{
    private const string _passwordCacheSufix = "Password";
    private const string _usuarioAuthCacheSufix = "Usuario";

    public static bool ValidarUsuario(string userName, string password)
    {
        // Valida el usuario y la clave
        Usuario usuario;
        UsuariosCN usuariosCN = new UsuariosCN();
        string cacheKey;
        string passwordCache;
        bool correcto = true;

        if (userName.ToLower() != "invitado")
        {
            cacheKey = userName + "\\t" + _passwordCacheSufix;
            passwordCache = (string)CacheManager.GetItem(cacheKey);
            if (passwordCache == null)
            {
                usuario = usuariosCN.ValidarUsuario(userName, password);
                if (usuario != null)
                    CacheManager.AddItem(cacheKey, password);
                else
                    correcto = false;
            }
            else
            {
                if (passwordCache != password)
                    correcto = false;
            }
        }

        return correcto;
    }

    public static GenericPrincipal ObtenerPrincipal(string userName)
    {
        string cacheKey;
        Usuario usuario;
        UsuariosCN usuariosCN = new UsuariosCN();

        if (userName == null || userName.ToLower() == "invitado")
        {
            return new GenericPrincipal(new GenericIdentity("invitado"), null);
        }
        else
        {
            cacheKey = userName + "\\t" + _usuarioAuthCacheSufix;
            usuario = (Usuario)CacheManager.GetItem(cacheKey);
            if (usuario == null)
            {
                ImpersonarLlamada();

                usuario = usuariosCN.ObtenerUsuarioPorNIF(userName);

                CancelarImpersonarLlamada();

                if (usuario == null)
                    return null;
            }

            return CrearPrincipalDeUsuario(usuario.NIF, usuario.Rol);
        }
    }

    private static GenericPrincipal CrearPrincipalDeUsuario(string nif, Rol rol)
    {
        GenericIdentity identity;
        GenericPrincipal principal;

        identity = new GenericIdentity(nif);
        if (rol == Rol.Admin)
            principal = new GenericPrincipal(identity, new string[] { "Admin" });
        else
            principal = new GenericPrincipal(identity, new string[] { "Socio" });

        return principal;
    }


    private static void ImpersonarLlamada()
    {
        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("Admin"), new string[] { "Admin" });
    }

    private static void CancelarImpersonarLlamada()
    {
        Thread.CurrentPrincipal = null;
    }
}
