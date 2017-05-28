using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;
using System.ComponentModel;

/// <summary>
/// Summary description for AJAXService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AJAXService : System.Web.Services.WebService
{

    public AJAXService()
    {

    }

    [WebMethod]
    public Pelicula[] ObtenerPeliculasEstreno()
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        BindingList<Pelicula> peliculas;
        FiltroPeliculas filtro = new FiltroPeliculas();
        int total;
        
        filtro.CamposFiltrado = (int)CamposFiltro.Novedad;
        filtro.Novedad = true;
        filtro.IncluirTotal = false;
        filtro.InicioPagina = 0;
        filtro.PeliculasPagina = 7;

        peliculas = peliculasCN.ObtenerPeliculasPorFiltro(filtro, false, false, out total);

        return peliculas.ToArray();
    }

}

