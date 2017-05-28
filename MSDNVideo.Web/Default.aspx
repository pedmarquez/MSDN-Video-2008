<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Bienvenido a MSDN Video" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Estilos.css" />
</asp:Content>

<asp:Content id="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="AJAXService.asmx" />
        </Services>
    </asp:ScriptManager>

    <script type="text/javascript" src="SilverlightControls/Silverlight.js"></script>
    <script type='text/javascript' src="SilverlightControls/BasePlayer.js"></script>
    <script type='text/javascript' src="SilverlightControls/PlayerStrings.js"></script>
	<script type="text/javascript" src="SilverlightControls/CreateEstrenos.js"></script>
	<script type="text/javascript" src="SilverlightControls/EstrenosControl.xaml.js"></script>

<div class="fondoDefault">
    <br />
    <div class="MarcoContainer">
	    <div class="TituloMarcoContainer">
		    <div class="TituloMarco">Bienvenido</div>
		    <div class="IconoMarco"></div>
	    </div>
	    <div>
                <p class="TextoMarco">
                Bienvenido al sitio web de MSDN Video. Ésta es la implementación 
                ASP.NET&nbsp;del frontal de la aplicación. Si quiere descargar el código fuente 
                de toda la aplicación y el tutorial de su implementación visite la web de <a href="http://www.desarrollaconmsdn.com/msdn/MSDNVideo.aspx">
                MSDN Video</a>
                </p>
        </div>
    </div>    
    
    <div class="MarcoContainer">
	    <div class="TituloMarcoContainer">
		    <div class="TituloMarco">Estrenos</div>
		    <div class="IconoMarco"></div>
	    </div>
	    <div>
                <div id="EstrenosControlHost" class="estrenosControl">
		        <script type="text/javascript">
			        createSilverlight();
		        </script> </div>
        </div>
    </div>  
    
    <div class="MarcoContainer">
	    <div class="TituloMarcoContainer">
		    <div class="TituloMarco">Alquilar por Internet</div>
		    <div class="IconoMarco"></div>
	    </div>
	    <div>
            <div id="Div1" class="estrenosControl">
		        <p class="TextoMarco">
                Alquile o compre 
			    el mejor cine a cualquier hora y desde casa. Si ya es socio de nuestra tienda 
			    sólo tiene que <a href="Conectar.aspx">iniciar sesión</a> y comenzar a 
			    consultar nuestro catálogo de películas. Si todavía no es socio acérquese a 
			    nuestro local para obtener nuestra exclusiva tarjeta <b>MSDN Video</b>. Le 
			    atendemos en la siguiente dirección:
			    </p>
		        <p class="TextoMarco direccion"><i>MSDN Video<br/>
			        Avda. del Cine, 8<br/>
			        28760 Ciudad del Cine <b>MADRID</b></i>
                </p>
             </div>
        </div>
    </div>  
    
</div>
</asp:Content>


