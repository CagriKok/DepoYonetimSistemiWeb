using System.Web.Mvc;

namespace DepoYonetimSistemi.Web.Areas.Yonetim
{
    public class YonetimAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Yonetim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Yonetim_default",
                "Yonetim/{controller}/{action}/{id}",
                new { controller = "DashBoard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}