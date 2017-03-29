using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;
using MealsApi.Utils.Glimpse;

namespace MealsApi.Utils.ActionFilters
{
    public class GlimpseActionFilterAttribute : ActionFilterAttribute
    {
        private readonly string _descriptor;
        private OngoingCapture _ongoingCapture;

        public GlimpseActionFilterAttribute(string descriptor)
        {
            _descriptor = descriptor;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _ongoingCapture = GlimpseTimeline.Capture(_descriptor);
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _ongoingCapture.Dispose();

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}