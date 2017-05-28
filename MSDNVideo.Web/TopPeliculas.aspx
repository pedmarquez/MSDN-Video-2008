<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TopPeliculas.aspx.cs" Inherits="TopPeliculas" Title="MSDN Video - Top películas" %>
<%@ Register TagPrefix="controles" TagName="ListaPeliculasControl" Src="Controles/ListaPeliculasControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Estilos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="topPeliculaLeft">
        <div class="posicionLista">1</div>
        <a runat="server" class="lnkImagenTopPelicula" id="lnkImagenPeliculaIzq">
            <img id="imgCaratulaIzq" class="imagenTopPelicula" runat="server" />
        </a>
        
        <div class="textoTopPelicula">
            <div class="tituloLista">
                <a runat="server" id="lnkPeliculaIzq"></a>
            </div>
            <p runat="server" id="SinopsisIzq" class="sinopsisTopPelicula" />
        </div>
    </div>
    
    <div class="topPeliculaRight">
        <div class="posicionLista">2</div>
        <a runat="server" class="lnkImagenTopPelicula" id="lnkImagenPeliculaDer">
            <img id="imgCaratulaDer" class="imagenTopPelicula" runat="server" />
        </a>
        
        <div class="textoTopPelicula">
            <div class="tituloLista">
                <a runat="server" id="lnkPeliculaDer"></a>
            </div>
            <p runat="server" id="SinopsisDer" class="sinopsisTopPelicula" />
        </div>
    </div>

    <controles:ListaPeliculasControl PrimerIndice="3" id="listaPeliculas" runat="server" />
</asp:Content>

