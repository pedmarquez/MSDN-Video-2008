<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ElementoMenuControl.ascx.cs" Inherits="ElementoMenuControl" %>
<a href="<%#MenuURL%>" class="enlaceMenu">
<p id="<%#ID%>" class="elementoMenu" onmouseover='menuSelect("<%#ID%>", "selectedMenu")' onmouseout='menuSelect("<%#ID%>", "elementoMenu")'>
<asp:Image ID="MenuImage" runat="server" alt="selector" class="estrellaMenu" height="15" ImageUrl="~/resources/Estrella.gif" width="16"/>
<%#MenuText%>
</p>
</a>