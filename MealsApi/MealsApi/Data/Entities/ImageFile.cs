using System;
using MealsApi.Data.Contracts;

namespace MealsApi.Data.Entities
{
    public class ImageFile : BaseEntity
    {
        public string FileName { get; set; }

        public string MimeType { get; set; }

        public DateTime DateStoredUtc { get; set; }

        public Guid? MealId { get; set; }

        public virtual Meal Meal { get; set; }
    }
}