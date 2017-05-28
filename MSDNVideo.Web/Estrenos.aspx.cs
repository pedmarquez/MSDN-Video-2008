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
using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;
using System.ComponentModel;

public partial class Estrenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FiltroPeliculas filtro;

        if (!IsPostBack)
        {
            filtro = new FiltroPeliculas();
            filtro.IncluirTotal = true;
            filtro.CamposFiltrado = (int)CamposFiltro.Novedad;
            filtro.Novedad = true;
            filtro.PeliculasPagina = paginacionPeliculas.ElementosPagina;


            paginacionPeliculas.ElementoActual = 0;
            listaPeliculas.PrimerIndice = 1;

            ObtenerPeliculas(filtro);
        }

        paginacionPeliculas.PaginacionChanged += new EventHandler(OnPaginacionChanged);
    }

    protected void OnPaginacionChanged(object sender, EventArgs e)
    {
        FiltroPeliculas filtro;

        filtro = new FiltroPeliculas();
        filtro.IncluirTotal = true;
        filtro.CamposFiltrado = (int)CamposFiltro.Novedad;
        filtro.PeliculasPagina = paginacionPeliculas.ElementosPagina;
        filtro.InicioPagina = paginacionPeliculas.ElementoActual;
        filtro.Novedad = true;

        listaPeliculas.PrimerIndice = paginacionPeliculas.ElementoActual + 1;

        ObtenerPeliculas(filtro);
    }

    private void ObtenerPeliculas(FiltroPeliculas filtro)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        BindingList<Pelicula> peliculas;
        int numPeliculas;

        peliculas = peliculasCN.ObtenerPeliculasPorFiltro(filtro, false, false, out numPeliculas);

        paginacionPeliculas.NumElementos = numPeliculas;
        listaPeliculas.Peliculas = peliculas;
        DataBind();

    }
}
