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
using MSDNVideo.LogicaNegocio;
using System.ComponentModel;
using MSDNVideo.Comun;

public partial class TopPeliculas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PeliculasCN peliculasCN = new PeliculasCN();
        BindingList<Pelicula> peliculas;
        BindingList<Pelicula> subLista;
        Pelicula peliculaIzq, peliculaDer;
        int i;
        string top;

        top = (string)Request["top"];

        if(top.ToLower() == "alquiler")
            peliculas = peliculasCN.ObtenerTopPeliculasAlquiler();
        else if (top.ToLower() == "ventas")
            peliculas = peliculasCN.ObtenerTopPeliculasVentas();
        else
            peliculas = peliculasCN.ObtenerTopPeliculasPuntuacion();

        peliculaIzq = peliculas[0];
        peliculaDer = peliculas[1];

        subLista = new BindingList<Pelicula>();
        for (i = 2; i < 10; i++)
        {
            subLista.Add(peliculas[i]);
        }

        lnkImagenPeliculaIzq.HRef = "InfoPelicula.aspx?CodBarras=" + peliculaIzq.CodBarras;
        lnkPeliculaIzq.HRef = lnkImagenPeliculaIzq.HRef;
        lnkPeliculaIzq.InnerText = peliculaIzq.Titulo;
        SinopsisIzq.InnerText = peliculaIzq.Sinopsis;
        imgCaratulaIzq.Src = "Caratula.aspx?CodBarras=" + peliculaIzq.CodBarras + "&Ancho=200&Alto=266";

        lnkImagenPeliculaDer.HRef = "InfoPelicula.aspx?CodBarras=" + peliculaDer.CodBarras;
        lnkPeliculaDer.HRef = lnkImagenPeliculaDer.HRef;
        lnkPeliculaDer.InnerText = peliculaDer.Titulo;
        SinopsisDer.InnerText = peliculaDer.Sinopsis;
        imgCaratulaDer.Src = "Caratula.aspx?CodBarras=" + peliculaDer.CodBarras + "&Ancho=200&Alto=266";

        listaPeliculas.Peliculas = subLista;
        DataBind();
    }
}
