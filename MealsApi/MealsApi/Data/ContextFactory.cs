using System.Data.Entity.Infrastructure;

namespace MealsApi.Data
{
    public class ContextFactory : IDbContextFactory<DatabaseContext>
    {
#if DEBUG

        public DatabaseContext Create()
        {
            return new DatabaseContext(Settings.DbConnection);
        }

#endif

    }
}