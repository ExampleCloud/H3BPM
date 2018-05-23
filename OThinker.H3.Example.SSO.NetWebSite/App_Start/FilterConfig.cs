using System.Web;
using System.Web.Mvc;

namespace OThinker.H3.Example.SSO.NetWebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
