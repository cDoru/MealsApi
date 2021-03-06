using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace MealsApi.Results
{
    public abstract class RouteLocationResult : IHttpActionResult
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string RouteName { get; private set; }
        public IDictionary<string, object> RouteValues { get; private set; }

        private readonly UrlHelper _urlFactory;
        private readonly HttpRequestMessage _request;

        protected RouteLocationResult(HttpStatusCode statusCode, string routeName, IDictionary<string, object> routeValues, ApiController controller)
            : this(statusCode, routeName, routeValues, controller.Url, controller.Request)
        {
        }

        protected RouteLocationResult(HttpStatusCode statusCode, string routeName, IDictionary<string, object> routeValues, UrlHelper urlFactory, HttpRequestMessage request)
        {
            if (!Enum.IsDefined(typeof (HttpStatusCode), statusCode))
            {
                throw new InvalidEnumArgumentException("statusCode", (int)statusCode, typeof(HttpStatusCode));
            }

            if (routeName == null) throw new ArgumentNullException("routeName");
            if (routeValues == null) throw new ArgumentNullException("routeValues");
            if (urlFactory == null) throw new ArgumentNullException("urlFactory");
            if (request == null) throw new ArgumentNullException("request");
            StatusCode = statusCode;
            RouteName = routeName;
            RouteValues = routeValues;
            _urlFactory = urlFactory;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            var httpResponseMessage = new HttpResponseMessage(StatusCode);

            try
            {
                var uriString = _urlFactory.Link(RouteName, RouteValues);

                if (uriString == null)
                {
                    throw new InvalidOperationException("Link must not return null.");
                }

                httpResponseMessage.Headers.Location = new Uri(uriString);
                httpResponseMessage.RequestMessage = _request;
            }
            catch
            {
                httpResponseMessage.Dispose();
                throw;
            }

            return httpResponseMessage;
        }
    }
}