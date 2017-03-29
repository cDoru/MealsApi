namespace MealsApi.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 2000),
                        MimeType = c.String(nullable: false, maxLength: 32),
                        DateStoredUtc = c.DateTime(nullable: false),
                        MealId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .Index(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "MealId", "dbo.Meals");
            DropIndex("dbo.Images", new[] { "MealId" });
            DropTable("dbo.Images");
            DropTable("dbo.Meals");
        }
    }
}
