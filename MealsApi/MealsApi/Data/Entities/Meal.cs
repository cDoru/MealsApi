using System.Collections.Generic;
using MealsApi.Data.Contracts;

namespace MealsApi.Data.Entities
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }

        public int Rating { get; set; }

        public virtual ICollection<ImageFile> Images { get; set; }
    }
}