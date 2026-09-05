using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PersonalWebsite.Areas.Admin.Filters
{
    public class AdminYetkiFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var girisYapildi = context.HttpContext.Session.GetString("AdminGiris");
            if (girisYapildi != "1")
            {
                context.Result = new RedirectToRouteResult(new Microsoft.AspNetCore.Routing.RouteValueDictionary
                {
                    { "area", "Admin" },
                    { "controller", "Giris" },
                    { "action", "Index" }
                });
            }
        }
    }
}