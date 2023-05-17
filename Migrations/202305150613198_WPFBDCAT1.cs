namespace CatBDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WPFBDCAT1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreedInformations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CountryOfOrigin = c.String(),
                        LifeExpectancy = c.String(),
                        Size = c.String(),
                        Weight_kg = c.Double(nullable: false),
                        CoatType = c.String(),
                        Color = c.String(),
                        Lifestyle = c.String(),
                        Group = c.String(),
                        Price = c.String(),
                        FamylyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamylyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Adaptabiliti = c.Int(nullable: false),
                        AttachmentTofamily = c.Int(nullable: false),
                        GameActivity = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        GeneralHealth = c.Int(nullable: false),
                        HairLoss = c.Int(nullable: false),
                        FriendlinessForChildren = c.Int(nullable: false),
                        FriendlyToDogs = c.Int(nullable: false),
                        LoveForMeow = c.Int(nullable: false),
                        FamylyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedInformations", "Id", "dbo.Families");
            DropForeignKey("dbo.Characters", "Id", "dbo.Families");
            DropIndex("dbo.Characters", new[] { "Id" });
            DropIndex("dbo.BreedInformations", new[] { "Id" });
            DropTable("dbo.Characters");
            DropTable("dbo.Families");
            DropTable("dbo.BreedInformations");
        }
    }
}
