using System.Web;
using System.Web.Mvc;

namespace RedStore_Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // for glabal filter of authorize  instead of controller or method
        }
    }
}
