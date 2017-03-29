using System.Data.Entity.Migrations;

namespace MealsApi.Data
{
    public class ContextConfiguration : DbMigrationsConfiguration<DatabaseContext>
    {
        public ContextConfiguration()
        {
            // disable automatic migrations
            AutomaticMigrationsEnabled = false;
        }
    }
}