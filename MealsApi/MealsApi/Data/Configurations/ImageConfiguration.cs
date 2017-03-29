using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MealsApi.Data.Entities;

namespace MealsApi.Data.Configurations
{
    public class ImageConfiguration : EntityTypeConfiguration<ImageFile>
    {
        private const string TableName = "Images";

        public ImageConfiguration() : this("dbo")
        {
            
        }

        private ImageConfiguration(string schema)
        {
            ToTable(TableName, schema);
            HasKey(x => x.Id);

            Property(x => x.DateStoredUtc)
                .HasColumnName("DateStoredUtc")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.FileName)
                .HasColumnName("FileName")
                .HasColumnType("nvarchar")
                .HasMaxLength(2000)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.MimeType)
                .HasColumnName("MimeType")
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}