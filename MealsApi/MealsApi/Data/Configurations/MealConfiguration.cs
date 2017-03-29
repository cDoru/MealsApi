using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MealsApi.Data.Entities;

namespace MealsApi.Data.Configurations
{
    public class MealConfiguration : EntityTypeConfiguration<Meal>
    {
        private const string TableName = "Meals";

        public MealConfiguration() : this("dbo")
        {
            
        }

        private MealConfiguration(string schema)
        {
            ToTable(TableName, schema);
            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(1000)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Rating)
                .HasColumnName("Rating")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasMany(x => x.Images).WithRequired(x => x.Meal).HasForeignKey(x => x.MealId);
        }
    }
}