using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepoYonetimSistemi.Web.Filters
{
    public class HataAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "Hata",
                ViewData = new ViewDataDictionary(filterContext.Exception)
            };
            filterContext.ExceptionHandled = true;
        }
    }
}