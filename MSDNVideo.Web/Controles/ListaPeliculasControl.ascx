<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListaPeliculasControl.ascx.cs" Inherits="ListaPeliculasControl" %>
<asp:DataList ID="DataListPeliculas" runat="server"
    RepeatDirection="Horizontal" RepeatLayout="Flow" EnableViewState="False">
    <alternatingitemtemplate>
        <div class="elementoListaRight <%#GetRowStyle(Container.DataItem) %>">
            <div class="posicionLista"><%#GetIndex(Container.DataItem)%></div>
            <a runat="server" href='<%#"~/InfoPelicula.aspx?CodBarras=" + Eval("CodBarras")%>'>
                <img runat="server" class="imagenLista" src='<%#"~/Caratula.aspx?CodBarras=" + Eval("CodBarras") + "&Ancho=100&Alto=133"%>' width="100" height="133" />
            </a>
            
            <div class="textoLista">
                <div class="tituloLista">
                    <a runat="server" href='<%#"~/InfoPelicula.aspx?CodBarras=" + Eval("CodBarras")%>'><%#Eval("Titulo")%></a>
                </div>
                <%#Eval("Sinopsis")%>
            </div>
        </div><br />
    </alternatingitemtemplate>
    <itemtemplate>
        <div class="elementoListaLeft <%#GetRowStyle(Container.DataItem) %>">
            <div class="posicionLista"><%#GetIndex(Container.DataItem)%></div>
            <a runat="server" href='<%#"~/InfoPelicula.aspx?CodBarras=" + Eval("CodBarras")%>'>
                <img runat="server" class="imagenLista" src='<%#"~/Caratula.aspx?CodBarras=" + Eval("CodBarras") + "&Ancho=100&Alto=133"%>' width="100" height="133" />
            </a>
            <div class="textoLista">
                <div class="tituloLista">
                    <a runat="server" href='<%#"~/InfoPelicula.aspx?CodBarras=" + Eval("CodBarras")%>'><%#Eval("Titulo")%></a>
                </div>
                <%#Eval("Sinopsis")%>
            </div>
        </div>
    </itemtemplate>
</asp:DataList>

