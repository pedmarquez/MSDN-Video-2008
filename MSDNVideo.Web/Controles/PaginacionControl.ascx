<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaginacionControl.ascx.cs" Inherits="Controles_PaginacionControl" %>
<div class="containerPaginacion">

    <p id="tituloNavegacion" class="tituloPaginacion" runat="server">25 películas encontradas</p>

    <ul class="listaPaginacion">
        <li class="navegacionPaginacion">
            <asp:LinkButton ID="lnkAnterior" runat="server" onclick="lnkAnterior_Click">
                <asp:Image runat="server" class="iconoNavegacion" ImageUrl="~/resources/PagAnterior.png" />
            </asp:LinkButton>
         </li>
        <asp:Repeater ID="paginasRepeater" runat="server" 
            onitemcommand="paginasRepeater_ItemCommand">
            <ItemTemplate>
                <li class="itemPaginacion" >
			        <asp:LinkButton CommandArgument="<%#Container.DataItem.ToString()%>" ID="lnkPagina" CssClass="lnkPagina" runat="server"><%#Container.DataItem.ToString()%></asp:LinkButton>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <li class="navegacionPaginacion">
            <asp:LinkButton ID="lnkSiguiente" runat="server" onclick="lnkSiguiente_Click">
                <asp:Image runat="server" class="iconoNavegacion" ImageUrl="~/resources/PagSiguiente.png" />
            </asp:LinkButton>
        </li>
    </ul>
</div>
