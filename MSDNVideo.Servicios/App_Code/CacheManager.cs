using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Caching;

/// <summary>
/// Clase wrapper de la caché de ASP.NET
/// Para usar esta caché es necesario estar hospedado en ASP.NET
/// Para otros casos es necesario sustituir el sistema de caché por otro
/// (por ejemplo el de Enterprise Blocks)
/// </summary>
public class CacheManager
{
    public static object GetItem(string key)
    {
        if (CacheInstance != null)
            return CacheInstance[key];
        else
            return null;
    }

    public static void AddItem(string key, object value)
    {
        if (CacheInstance != null)
            CacheInstance.Add(key, value, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), CacheItemPriority.Normal, null);
    }

    private static Cache CacheInstance
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Cache;
            else
                return null;
        }
    }
}
