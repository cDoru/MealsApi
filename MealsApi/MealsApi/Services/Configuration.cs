using System.Configuration;

namespace MealsApi.Services
{
    public class Configuration : IConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string 
            GetConfigurationValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}