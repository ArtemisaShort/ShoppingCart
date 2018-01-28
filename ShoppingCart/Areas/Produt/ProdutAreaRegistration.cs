using System.Web.Mvc;

namespace ShoppingCart.Areas.Produt
{
    public class ProdutAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Produt";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Produt_default",
                "Produt/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}