<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComprarAlquilar.aspx.cs" Inherits="Secure_ComprarAlquilar" Title="MSDN Video - Comprar película" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../Estilos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Panel ID="PanelInformacion" runat="server">
        <div class="MarcoContainer">
            <div class="TituloMarcoContainer">
                <div class="TituloMarco">Confirmación</div>
                <div class="IconoMarco"></div>
            </div>
            
            <div class="caratulaConfirmacionContainer">
                <img id="imgCaratula" runat="server" class="caratulaConfirmacion" />
            </div>

            <div class="infoConfirmacionContainer">
                <div class="containerAccionInfoPelicula">
                    <p class="textoAccionInfoPelicula etiquetaInfoPelicula" >Película:</p>
                    <p id="Titulo" runat="server" class="textoAccionInfoPelicula" >Título película</p>
                </div>
                
                <div class="containerAccionInfoPelicula">
                    <p class="textoAccionInfoPelicula etiquetaInfoPelicula" >Precio:</p>
                    <p id="Precio" runat="server" class="textoAccionInfoPelicula" >0.15 € / hora</p>
                </div>

                <div class="containerAccionInfoPelicula">
                    <p class="textoAccionInfoPelicula etiquetaInfoPelicula" >Saldo usuario:</p>
                    <p id="Saldo" runat="server" class="textoAccionInfoPelicula" >100 €</p>
                </div>
                <div class="containerAccionInfoPelicula">
                    <asp:LinkButton CssClass="linkAccionConfirmacion" id="lnkAlquilar" 
                        runat="server" onclick="lnkAlquilar_Click" >
                        <img src="../resources/Alquilar.jpg" height="28" width="83" />
                     </asp:LinkButton>
                    <asp:LinkButton CssClass="linkAccionConfirmacion" id="lnkComprar" 
                        runat="server" onclick="lnkComprar_Click" >
                        <img src="../resources/Comprar.jpg" height="28" width="83" />
                     </asp:LinkButton>
                </div>
            </div>

        </div>
    </asp:Panel>
    
    <asp:Panel ID="PanelResultado" runat="server" Visible = "false">
        <div class="MarcoContainer">
            <div class="TituloMarcoContainer">
                <div class="TituloMarco">Resultado</div>
                <div class="IconoMarco"></div>
            </div>
            
            <p class="TextoMarco" runat="server" id="Resultado">
                La película ha sido alquilada, puede recogerla en la tienda cuando lo desee.
            </p>        

        </div>
    </asp:Panel>


</asp:Content>

