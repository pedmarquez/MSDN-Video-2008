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
using MSDNVideo.Comun;

public partial class Secure_ComprarAlquilar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string accion;
        string codBarras;
        Pelicula pelicula;
        Socio socio;
        PeliculasCN peliculasCN = new PeliculasCN();
        UsuariosCN usuariosCN = new UsuariosCN();

        codBarras = Server.HtmlEncode(Request.QueryString["CodBarras"]);
        accion = Server.HtmlEncode(Request.QueryString["accion"]);

        imgCaratula.Src = "../Caratula.aspx?Ancho=100&Alto=133&CodBarras=" + codBarras;

        pelicula = peliculasCN.ObtenerPeliculaPorCodBarras(codBarras, false, false);
        socio = (Socio)usuariosCN.ObtenerMiUsuario();

        Titulo.InnerText = pelicula.Titulo;
        Saldo.InnerText = socio.Saldo.Value.ToString() + " €";

        if (accion.ToLower() == "alquilar")
        {
            lnkComprar.Visible = false;
            lnkAlquilar.Visible = true;
            Precio.InnerText = "0,15 € / hora";
        }
        else
        {
            lnkComprar.Visible = true;
            lnkAlquilar.Visible = false;
            Precio.InnerText = "21,00 €";
        }
    }
    protected void lnkAlquilar_Click(object sender, EventArgs e)
    {
        string codBarras;

        codBarras = Server.HtmlEncode(Request.QueryString["CodBarras"]);

        AlquileresCN alquileresCN = new AlquileresCN();
        EstadoPedido estadoPedido;

        estadoPedido = alquileresCN.AlquilarMiPelicula(codBarras);
        ActualizarMensaje(estadoPedido, true);
        
    }

    private void ActualizarMensaje(EstadoPedido estadoPedido, bool esAlquiler)
    {
        string operacion;

        if (esAlquiler)
            operacion = "el alquiler";
        else
            operacion = "la compra";

        if (estadoPedido == EstadoPedido.SaldoInsuficiente)
        {
            Resultado.InnerText = "No dispone de saldo suficiente para realizar " + operacion + ". Recarge la tarjeta y vuelva a intentarlo";
        }
        else if (estadoPedido == EstadoPedido.StockInsuficiente)
        {
            Resultado.InnerText = "No se pudo realizar " + operacion + ". No quedan unidades de la película en existencias";
        }
        else
        {
            if(esAlquiler)
                Resultado.InnerText = "La película ha sido alquilada, puede recogerla en la tienda cuando lo desee.";
            else
                Resultado.InnerText = "La película ha sido comprada, puede recogerla en la tienda cuando lo desee.";
        }

        PanelResultado.Visible = true;
        PanelInformacion.Visible = false;
    }

    protected void lnkComprar_Click(object sender, EventArgs e)
    {
        string codBarras;

        codBarras = Server.HtmlEncode(Request.QueryString["CodBarras"]);

        ComprasCN comprasCN = new ComprasCN();
        EstadoPedido estadoPedido;

        estadoPedido = comprasCN.ComprarMiPelicula(codBarras);
        ActualizarMensaje(estadoPedido, true);

    }
}

