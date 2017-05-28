if (!window.SilverlightControls)
	window.SilverlightControls = {};

SilverlightControls.EstrenosControl = function() 
{
}

SilverlightControls.EstrenosControl.prototype =
{
	handleLoad: function(control, userContext, rootElement) 
	{
		this.control = control;
		this.trailerMostrado = false;
		this.PanelMostrado = false;
		this.pendingPlay = false;
		
		var caratula, btnVerTrailer;
		var i;
				
		// Eventos de las carátulas
		this.caratulas = new Array();
		for(i=0;i<7;i++)
		{
		    caratula = rootElement.findName("caratula" + i);
		    this.caratulas[i] = caratula;
		    
		    caratula.addEventListener("MouseEnter",  Silverlight.createDelegate(this, this.handleMouseEnterCaratula));
		    caratula.addEventListener("MouseLeave",  Silverlight.createDelegate(this, this.handleMouseLeaveCaratula));
		    caratula.addEventListener("MouseLeftButtonDown",  Silverlight.createDelegate(this, this.handleMouseClickCaratula));
		}
		
		// Eventos de los botones
		btnVerTrailer = rootElement.findName("btnVerTrailer");
		btnVerTrailer.addEventListener("MouseEnter",  Silverlight.createDelegate(this, this.handleBtnMouseEnter));
		btnVerTrailer.addEventListener("MouseLeave",  Silverlight.createDelegate(this, this.handleBtnMouseLeave));
		btnVerTrailer.addEventListener("MouseLeftButtonDown",  Silverlight.createDelegate(this, this.handleBtnMouseLeftButtonDown));
		btnVerTrailer.addEventListener("MouseLeftButtonUp",  Silverlight.createDelegate(this, this.handleBtnMouseLeftButtonUp));

		btnVerSinopsis = rootElement.findName("btnVerSinopsis");
		btnVerSinopsis.addEventListener("MouseEnter",  Silverlight.createDelegate(this, this.handleBtnMouseEnter));
		btnVerSinopsis.addEventListener("MouseLeave",  Silverlight.createDelegate(this, this.handleBtnMouseLeave));
		btnVerSinopsis.addEventListener("MouseLeftButtonDown",  Silverlight.createDelegate(this, this.handleBtnMouseLeftButtonDown));
		btnVerSinopsis.addEventListener("MouseLeftButtonUp",  Silverlight.createDelegate(this, this.handleBtnMouseLeftButtonUp));
		
		rootElement.findName("OcultarDetallePelicula").addEventListener("Completed",  Silverlight.createDelegate(this, this.handlePanelOcultado));
		rootElement.findName("MostrarDetallePelicula").addEventListener("Completed",  Silverlight.createDelegate(this, this.handlePanelMostrado));
		rootElement.findName("VideoWindow").addEventListener("CurrentStateChanged",  Silverlight.createDelegate(this, this.handleVideoStateChanged));
		
		
		// Tratamiento del tamaño del control
        this.control.style.position = "absolute";
		this.hostResize(null, null);
		
		// Enlazar con películas
        var svc = new AJAXService();	    
        svc.ObtenerPeliculasEstreno(Silverlight.createDelegate(this, this.OnEndObtenerPeliculasEstreno));
				
		// Video del trailer
		this._player = $create(   EePlayer.Player, 
                                  {
                                    autoPlay    : false, 
                                    volume      : 1.0,
                                    muted       : false
                                  }, 
                                  {
                                  },
                                  null, $get(this.control.id)  ); 
	},
	
	OnEndObtenerPeliculasEstreno: function(peliculas) 
	{
	    var i;
	    this.peliculas = peliculas;
	    
	    for(i=0;i<7;i++)
	    {
	        this.caratulas[i].Source = "Caratula.aspx?CodBarras=" + this.peliculas[i].CodBarras + "&Ancho=150&Alto=200";
	        this.caratulas[i].tag = i + "";
	    }
	},
		
	hostResize: function(sender, eventArgs) 
	{	
		var numCaratulas;
		var widthCaratula = this.caratulas[0].Width;
		var widthControl = document.getElementById("EstrenosControlHost").clientWidth;    
		var separacionCaratula, offsetPrimeraCaratula;
		var i;

	    this.control.height = 500;
	    this.control.width = widthControl;
		this.control.content.findName("Page").Width = this.control.clientWidth;
		this.control.content.findName("ListaPeliculas").Width = this.control.clientWidth;
		this.control.content.findName("FondoListaPeliculas").Width = this.control.clientWidth;
		
		// Centrado de carátulas
		numCaratulas = Math.floor(widthControl / (widthCaratula * 1.5));
		if(numCaratulas > 0)
		{
		    separacionCaratula = widthControl / numCaratulas;
		    offsetPrimeraCaratula = (widthControl - widthCaratula * numCaratulas) / (numCaratulas * 2);
		}
		else
		{
		    separacionCaratula = offsetPrimeraCaratula = 0;
		}
		
		for(i=0;i<7;i++)
		{
		    this.caratulas[i]["Canvas.Left"] = offsetPrimeraCaratula + (separacionCaratula * i);
            if(i<numCaratulas)		    
                this.caratulas[i].Visibility = "Visible";
            else
                this.caratulas[i].Visibility = "Collapsed";             
		}
		
		// Panel de detalles
		var panelDetalles = this.control.content.findName("PanelDetalles");
		panelDetalles["Canvas.Left"] = (widthControl - panelDetalles.Width)/2;
	},
	
	handleMouseEnterCaratula: function(sender, eventArgs) 
	{
	    var mouseEnterSB = this.control.content.findName("Page").findName("MouseEnterCaratula");
	    
	    mouseEnterSB.Stop();
	    mouseEnterSB.findName("MouseEnterCaratula_key0")["Storyboard.TargetName"] = sender.Name;
	    mouseEnterSB.findName("MouseEnterCaratula_key1")["Storyboard.TargetName"] = sender.Name;
	    mouseEnterSB.Begin();
	},
	
	handleMouseLeaveCaratula: function(sender, eventArgs) 
	{
	    var mouseLeaveSB = this.control.content.findName("Page").findName("MouseLeaveCaratula");
	    
	    mouseLeaveSB.Stop();
	    mouseLeaveSB.findName("MouseLeaveCaratula_key0")["Storyboard.TargetName"] = sender.Name;
	    mouseLeaveSB.findName("MouseLeaveCaratula_key1")["Storyboard.TargetName"] = sender.Name;
	    mouseLeaveSB.Begin();
	},
	
	handleMouseClickCaratula: function(sender, eventArgs) 
	{
	    // Guardamos película seleccionada
	    this.selPelicula = sender.tag;
	    
	    // Ocultamos panel
	    if(this.PanelMostrado)
	    {
	        var ocultarDetalleSB = this.control.content.findName("Page").findName("OcultarDetallePelicula");
	        ocultarDetalleSB.Stop();
	        ocultarDetalleSB.Begin();	    	    
	    }
	    else
	    {
	        this.PanelMostrado = true;
	        this.handlePanelOcultado();
	    }
	    
	},
	
	handlePanelOcultado: function(sender, eventArgs) 
	{
	    this.control.content.findName("TituloPelicula").Text = this.peliculas[this.selPelicula].Titulo;
	    this.control.content.findName("SinopsisPelicula").Text = this.peliculas[this.selPelicula].Sinopsis;
	    this.control.content.findName("CaratulaDetalle").Source = "Caratula.aspx?CodBarras=" + this.peliculas[this.selPelicula].CodBarras + "&Ancho=150&Alto=200";

        if(this.trailerMostrado)
	    {
	        video = this.control.content.findName("VideoWindow");
	        this.control.content.findName("TransformPanelDetalles").X = 0;
	        video.Stop();
	        this.trailerMostrado = false;
	    }
	    
	    // Mostramos panel
	    this.DetallesMostrados = true;
	    var mostrarDetalleSB = this.control.content.findName("Page").findName("MostrarDetallePelicula");
	    mostrarDetalleSB.Stop();
	    mostrarDetalleSB.Begin();
	    
	},
	
	handlePanelMostrado:function(sender, eventArgs) 
	{
	    this.control.content.findName("VideoWindow").Source = this.peliculas[this.selPelicula].URLTrailer;
	},
	
	handleBtnMouseEnter: function(sender, eventArgs) 
	{
	    var txt = sender.Name;
	    var sb = sender.findName("MouseEnterBoton");
	    sb.Stop();
	    sb.findName("MouseEnterBoton_key0")["Storyboard.TargetName"] = txt + "Highlight";
	    sb.Begin();
	},
	
	handleBtnMouseLeave: function(sender, args)
    {
	    var txt = sender.Name;
	    var sb = sender.findName("MouseLeaveBoton");
	    sb.Stop();
	    sb.findName("MouseLeaveBoton_key0")["Storyboard.TargetName"] = txt + "Highlight";
	    sb.Begin();
    },

    handleBtnMouseLeftButtonDown: function(sender, args)
    {
        var sb;
        var video;
	    var txt = sender.Name;
	    sender.findName(txt + "ClickHighlight").opacity = 1.0;
	    
	    // Mostramos sinopsis - caratula
	    video = sender.findName("VideoWindow");
	    if(this.trailerMostrado)
	    {
	        sb = sender.findName("MostrarSinopsis");
	        video.Stop();
	        this.trailerMostrado = false;
	    }
	    else
	    {
	        sb = sender.findName("MostrarTrailer");
	        if(video.CurrentState != "Opening")
	            video.Play();
	        else
	            this.pendingPlay = true;
	        this.trailerMostrado = true;
	    }
	    
	    sb.Stop();
	    sb.Begin();
    },	
    
    handleVideoStateChanged: function(sender, args)
    {
        if(this.pendingPlay && sender.CurrentState == "Stopped")
        {
            this.pendingPlay = false;
            sender.Play();
        }
    },

    handleBtnMouseLeftButtonUp: function(sender, args)
    {
	    var txt = sender.Name;
	    sender.findName(txt + "ClickHighlight").opacity = 0.0;
    }
}
