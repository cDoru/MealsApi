using System.Data.Entity;
using MealsApi.Data.Context;
using MealsApi.Data.Contracts;
using MealsApi.Data.Entities;
using MealsApi.Services;
using MealsApi.Utils.Extensions;

namespace MealsApi.Data
{
    public class DatabaseContext : DbContextBase,  IDatabaseContext
    {
        public DatabaseContext(IConfiguration configuration, IGuidGenerator generator)
            : base(configuration, generator, new ContextConfigurationModule())
        {
            this.DisableDatabaseInitialization();
        }

        // only used in development
        internal DatabaseContext(string connectionString)
            : base(connectionString, new ContextConfigurationModule())
        {
            this.DisableDatabaseInitialization();
        }

        public IDbSet<Meal> Meals { get; set; }
        public IDbSet<ImageFile> Images { get; set; } 
    }
}