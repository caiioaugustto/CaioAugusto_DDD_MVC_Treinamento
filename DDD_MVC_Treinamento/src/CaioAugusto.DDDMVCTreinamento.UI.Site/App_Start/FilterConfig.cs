using CaioAugusto.DDDMVCTreinamento.UI.Site.Filters;
using System.Web;
using System.Web.Mvc;

namespace CaioAugusto.DDDMVCTreinamento.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //FilterAttribute
            filters.Add(new GlobalErrorHandler());
        }
    }
}
