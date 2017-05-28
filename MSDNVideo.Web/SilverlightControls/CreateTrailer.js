var xamlScene;

function createSilverlight(videoURL)
{
	xamlScene = new SilverlightControls.TrailerControl(videoURL);
	Silverlight.createObjectEx({
		source: "SilverlightControls/TrailerControl.xaml",
		parentElement: document.getElementById("TrailerControlHost"),
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
}


if (!window.Silverlight) 
	window.Silverlight = {};

Silverlight.createDelegate = function(instance, method) {
	return function() {
		return method.apply(instance, arguments);
	}
}
