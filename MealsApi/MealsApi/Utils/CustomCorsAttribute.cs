using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace MealsApi.Utils
{
    public class CustomCorsAttribute : Attribute, ICorsPolicyProvider
    {
        private readonly CorsPolicy _policy;

        public CustomCorsAttribute()
        {
            _policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true
            };

            _policy.Origins.Add("localhost");
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}