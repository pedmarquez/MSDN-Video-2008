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

public partial class InfoPelicula : System.Web.UI.Page
{
    private string _videoURL;

    protected void Page_Load(object sender, EventArgs e)
    {
        string codBarras;
        Pelicula pelicula;
        PeliculasCN peliculasCN;
        bool modalidadVenta, modalidadAlquiler;

        codBarras = Server.HtmlEncode(Request.QueryString["CodBarras"]);
        if (codBarras == null)
            return;

        pelicula = (Pelicula)Cache["Pelicula_" + codBarras];
        
        if (pelicula == null)
        {
            peliculasCN = new PeliculasCN();
            pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarras, true, true);
            if (pelicula == null)
                return;

            Cache["Pelicula_" + codBarras] = pelicula;
        }

        // Mostrar info de película
        lblTitulo.InnerText = pelicula.Titulo;
        Caratula.Src = "Caratula.aspx?CodBarras=" + codBarras + "&Ancho=300&Alto=380";

        if (pelicula.DisponibleAlquiler == 0)
            containerAlquilar.Visible = false;
        else
            containerNotificar.Visible = false;
        if (pelicula.DisponibleVenta == 0)
            containerComprar.Visible = false;

        Sinopsis.InnerText = pelicula.Sinopsis;
        Duracion.InnerText = pelicula.Duracion + " min";
        Evaluacion.Evaluacion = pelicula.PuntuacionMedia;
        Genero.InnerText = GeneroToString(pelicula.Genero);

        VideoURL = pelicula.URLTrailer;

        lnkComprar.NavigateUrl = "~/Secure/ComprarAlquilar.aspx?Accion=comprar&CodBarras=" + pelicula.CodBarras;
        lnkAlquilar.NavigateUrl = "~/Secure/ComprarAlquilar.aspx?Accion=alquilar&CodBarras=" + pelicula.CodBarras;

        modalidadAlquiler = modalidadVenta = false;
        if (pelicula.UnidadesVenta + pelicula.UnidadesVentaAlquiler > 0)
            modalidadVenta = true;
        if (pelicula.UnidadesAlquiler + pelicula.UnidadesVentaAlquiler > 0)
            modalidadAlquiler = true;

        if (modalidadVenta && modalidadAlquiler)
            Modalidad.InnerText = "Venta y alquiler";
        else if (modalidadAlquiler)
            Modalidad.InnerText = "Alquiler";
        else
            Modalidad.InnerText = "Venta";

        Reparto.DataSource = pelicula.ActoresPeliculas;
        Reparto.DataBind();
    }

    protected string VideoURL
    {
        get
        {
            return _videoURL;
        }
        set
        {
            _videoURL = value;
        }
    }

    private string GeneroToString(Generos genero)
    {
        switch (genero)
        {
            case Generos.Accion:
                return "Acción";
            case Generos.Comedia:
                return "Comedia";
            case Generos.Drama:
                return "Drama";
            case Generos.Romantica:
                return "Romántica";
            case Generos.Terror:
                return "Terror";
            case Generos.Thriller:
                return "Thriller";
            default:
                return "";
        }

    }
}
