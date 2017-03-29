using System;

namespace MealsApi.Data.Contracts
{
    public interface IGuidGenerator
    {
        Guid NewId();
    }
}