using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class Controles_PaginacionControl : System.Web.UI.UserControl
{
    public event EventHandler PaginacionChanged;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public int NumElementos
    {
        get
        {
            return (int)ViewState["NumElementos"];
        }
        set
        {
            base.ViewState["NumElementos"] = value;
        }
    }

    public int ElementosPagina
    {
        get
        {
            return (int)ViewState["ElementosPagina"];
        }
        set
        {
            base.ViewState["ElementosPagina"] = value;
        }
    }

    public int ElementoActual
    {
        get
        {
            return (int)ViewState["ElementoActual"];
        }
        set
        {
            base.ViewState["ElementoActual"] = value;
        }
    }

    private void Page_PreRender()
    {
        List<int> numPaginas = new List<int>();
        int i;
        int paginaActual = ElementoActual / ElementosPagina;
        int numPaginasTotal = NumElementos / ElementosPagina + 1;
        int paginasMostradas = numPaginasTotal > 10 ? 10 : numPaginasTotal;
        int paginaInicial = paginaActual < 4 ? 1 : paginaActual - 3;

        if (paginasMostradas == 1)
        {
            lnkSiguiente.Visible = false;
            lnkAnterior.Visible = false;
            return;
        }

        for (i = paginaInicial; i < paginaInicial + paginasMostradas && i < numPaginasTotal + 1; i++)
        {
            numPaginas.Add(i);
        }

        paginasRepeater.DataSource = numPaginas;
        paginasRepeater.DataBind();

        if (paginaActual == 0)
            lnkAnterior.Visible = false;
        else
            lnkAnterior.Visible = true;

        if (paginaActual == numPaginasTotal - 1)
            lnkSiguiente.Visible = false;
        else
            lnkSiguiente.Visible = true;


        tituloNavegacion.InnerText = NumElementos.ToString() + " películas encontradas";
    }

    protected void paginasRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ElementoActual = (int.Parse((string)e.CommandArgument) - 1) * ElementosPagina;        
        if(PaginacionChanged != null)
            PaginacionChanged(this, new EventArgs());
    }

    protected void lnkAnterior_Click(object sender, EventArgs e)
    {
        ElementoActual -= ElementosPagina;
        if (PaginacionChanged != null)
            PaginacionChanged(this, new EventArgs());
    }
    protected void lnkSiguiente_Click(object sender, EventArgs e)
    {
        ElementoActual += ElementosPagina;
        if (PaginacionChanged != null)
            PaginacionChanged(this, new EventArgs());
    }
}
