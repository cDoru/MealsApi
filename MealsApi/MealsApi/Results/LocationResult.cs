using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MealsApi.Results
{
    public abstract class LocationResult : IHttpActionResult
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Location { get; private set; }

        private readonly HttpRequestMessage _request;

        protected LocationResult(HttpStatusCode statusCode, string location, ApiController controller)
            : this(statusCode, location, controller.Request)
        {
        }

        protected LocationResult(HttpStatusCode statusCode, string location, HttpRequestMessage request)
        {
            // Not guarding against not defined enum value as some code are missing, for example 308 (Permanent Redirect)
            if (location == null) throw new ArgumentNullException("location");
            if (request == null) throw new ArgumentNullException("request");
            StatusCode = statusCode;
            Location = location;
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
                httpResponseMessage.Headers.Location = new Uri(Location);
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