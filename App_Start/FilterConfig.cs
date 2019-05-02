using SclBaseball.Filters;
using System.Web.Mvc;

namespace SclBaseball
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new RequireHttpsAttribute());
            //filters.Add(new RequireSslAttribute());
            filters.Add(new ErrorHandler.AiHandleErrorAttribute());
        }
    }
}
