using System;

namespace MealsApi.Data.Contracts
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
    }
}