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
using System.IO;
using MSDNVideo.Comun;
using MSDNVideo.LogicaNegocio;

public partial class Caratula : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string codBarras, anchoStr, altoStr;
        int ancho, alto;
        byte[] imagen;
        MemoryStream imageStream;
        PeliculasCN peliculasCN = new PeliculasCN();


        codBarras = Request.QueryString["CodBarras"];
        anchoStr = Request.QueryString["Ancho"];
        altoStr = Request.QueryString["Alto"];

        if(codBarras == null || !int.TryParse(anchoStr, out ancho) || !int.TryParse(altoStr, out alto))
            return;

        imagen = peliculasCN.ObtenerCaratula(codBarras, ancho, alto);
        if(imagen == null)
            return;

        imageStream = new MemoryStream(imagen);
        Response.Clear();
        Response.ContentType = "image/jpeg";
        imageStream.WriteTo(Response.OutputStream);
    }
}
