using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using MealsApi.Results;

namespace MealsApi.Controllers.Base
{
    public abstract class BaseApiController : ApiController
    {
        public NoContentResult NoContent()
        {
            return new NoContentResult(this);
        }

        public MovedPermanentlyResult RedirectPermanentlyToRoute(string routeName, object routeValues)
        {
            return RedirectPermanentlyToRoute(routeName, new HttpRouteValueDictionary(routeValues));
        }

        public MovedPermanentlyResult RedirectPermanentlyToRoute(string routeName, IDictionary<string, object> routeValues)
        {
            return new MovedPermanentlyResult(routeName, routeValues, this);
        }
    }
}