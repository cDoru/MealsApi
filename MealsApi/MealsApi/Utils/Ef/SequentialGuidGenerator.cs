using System;
using MealsApi.Data.Contracts;

namespace MealsApi.Utils.Ef
{
    public class SequentialGuidGenerator : IGuidGenerator
    {
        public Guid NewId()
        {
            return SequentialGuid.NewSequentialGuid();
        }
    }
}