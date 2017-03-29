using MealsApi.Utils.Upload;

namespace MealsApi.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestMealDto
    {
        public string Name { get; set; }

        public HttpFile Image { get; set; }

        public int Rating { get; set; }
    }
}