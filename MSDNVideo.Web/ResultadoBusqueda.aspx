<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResultadoBusqueda.aspx.cs" Inherits="ResultadoBusqueda" Title="MSDN Video - Búsqueda" %>
<%@ Register TagPrefix="controles" TagName="ListaPeliculasControl" Src="Controles/ListaPeliculasControl.ascx" %>
<%@ Register TagPrefix="controles" TagName="PaginacionControl" Src="Controles/PaginacionControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Estilos.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="fondoResultados">
        <controles:PaginacionControl ElementosPagina="10" ID="paginacionPeliculas" runat="server" />
        
        <controles:ListaPeliculasControl id="listaPeliculas" runat="server" />
    </div>
</asp:Content>

