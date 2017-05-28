var xamlScene;

function createSilverlight()
{
	xamlScene = new SilverlightControls.EstrenosControl();
	Silverlight.createObjectEx({
		source: "SilverlightControls/EstrenosControl.xaml",
		parentElement: document.getElementById("EstrenosControlHost"),
		id: "SilverlightControl",
		properties: {
			width: "100%",
			height: "100%",
			version: "1.0",
			isWindowless: "true",
			background: "#00ffffff"
		},
		events: {
			onLoad: Silverlight.createDelegate(xamlScene, xamlScene.handleLoad)
		}
	});
	
	document.getElementById("EstrenosControlHost").onresize = Silverlight.createDelegate(xamlScene, xamlScene.hostResize);
}


if (!window.Silverlight) 
	window.Silverlight = {};

Silverlight.createDelegate = function(instance, method) {
	return function() {
		return method.apply(instance, arguments);
	}
}
