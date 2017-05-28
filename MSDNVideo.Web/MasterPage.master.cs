using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using MSDNVideo.Comun;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered("ScriptMenu"))
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ScriptMenu", "<script language=JavaScript type=text/javascript src='" + BaseURL + "/resources/scripts.js'></script>");
    }

    protected string BaseURL
    {
        get
        {
            try
            {
                return string.Format("http://{0}{1}",
                                     HttpContext.Current.Request.ServerVariables["HTTP_HOST"],
                                     (VirtualFolder.Equals("/")) ? string.Empty : VirtualFolder);
            }
            catch
            {
                return null;
            }

        }
    }

    private static string VirtualFolder
    {
        get { return HttpContext.Current.Request.ApplicationPath; }
    }

    // Acceso a los campos de la búsqueda
    public string BusquedaTitulo
    {
        get { return Titulo.Text; }
    }

    public Generos BusquedaGenero
    {
        get 
        {
            int index = Genero.SelectedIndex;
            if (index == 6)
                return Generos.Romantica;
            else
                return (Generos)index;
        }
    }

    public bool BusquedaIncluyeGenero
    {
        get { return Genero.SelectedIndex != 6; }
    }

    public Clasificaciones BusquedaClasificacion
    {
        get
        {
            int index = Clasificacion.SelectedIndex;
            if (index == 4)
                return Clasificaciones.Apta;
            else
                return (Clasificaciones)index;
        }
    }

    public bool BusquedaIncluyeClasificacion
    {
        get { return Clasificacion.SelectedIndex != 4; }
    }

    public bool BusquedaEstreno
    {
        get
        {
            if (Estreno.SelectedIndex == 0)
                return true;
            else
                return false;
        }
    }

    public bool BusquedaIncluyeEstreno
    {
        get { return (Estreno.SelectedIndex != 2);}
    }

    protected void BuscarPelicula_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/ResultadoBusqueda.aspx");
    }

    protected void logon_Click(object sender, EventArgs e)
    {
        Response.Redirect(BaseURL + "/Secure/InfoUsuario.aspx");
    }

    protected void logoff_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
    }
}
