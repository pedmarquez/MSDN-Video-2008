using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using MSDNVideo.Comun;

public partial class ListaPeliculasControl : System.Web.UI.UserControl
{
    public BindingList<Pelicula> Peliculas
    {
        get
        {
            return (BindingList<Pelicula>)DataListPeliculas.DataSource;
        }
        set
        {
            DataListPeliculas.DataSource = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected int GetIndex(object pelicula)
    {
        if (Peliculas == null || !(pelicula is Pelicula))
            return 0;
        else
            return Peliculas.IndexOf((Pelicula)pelicula) + PrimerIndice;
    }

    protected string GetRowStyle(object pelicula)
    {
        int index = GetIndex(pelicula) + PrimerIndice - 1;
        int rowIndex = (index-1) % 4;

        if (rowIndex == 0 || rowIndex == 1)
            return "filaListaPar";
        else
            return "filaListaImpar";

    }

    public int PrimerIndice
    {
        get
        {
            return (int)ViewState["PrimerIndice"];
        }
        set
        {
            ViewState["PrimerIndice"] = value;
        }
    }
}
