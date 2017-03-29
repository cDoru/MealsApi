namespace MealsApi.Services
{
    public interface IConfiguration
    {
        string GetConfigurationValue(string key);
    }
}