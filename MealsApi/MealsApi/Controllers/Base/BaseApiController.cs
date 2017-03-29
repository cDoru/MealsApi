using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Routing;
using Common.Logging;
using MealsApi.Results;

namespace MealsApi.Controllers.Base
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly ILog Log;

        protected BaseApiController()
        {
            Log = LogManager.GetLogger(GetType());
        }


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