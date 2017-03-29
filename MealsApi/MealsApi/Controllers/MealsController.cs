using System;
using System.Collections.Generic;
using System.Web.Hosting;
using System.Web.Http;
using MealsApi.Controllers.Base;
using MealsApi.Requests;
using MealsApi.Responses;
using MealsApi.Services;
using MealsApi.Utils;

namespace MealsApi.Controllers
{
    /// <summary>
    /// Meals Controller
    /// </summary>

    [CustomCors]
    
    public class MealsController : BaseApiController
    {
        private readonly IFileSystem _fileSystem;
        private readonly IMealService _mealService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="mealService"></param>
        public MealsController(IFileSystem fileSystem, IMealService mealService)
        {
            var mapPath = HostingEnvironment.MapPath("~/App_Data");

            _fileSystem = fileSystem;
            _mealService = mealService;
        }

        public IEnumerable<MealDto> Get()
        {
            Log.Info("Values hit");
            return new[] { new MealDto
            {
                Name = "Risotto",
                Rating = 2,
                Url = "http://www.meals.com/221423234234.jpg"
            } };
        }

        // GET api/values/5
        public MealDto Get(Guid id)
        {
            return new MealDto
            {
                Name = "Risotto",
                Rating = 2,
                Url = "http://www.meals.com/221423234234.jpg"
            };
        }

        // POST api/values
        public void Post([FromBody]RequestMealDto value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]RequestMealDto value)
        {
        }

        // DELETE api/values/5
        public void Delete(Guid id)
        {
        }
    }
}