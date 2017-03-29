using System.Data.Entity;
using MealsApi.Data.Configurations;
using MealsApi.Data.Contracts;

namespace MealsApi.Data
{
    public class ContextConfigurationModule : IConfigurationModule
    {
        public void Register(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MealConfiguration());
            modelBuilder.Configurations.Add(new ImageConfiguration());
        }
    }
}