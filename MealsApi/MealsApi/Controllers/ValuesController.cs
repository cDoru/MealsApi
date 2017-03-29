using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using MealsApi.Controllers.Base;
using MealsApi.Utils;
using MealsApi.Utils.ActionFilters;

namespace MealsApi.Controllers
{
    //[Authorize] not autorizing for now 
    [CustomCors]
    public class ValuesController : BaseApiController
    {
        // GET api/values
        [ApiExplorerSettings(IgnoreApi = true)]
        [GlimpseActionFilter("Get values")]
        public IEnumerable<string> Get()
        {
            Log.Info("Values hit");
            return new[] { "value1", "value2" };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
