using casodeestudio.Filters;
using System.Web;
using System.Web.Mvc;

namespace casodeestudio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomErrorFilter());
            filters.Add(new AuditoriaFilter());

        }
    }
}
