using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace DepoYonetimSistemi.Web.Filters
{
    public class KimlikAttribute : FilterAttribute, IAuthenticationFilter
    {

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.Principal.Identity.IsAuthenticated && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new EmptyResult();
            }
            else if (!filterContext.Principal.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                       new RouteValueDictionary(
                           new
                           {
                               controller = "Login",
                               action = "Index"
                           }));
            }
            else if (filterContext.Result is EmptyResult)
            {
                filterContext.HttpContext.Response.Write(System.Web.Helpers.Json.Encode(new { statusCode = 403, message = "Giriş yapılması gerekmektedir", data = new { } }));
            }
        }
    }

}
