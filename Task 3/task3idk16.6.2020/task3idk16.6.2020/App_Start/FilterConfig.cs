using System.Web;
using System.Web.Mvc;

namespace task3idk16._6._2020
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new HandleErrorAttribute());
            // New code:
            filters.Add(new RequireHttpsAttribute());
            
        }
    }
}
