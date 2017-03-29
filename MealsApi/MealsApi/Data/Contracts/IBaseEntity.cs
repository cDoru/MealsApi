using System;

namespace MealsApi.Data.Contracts
{
    public interface IBaseEntity
    {
        Guid Id { get; }
    }
}