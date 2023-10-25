using System.Web;
using System.Web.Mvc;

namespace ProyectoAula4_SantiagoVieira_JohnSebastianVillegas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
