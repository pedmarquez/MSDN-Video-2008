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
using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;
using System.ComponentModel;

public partial class ResultadoBusqueda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage master;
        PeliculasCN peliculasCN = new PeliculasCN();
        BindingList<Pelicula> peliculas;
        FiltroPeliculas filtro;
        int numPeliculas;

        if (!IsPostBack)
        {
            // Obtenemos las películas
            filtro = new FiltroPeliculas();

            if (PreviousPage != null)
            {
                master = (MasterPage)PreviousPage.Master;
            }
            else
            {
                master = (MasterPage)this.Master;
            }

            filtro.IncluirTotal = true;
            filtro.CamposFiltrado = (int)CamposFiltro.Titulo;
            if (master.BusquedaIncluyeGenero)
                filtro.CamposFiltrado += (int)CamposFiltro.Genero;
            if (master.BusquedaIncluyeClasificacion)
                filtro.CamposFiltrado += (int)CamposFiltro.Clasificacion;
            if (master.BusquedaIncluyeEstreno)
                filtro.CamposFiltrado += (int)CamposFiltro.Novedad;

            filtro.Clasificacion = master.BusquedaClasificacion;
            filtro.Novedad = master.BusquedaEstreno;
            filtro.Genero = master.BusquedaGenero;
            filtro.Titulo = master.BusquedaTitulo;
            filtro.PeliculasPagina = paginacionPeliculas.ElementosPagina;

            ViewState["FiltroBusqueda"] = filtro;

            paginacionPeliculas.ElementoActual = 0;
            listaPeliculas.PrimerIndice = 1;

            peliculas = peliculasCN.ObtenerPeliculasPorFiltro(filtro, false, false, out numPeliculas);

            paginacionPeliculas.NumElementos = numPeliculas;
            listaPeliculas.Peliculas = peliculas;
            DataBind();

        }

        paginacionPeliculas.PaginacionChanged += new EventHandler(OnPaginacionChanged);
    }

    protected void OnPaginacionChanged(object sender, EventArgs e)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        BindingList<Pelicula> peliculas;
        FiltroPeliculas filtro;
        int numPeliculas;

        filtro = (FiltroPeliculas)ViewState["FiltroBusqueda"];
        filtro.InicioPagina = paginacionPeliculas.ElementoActual;
        listaPeliculas.PrimerIndice = paginacionPeliculas.ElementoActual + 1;

        peliculas = peliculasCN.ObtenerPeliculasPorFiltro(filtro, false, false, out numPeliculas);
        listaPeliculas.Peliculas = peliculas;
        DataBind();
    }
}
