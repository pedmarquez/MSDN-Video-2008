using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Controles_EvaluacionControl : System.Web.UI.UserControl
{
    private decimal _evaluacion;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public decimal Evaluacion
    {
        get
        {
            return _evaluacion;
        }
        set
        {
            _evaluacion = value;

            for (int i = 0; i < 5; i++)
            {
                HtmlImage imgControl = (HtmlImage)FindControl("imgEstrella" + i);
                if (_evaluacion >= i * 2 + 2)
                    imgControl.Src = "../resources/1Estrella.gif";
                else if (_evaluacion >= i * 2 + 1)
                    imgControl.Src = "../resources/MediaEstrella.gif";
            }
        }
    }
}
