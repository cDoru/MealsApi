using MealsApi.Utils.Upload;

namespace MealsApi.Requests
{
    public class NewMealDto
    {
        public string Name { get; set; }

        public HttpFile Image { get; set; }

        public int Rating { get; set; }
    }
}