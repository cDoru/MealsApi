using System.Collections.Generic;
using System.Web.Http;
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

        [GlimpseActionFilter("Get values")]
        public IEnumerable<string> Get()
        {
            Log.Info("Values hit");
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
