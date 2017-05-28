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
using System.Web.Security;

using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;
using System.ComponentModel;
using System.Collections.Specialized;

public class SocioMembershipProvider : MembershipProvider
{

    private string _applicationName = "MSDNVideo";

    public SocioMembershipProvider()
    {
        
    }

    #region "Métodos de MembershipProvider"
    
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

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        throw new NotSupportedException();
    }    

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        throw new NotSupportedException();
    }

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        UsuariosCN usuariosCN = new UsuariosCN();
        Socio usuario = new Socio();

        usuario.NIF = username;
        usuario.Rol = Rol.Socio;
        
        usuariosCN.AgregarUsuario(usuario);

        status = MembershipCreateStatus.Success;

        return SocioToMembershipUser(usuario);
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        Usuario usuario;
        UsuariosCN UsuariosCN = new UsuariosCN();

        usuario = UsuariosCN.ObtenerSocioPorNIF(username);

        if(usuario != null)
            UsuariosCN.EliminarUsuario(usuario);

        return true;
    }

    public override bool EnablePasswordReset
    {
        get
        {
            return false;
        }
    }

    public override bool EnablePasswordRetrieval
    {
        get
        {
            return false;
        }
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new NotSupportedException();
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new NotSupportedException();
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        BindingList<Socio> socios;
        UsuariosCN usuariosCN = new UsuariosCN();

        socios = usuariosCN.ObtenerSocios();
        totalRecords = socios.Count;
        return SociosToCollection(socios, pageIndex, pageSize);
    }

    public override int GetNumberOfUsersOnline()
    {
        return 0;
    }

    public override string GetPassword(string username, string answer)
    {
        throw new NotSupportedException();
    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        throw new NotSupportedException();
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
        throw new NotSupportedException();
    }

    public override string GetUserNameByEmail(string email)
    {
        throw new NotSupportedException();
    }


    public override void Initialize(string name, NameValueCollection config)
    {
        if (config == null)
            throw new ArgumentNullException("No hay fichero de configuracion?");

        if (String.IsNullOrEmpty(name))
            name = "SocioMembershipProvider";

        if (String.IsNullOrEmpty(config["description"]))
        {
            config.Remove("description");
            config.Add("description", "Proveedor de Membership de MSDN Video");
        }

        base.Initialize(name, config);
    }

    public override int MaxInvalidPasswordAttempts
    {
        get
        {
            return 0;
        }
    }

    public override int MinRequiredNonAlphanumericCharacters
    {
        get
        {
            return 0;
        }
    }

    public override int MinRequiredPasswordLength
    {
        get
        {
            return 6;
        }
    }

    public override int PasswordAttemptWindow
    {
        get
        {
            return 0;
        }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
        get
        {
            return MembershipPasswordFormat.Hashed;
        }
    }

    public override string PasswordStrengthRegularExpression
    {
        get
        {
            return null;
        }
    }

    public override bool RequiresQuestionAndAnswer
    {
        get
        {
            return false;
        }
    }

    public override bool RequiresUniqueEmail
    {
        get
        {
            return true;
        }
    }

    public override string ResetPassword(string username, string answer)
    {
        throw new NotSupportedException();
    }

    public override bool UnlockUser(string userName)
    {
        throw new NotSupportedException();
    }

    public override void UpdateUser(MembershipUser user)
    {
        throw new NotSupportedException();
    }

    public override bool ValidateUser(string username, string password)
    {
        UsuariosCN usuariosCN = new UsuariosCN();
        Usuario usuario;

        usuario = usuariosCN.ValidarUsuario(username, password);
        if (usuario == null)
            return false;
        else if (usuario.Rol == Rol.Admin)
            return false;
        else
            return true;
    }

    #endregion

    #region "Métodos privados"

    private MembershipUserCollection SociosToCollection(BindingList<Socio> socios, int pageIndex, int pageSize)
    {
        MembershipUserCollection collection = new MembershipUserCollection();
        int i;

        for(i = (pageSize * pageIndex); i<(pageSize * (pageIndex + 1));i++)
        {
            if (i < socios.Count)
                collection.Add(SocioToMembershipUser(socios[i]));
            else
                return collection;
        }

        return  collection;

    }

    private MembershipUser SocioToMembershipUser(Socio socio)
    {
        return new MembershipUser(base.Name, socio.NIF, socio.UsuarioID, socio.Email, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
    }

    #endregion

}
