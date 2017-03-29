using System.Data.Entity;

namespace MealsApi.Data.Contracts
{
    public interface IConfigurationModule
    {
        void Register(DbModelBuilder modelBuilder);
    }
}