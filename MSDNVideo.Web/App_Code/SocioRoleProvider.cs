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

/// <summary>
/// Summary description for SocioRoleProvider
/// </summary>
public class SocioRoleProvider : RoleProvider
{
    private string _applicationName = "MSDNVideo";

    public SocioRoleProvider()
    {
    }

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public override string ApplicationName
    {
        get
        {
            return _applicationName;
        }
        set
        {
            _applicationName = value;
        }
    }

    public override void CreateRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
        throw new NotImplementedException();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
        throw new NotImplementedException();
    }

    public override string[] GetAllRoles()
    {
        return new string[] { "Admin", "Socio" };
    }

    public override string[] GetRolesForUser(string username)
    {
        UsuariosCN usuariosCN = new UsuariosCN();

        return new string[] { usuariosCN.ObtenerRolUsuario(username).ToString() };
    }

    public override string[] GetUsersInRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override bool IsUserInRole(string username, string roleName)
    {
        throw new NotImplementedException();
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public override bool RoleExists(string roleName)
    {
        throw new NotImplementedException();
    }
}
