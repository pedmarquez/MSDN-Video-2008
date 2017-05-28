function menuSelect(elem, cls)
{		
	var t;
	if(document.getElementById)
		t = document.getElementById(elem);
	else
		t = document.all(elem);
	if(t==null)
	{
		t = event.srcElement;
		while(t.onmouseover == null)
		    t = t.parentElement;
	}
	if(t==null)
	    return;
	t.className = cls;
	
	return false;
}

function ControlSetFocus(elem)
{
	var t;
	if(document.getElementById)
		t = document.getElementById(elem);
	else
		t = document.all(elem);
	if(t==null)
		return;
		
	t.focus();
}

function document.onkeypress()
{
	var t;
	if (typeof(defaultButton)=="undefined" || window.event.keyCode!=13)
		 return;

	if(document.getElementById)
		t = document.getElementById(defaultButton);
	else
		t = document.all(defaultButton);
	if(t==null)
		return;

	t.click();
	window.event.returnValue = false;
	return false;
}
