using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Radius.UI.Utils
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Allows json to exhange across platforms
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
#if DEBUG
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
#endif
            base.OnActionExecuting(filterContext);
        }
    }
}