using System.Data.Entity;
using MealsApi.Data.Entities;

namespace MealsApi.Data.Contracts
{
    public interface IDatabaseContext : IDbContext
    {
        IDbSet<Meal> Meals { get; } 
    }
}