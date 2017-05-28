<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InfoPelicula.aspx.cs" Inherits="InfoPelicula" Title="MSDN Video - Detalle película" %>
<%@ Register TagPrefix="controles" TagName="EvaluacionControl" Src="Controles/EvaluacionControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Estilos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript" src="SilverlightControls/Silverlight.js"></script>
    <script type='text/javascript' src="SilverlightControls/BasePlayer.js"></script>
    <script type='text/javascript' src="SilverlightControls/PlayerStrings.js"></script>
	<script type="text/javascript" src="SilverlightControls/CreateTrailer.js"></script>
	<script type="text/javascript" src="SilverlightControls/TrailerControl.xaml.js"></script>

    <p ID="lblTitulo" runat="server" class="tituloPagina">Título película</p>
    <div class="containerCaratulaPelicula">
        <img src="" alt="carátula" id="Caratula" class="caratulaInfoPelicula" runat="server"></img>
        <div id="TrailerControlHost" class="trailerControl">
            <script type="text/javascript">
	            createSilverlight("<%=VideoURL%>");
            </script>
        </div>
    </div>

    <div class="panelInfoPelicula">
        <div class="MarcoContainerInfoPelicula">
	        <div class="TituloMarcoContainer">
		        <div class="TituloMarco">Compra y alquiler</div>
		        <div class="IconoMarco"></div>
	        </div>
            <div id="containerComprar" class="containerAccionInfoPelicula" runat="server">
                <asp:hyperlink CssClass="linkAccionInfoPelicula" id="lnkComprar" runat="server" Height="28" Width="83" ImageUrl="resources/Comprar.jpg" BorderWidth="0" NavigateUrl="~/Secure/ComprarAlquilar.aspx?Accion=comprar"></asp:hyperlink>
                <p class="textoAccionInfoPelicula" >Disponible para comprar</p>
            </div>
            
            <div id="containerAlquilar" runat="server" class="containerAccionInfoPelicula">
                <asp:hyperlink CssClass="linkAccionInfoPelicula" id="lnkAlquilar" runat="server" Height="28" Width="83" ImageUrl="resources/Alquilar.jpg" BorderWidth="0" NavigateUrl="~/Secure/ComprarAlquilar.aspx?Accion=alquilar"></asp:hyperlink>
                <p class="textoAccionInfoPelicula" >Disponible para alquilar</p>
            </div>

            <div id="containerNotificar" runat="server" class="containerAccionInfoPelicula">
                <asp:hyperlink CssClass="linkAccionInfoPelicula" id="lnkNotificar" runat="server" Height="28" Width="83" ImageUrl="resources/Notificar.jpg" BorderWidth="0"></asp:hyperlink>
                <p class="textoAccionInfoPelicula">No disponible para alquiler</p>
            </div>                
        </div>
        
        <div class="MarcoContainerInfoPelicula">
	        <div class="TituloMarcoContainer">
		        <div class="TituloMarco">Sinopsis</div>
		        <div class="IconoMarco"></div>
	        </div>
	        
            <p id="Sinopsis" runat="server" class="TextoMarco">
            Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis 
            Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis
            Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis
            Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis
            Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis
            Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis Sinopsis
            </p>
        </div>

        <div class="MarcoContainerInfoPelicula">
	        <div class="TituloMarcoContainer">
		        <div class="TituloMarco">Información</div>
		        <div class="IconoMarco"></div>
	        </div>
            <div class="containerAccionInfoPelicula">
                <p class="textoDetalleInfoPelicula etiquetaInfoPelicula" >Duración:</p>
                <p id="Duracion" runat="server" class="textoDetalleInfoPelicula" >100 min</p>
            </div>
            
            <div class="containerAccionInfoPelicula">
                <p class="textoDetalleInfoPelicula etiquetaInfoPelicula" >Género:</p>
                <p id="Genero" runat="server" class="textoDetalleInfoPelicula" >Acción</p>
            </div>

            <div class="containerAccionInfoPelicula">
                <p class="textoDetalleInfoPelicula etiquetaInfoPelicula" >Evaluación:</p>
                <div class="containerEvaluacion">
                    <controles:EvaluacionControl ID="Evaluacion" runat="server" />
                </div>
            </div>                

            <div class="containerAccionInfoPelicula">
                <p class="textoDetalleInfoPelicula etiquetaInfoPelicula" >Modalidad:</p>
                <p id="Modalidad" runat="server" class="textoDetalleInfoPelicula" >Venta y alquiler</p>
            </div>                

        </div>
        
        <div class="MarcoContainerInfoPelicula">
	        <div class="TituloMarcoContainer">
		        <div class="TituloMarco">Reparto</div>
		        <div class="IconoMarco"></div>
	        </div>
	        
		    <asp:repeater id="Reparto" runat="server">
			    <ItemTemplate>
				    <div class="containerAccionInfoPelicula">
					    <a class="linkRepartoInfoPelicula" href='BusquedaActor.aspx?ActorID=<%#DataBinder.Eval(Container.DataItem, "ActorID")%>'>
						<img border="0" src="resources/buscar.gif" width="16" height="16"></a>
						<p class="textoRepartoInfoPelicula" ><%#DataBinder.Eval(Container.DataItem, "Actor.Nombre")%></p>
				    </div>
			    </ItemTemplate>
		    </asp:repeater>	        	        
        </div>
    </div>
    
    
    
    </asp:Content>

