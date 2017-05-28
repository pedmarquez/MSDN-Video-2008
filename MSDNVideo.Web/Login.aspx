<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Estilos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="MarcoContainer">
	    <div class="TituloMarcoContainer">
		    <div class="TituloMarco">Clientes con tarjeta de socio</div>
		    <div class="IconoMarco"></div>
	    </div>
	    <div>
                <p class="TextoMarco">
                Si usted es un cliente que ya dispone de tarjeta de socio puede utilizar nuestros servicios online para alquilar y comprar películas. 
                Introduzca su NIF y la clave que solicitó en nuestra tienda.
                </p>
                <div class="formLogin">
                    <asp:Login ID="Login1" runat="server">
                        <LayoutTemplate>
                            <table border="0" cellpadding="1" cellspacing="0" 
                                style="border-collapse:collapse;">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0">
                                            <tr>
                                                <td align="center" colspan="2">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" 
                                                        CssClass="TextoMarco">NIF:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="controlMenu"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                        ControlToValidate="UserName" ErrorMessage="Introduzca su NIF." 
                                                        ToolTip="Introduzca su NIF." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                                                        CssClass="TextoMarco">Clave:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" 
                                                        CssClass="controlMenu"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                        ControlToValidate="Password" ErrorMessage="Introduzca su clave." 
                                                        ToolTip="Introduzca su clave." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Recordar la próxima vez." 
                                                        CssClass="TextoMarco" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color:Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False" 
                                                        Text="Usuario o clave incorrectos" Visible="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button CssClass="controlMenu" ID="LoginButton" runat="server" CommandName="Login" 
                                                        Text="Iniciar sesión" ValidationGroup="Login1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
                </div>
                <p class="TextoMarco direccion">Nota: Usuario de prueba "00000000T", clave "12345"</p>
        </div>
    </div>    

    <div class="MarcoContainer">
	    <div class="TituloMarcoContainer">
		    <div class="TituloMarco">Clientes con tarjeta de socio</div>
		    <div class="IconoMarco"></div>
	    </div>
	    <div>
                <p class="TextoMarco">
                Para acceder a nuestros servicios por Internet deberá ser socio de nuestra tienda. 
                Diríjase a nuestro local para obtener la tarjeta de socio y disfrutar del 
                mejor cine en casa. Le atendemos en la siguiente dirección:
                </p>
		        <p class="TextoMarco direccion"><i>MSDN Video<br/>
			        Avda. del Cine, 8<br/>
			        28760 Ciudad del Cine <b>MADRID</b></i>
                </p>
        </div>
    </div>    


</asp:Content>

