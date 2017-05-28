if (!window.SilverlightControls)
	window.SilverlightControls = {};

SilverlightControls.TrailerControl = function(videoURL) 
{
    this.videoURL = videoURL;
}

SilverlightControls.TrailerControl.prototype =
{
	handleLoad: function(control, userContext, rootElement) 
	{
		this.control = control;
		this.videoShown = false;
		this.pendingPlay = false;
								
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
                                  
        video = this.control.content.findName("VideoWindow");
	    video.Source = this.videoURL;
	    video.addEventListener("CurrentStateChanged",  Silverlight.createDelegate(this, this.handleVideoStateChanged));
	    
	    var mainCanvas = this.control.content.findName("MainCanvas");
	    mainCanvas.addEventListener("MouseEnter",  Silverlight.createDelegate(this, this.handleVideoMouseEnter));
	    mainCanvas.addEventListener("MouseLeave",  Silverlight.createDelegate(this, this.handleVideoMouseLeave));
	},
	
	setVideo: function(videoURL)
	{
	    this.videoURL = videoURL;	    
	},
	
	handleVideoMouseEnter: function()
	{
	    if(!this.videoShown)
	    {
	        var sb = this.control.content.findName("ShowVideo");
	        sb.Stop();
	        sb.Begin();
	        video = this.control.content.findName("VideoWindow");
	        
	        if(video.CurrentState != "Opening")
	            video.Play();
	        else
	            this.pendingPlay = true;
	            
	        this.videoShown = true;
	    }
	},
	
	handleVideoStateChanged: function(sender, args)
    {
        if(this.pendingPlay && sender.CurrentState == "Stopped")
        {
            this.pendingPlay = false;
            sender.Play();
        }
    },

	
	handleVideoMouseLeave: function()
	{
	    
	}
}
