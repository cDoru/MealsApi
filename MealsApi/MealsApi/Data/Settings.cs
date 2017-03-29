using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MealsApi.Data
{
    internal class Settings
    {
#if DEBUG
        public const string DbConnection = "Data Source=.;Initial Catalog=Meals;Integrated Security=True;";
#endif
    }
}